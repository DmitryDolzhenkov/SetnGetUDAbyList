using System;
using System.Text;
using System.IO;
using System.Collections;
using System.ComponentModel;
using System.Collections.Generic;
using System.Windows.Forms;
using TSMUI = Tekla.Structures.Model.UI;
using Tekla.Structures.Model.Operations;
using TS = Tekla.Structures;
using TSM = Tekla.Structures.Model;
//using TSDrw = Tekla.Structures.Drawing;
//using Tekla.Structures.Solid;
using Tekla.Structures.Model;
using TSD = Tekla.Structures.Drawing;
using TSDUI = Tekla.Structures.Drawing.UI;

using System.Runtime.InteropServices;
using System.Globalization;
using System.Linq;
using System.Diagnostics;
using System.Threading;


using Excel = Microsoft.Office.Interop.Excel;
using System.Drawing;
using System.Runtime.Remoting.Messaging;

namespace SetnGetAttribute
{
    public enum eTypeofList
    {
        OnlyWithValues = 0,
        Full = 1
    }
    public partial class SetAttributeFromList : Form
    {
        private TSM.Events TsEvents;

        static public Encoding enc = Encoding.GetEncoding(1251);
        string lastSetting = "";
        TSM.Model _model = new Model();
        string _filepath;
        public static string PathofLog;
        //private static Thread workerThread;
        public static Tuple<string, eDefineAType> RepAtt;
        public static Tuple<string, eUDAType> UserAtt;

        public AppDataFile DataFile = new AppDataFile();
        public string RegeditKeyforApp = "Software\\BelEnergomash\\" + Application.ProductName;

        public SetAttributeFromList()
        {
            string filename = @"\Attribute_Value.xlsx";
            _filepath = GetModelDirectory() + filename;
            InitializeComponent();

            methApplyValues();
            GetExternalSettings();
        }
        private void GetExternalSettings()
        {
            //UDA.listOfExceptionalUDA = new List<string>();
            //UDA.listOfExceptionalUDA = UDA.ListOfExceptionalUDA(); 
            //UDA.listOfExternalAttributes = UDA.GetExternalAttributes();
        }
        public static void SetPathLog()
        {
            PathofLog = GetPathofLog();
            if (File.Exists(SetAttributeFromList.PathofLog))
            {
                File.Delete(PathofLog);
            }
        }
        private static string GetPathofLog()
        {
            string filePath = string.Empty;
            string filename = Application.ProductName + ".log";

            string temp_dir = System.Environment.GetEnvironmentVariable("Temp");
            if (!temp_dir.EndsWith(@"\"))
            {
                temp_dir = temp_dir + '\\';
            }
            filePath = temp_dir + filename;
            return filePath;
        }
        private void methApplyValues()
        {
            methOptionsRead();
            methOptionsWrite(false);

            if (File.Exists(DataFile.filename))
            {
                DataFile.Read();
            }

            tbLocationExcel.Text = DataFile.ExcelPath;
            cBTypeOfsecondcolumn.Checked = DataFile.BothRepAttribute;
            tbRepAttr.Text = DataFile.DA.Name;
            cBReportAttrDatatype.Text = DataFile.DA.Type.ToString();
            tbUserAttr.Text = DataFile.UDA.Name;
            cBUDADatatype.Text = DataFile.UDA.Type.ToString();
            if(DataFile.objectSelectorType == AppDataFile.eObjectSelectorType.Model)
            {
                cBModelObj.Checked = true;
                cBDrawingObj.Checked = false;
            }
            else
            {
                cBModelObj.Checked = false;
                cBDrawingObj.Checked = true;
            }
        }

        
       

        private void GetSettingsFromMainForm()
        {
            string reptype = cBReportAttrDatatype.Text.ToLower();
            string udatype = cBUDADatatype.Text.ToLower();
            
            eDefineAType DAType = (reptype == "double") ? eDefineAType.Double : (reptype == "int") ? eDefineAType.Int : eDefineAType.String;
            eUDAType UDAType = (udatype == "double") ? eUDAType.Double : (udatype == "int") ? eUDAType.Int : eUDAType.String;

            RepAtt = new Tuple<string, eDefineAType>(tbRepAttr.Text, DAType);
            UserAtt = new Tuple<string, eUDAType>(tbUserAttr.Text, UDAType);
        }

        private List<TSItem> GetListofAsmFromFile()
        {
            List<TSItem> listofassm = new List<TSItem>();

            string filepath = tbLocationExcel.Text;
            if (File.Exists(filepath))
            {
                string fulllist = ReadTextFile(filepath);
                if (fulllist == "ERROR") return null;
                List<string> parseattributes = Listofstring(fulllist);
                listofassm = GetListOfAsm(parseattributes);
            }
            
            return listofassm;
        }
        private static List<TSItem> GetListOfAsm(List<string> parseattributes)
        {
            List<TSItem> listexternalAtt = new List<TSItem>();
            foreach (var item in parseattributes)
            {
                TSItem assemblyItem = new TSItem();
                List<string> attributes = new List<string>();
                if (item.Contains(';'))
                {
                    attributes = item.Split(';').ToList();
                    assemblyItem.ReportAttribute = attributes[0];
                    assemblyItem.UserAttribute = attributes[1];
                    listexternalAtt.Add(assemblyItem);
                }
            }
            return listexternalAtt;
        }
        private static List<string> Listofstring(string fulllist)
        {
            List<string> attributes = new List<string>();
            List<string> parseattributes = new List<string>();
            attributes = fulllist.Split('\n').ToList();
            foreach (var item in attributes)
            {
                string new_name = item.TrimEnd('\r');
                parseattributes.Add(new_name);
            }
            return parseattributes;
        }
        private static string ReadTextFile(string path)
        {
            string text = string.Empty;

            try
            {   // Open the text file using a stream reader.
                using (StreamReader sr = new StreamReader(path, SetAttributeFromList.enc))
                {
                    // Read the stream to a string, and write the string to the console.
                    text = sr.ReadToEnd();
                }
            }
            catch (Exception ex)
            {
                Logger.WriteExMessage2Temp(PathofLog, ex);
                MessageBox.Show("Read Log");
                return "ERROR";
            }
            return text;
        }

        static public string GetModelDirectory()
        {
            TSM.Model _model = new TSM.Model();
            ModelInfo modelinfo = _model.GetInfo();
            string modelDir = modelinfo.ModelPath;
            return modelDir;
        }

        private void bcreateList_Click(object sender, EventArgs e)
        {
            CreateListWithValues(true);
        }
        private void CreateListWithValues(bool only_with_value)
        {
            string RepAtt = tbRepAttr.Text;
            string UserAtt = tbUserAttr.Text;
            string filename = (only_with_value) ? @"\Draw_Ass.txt" : @"Draw_Ass_all.txt";
            string filepath = GetModelDirectory() + filename;
            File.Delete(filepath);
            List<TSItem> listofassm = new List<TSItem>();
            List<string> listofstring = new List<string>();
            ArrayList selobj = ModelOperations.SelectModelObj();
            IEnumerator Enum = selobj.GetEnumerator();
            while (Enum.MoveNext())
            {
                TSM.ModelObject asm = Enum.Current as TSM.ModelObject;
                if (asm != null)
                {
                    TSItem asmItem = new TSItem();
                    bool isRead = false;
                    string assPos = string.Empty;
                    string fullname = string.Empty;
                    string drwNumber = string.Empty;
                    string userdefstr = "USERDEFINED." + UserAtt;
                    isRead = asm.GetReportProperty(RepAtt, ref assPos);
                    isRead = asm.GetReportProperty(userdefstr, ref drwNumber);
                    fullname = assPos + "#" + drwNumber;
                    asmItem.ReportAttribute = assPos;
                    asmItem.UserAttribute = drwNumber;
                    switch (only_with_value)
                    {
                        case true:
                            if (drwNumber != string.Empty && !listofstring.Contains(fullname))
                                listofstring.Add(fullname);
                            break;
                        case false:
                            if (!listofstring.Contains(fullname))
                                listofstring.Add(fullname);
                            break;
                    }
                }
            }
            foreach (var item in listofstring)
            {
                WriteList2Path(filepath, item);
            }
        }

        public static void WriteList2Path(string filepath, string value)
        {
            using (StreamWriter writer = new StreamWriter(filepath, true, enc))
            {
                writer.WriteLine(value);
            }
        }

        private void button1_Click_1(object sender, EventArgs e)
        {
            CreateListWithValues(false);
        }

        public void CreateExcelList(eTypeofList TypeOfList)
        {
            string filepath = tbLocationExcel.Text;
            try
            {
                File.Delete(filepath);
            }
            catch (Exception)
            {
                MessageBox.Show("Please close file:" + "\n" + filepath, "Attention", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            List<TSItem> listofobj = null;
            listofobj = GetListofObj(TypeOfList);
            SortListofTSItem(ref listofobj);
            if (filepath.Contains(".xlsx"))
            {
                CreateExcelFile(filepath, listofobj);
            }
            if (filepath.Contains(".csv"))
            {
                CreateCSVFile(filepath, listofobj);
            }
            
        }

        private void SortListofTSItem(ref List<TSItem> listofobj)
        {
            List<TSItem> SortedList = listofobj.OrderBy(o => o.ReportAttribute).ToList();
            listofobj = SortedList;
        }

        private void CreateExcelFile(string filepath, List<TSItem> listofobj)
        {
            int i = 2;
            Excel.Application excel = new Excel.Application();
            //excel.Visible = true;
            if (excel == null)
                return;
            string sep = excel.DecimalSeparator;
            Excel.Workbook wb = excel.Workbooks.Add(Excel.XlWBATemplate.xlWBATWorksheet);
            Excel.Worksheet excelSheet = wb.Worksheets[1];
            var dd = GetRangeSeparator(excelSheet);
            excelSheet.Cells[1, 1] = RepAtt.Item1;
            excelSheet.Cells[1, 2] = UserAtt.Item1;
            foreach (var item in listofobj)
            {
                char delimeter = '.';
                char new_delimeter = ',';
                
                excelSheet.Cells[i, 1] = item.ReportAttribute;
                excelSheet.Cells[i, 2] = item.UserAttribute;
                //excelSheet.Cells[i, 2] = item.UserAttribute.Replace(new_delimeter, delimeter); 
                i++;
            }
            wb.SaveAs(filepath);
            wb.Close();
            tbMessage.Text = "The file was created.";
        }
        private void CreateCSVFile(string filepath, List<TSItem> listofobj)
        {
            WriteList2Path(filepath, RepAtt.Item1.ToString() + ';' + UserAtt.Item1.ToString());
            foreach (var item in listofobj)
            {
                if (item.UserAttribute == null) item.UserAttribute = string.Empty;

                WriteList2Path(filepath, item.ReportAttribute.ToString() + ';' + item.UserAttribute.ToString());
            }
            tbMessage.Text = "The file was created.";
        }
        private static string GetRangeSeparator(Excel.Worksheet sheet)
        {
            Excel.Application app = sheet.Application;
            string sRng = app.Union(sheet.get_Range("A1"), sheet.get_Range("A3")).AddressLocal;
            sRng = sRng.Replace("$", string.Empty);
            string sSep = sRng.Substring(sRng.IndexOf("A3") - 1, 1);
            return sSep;
        }
        private List<TSItem> GetListofObj(eTypeofList TypeOfList)
        {
            List<TSItem> listofobj = new List<TSItem>();
            List<string> listofstring = new List<string>();
            ArrayList selobj = new ArrayList();

            switch (DataFile.objectSelectorType)
            {
                case AppDataFile.eObjectSelectorType.Model:
                    selobj = ModelOperations.SelectModelObj();
                    IEnumerator Enum_Model = selobj.GetEnumerator();
                    while (Enum_Model.MoveNext())
                    {
                        TSM.ModelObject prototype = Enum_Model.Current as TSM.ModelObject;
                        GetPropforCurrentnAdd2List(prototype, TypeOfList, ref listofobj, ref listofstring);
                    }
                    break;
                case AppDataFile.eObjectSelectorType.Drawing:
                    selobj = DrawingOperations.SelectDrawingObj();
                    IEnumerator Enum_Draw = selobj.GetEnumerator();
                    while (Enum_Draw.MoveNext())
                    {
                        TSD.DatabaseObject drawprototype = Enum_Draw.Current as TSD.DatabaseObject;
                        if (drawprototype != null)
                        {
                            TSM.ModelObject prototype = ConvertFromDrawingtoModelObj(drawprototype);
                            GetPropforCurrentnAdd2List(prototype, TypeOfList, ref listofobj, ref listofstring);
                        }
                    }
                    break;
                default:
                    break;
            }
            return listofobj;
        }
        private void GetPropforCurrentnAdd2List(ModelObject prototype, eTypeofList TypeOfList, ref List<TSItem> listofobj, ref List<string> listofstring)
        {
            if (prototype != null)
            {
                TSItem _tsitem = GetTSItem(prototype);
                string fullname = string.Empty;


                fullname = _tsitem.ReportAttribute + "#" + _tsitem.UserAttribute;
                switch (TypeOfList)
                {
                    case eTypeofList.OnlyWithValues:
                        if (_tsitem.UserAttribute != null && !listofstring.Contains(fullname))
                        {
                            listofobj.Add(_tsitem);
                            listofstring.Add(fullname);
                        }
                        break;
                    case eTypeofList.Full:
                        if (!listofstring.Contains(fullname))
                        {
                            listofobj.Add(_tsitem);
                            listofstring.Add(fullname);
                        }
                        break;
                }
            }
        }
        private TSItem GetTSItem(TSM.ModelObject prototype)
        {
            TSItem _tsitem = new TSItem();
            _tsitem.ReportAttribute = GetRepAttributeValue(prototype);
            _tsitem.UserAttribute = GetUserAttributeValue(prototype);

            return _tsitem;
        }
        public TSM.Beam ConvertFromDrawingtoModelObj(TSD.DatabaseObject drawingobject)
        {
            Tekla.Structures.Model.Beam prototype = new Tekla.Structures.Model.Beam
            {
                Identifier =
                (TS.Identifier)drawingobject.GetType().GetProperty("Identifier", System.Reflection.BindingFlags.NonPublic | System.Reflection.BindingFlags.Instance).GetValue(drawingobject, null)
            };
            return prototype;
        }
        private object GetUserAttributeValue(ModelObject prototype)
        {
            object result = null;
            
            string UserAtt = SetAttributeFromList.UserAtt.Item1;
            string userdefstr = string.Empty;
            userdefstr = (cBTypeOfsecondcolumn.Checked) ? UserAtt : "USERDEFINED." + UserAtt;
            eUDAType UDAType = SetAttributeFromList.UserAtt.Item2;
            switch (UDAType)
            {
                case eUDAType.String:
                    string uda_value = string.Empty;
                    if (prototype.GetReportProperty(userdefstr, ref uda_value))
                        result = uda_value;
                    break;
                case eUDAType.Int:
                    int value_int = -1;
                    if (prototype.GetReportProperty(userdefstr, ref value_int))
                        result = value_int;
                    break;
                case eUDAType.Double:
                    double value_double = -1.0;
                    if (prototype.GetReportProperty(userdefstr, ref value_double))
                    {
                        if (userdefstr.Contains("USERDEFINED."))
                        {
                            result = value_double;
                        }
                        else
                        {
                            result = Math.Round(value_double * DataFile.Coefficient4Double, DataFile.Decimals4Double);
                        }
                    }
                    break;
            }
            return result;
        }
        private object GetRepAttributeValue(TSM.ModelObject prototype)
        {
            object result = null;
           
            string RepAtt = SetAttributeFromList.RepAtt.Item1;
            eDefineAType DAType = SetAttributeFromList.RepAtt.Item2;
            switch (DAType)
            {
                case eDefineAType.String:
                    string defineattr_value = string.Empty;
                    if (prototype.GetReportProperty(RepAtt, ref defineattr_value))
                        result = defineattr_value;
                    break;
                case eDefineAType.Int:
                    int value_int = -1;
                    if (prototype.GetReportProperty(RepAtt, ref value_int))
                        result = value_int;
                    break;
                case eDefineAType.Double:
                    double value_double = -1.0;
                    if (prototype.GetReportProperty(RepAtt, ref value_double))
                    {
                        result = Math.Round(value_double * DataFile.Coefficient4Double, DataFile.Decimals4Double);
                    }
                    break;
            }
            return result;
        }
        private void bCrtexcelList_Click(object sender, EventArgs e)
        {
            GetSettingsFromMainForm();
            tbMessage.Text = string.Empty;
            if (cBTypeOfList.Checked)
                CreateExcelList(eTypeofList.OnlyWithValues);
            else
                CreateExcelList(eTypeofList.Full);
        }

        private void bSetFromExcelList_Click(object sender, EventArgs e)
        {
            GetSettingsFromMainForm();
            tbMessage.Text = string.Empty;
            string filepath = tbLocationExcel.Text;
            try
            {
                bool readfromExcel = (filepath.Contains(".xlsx")) ? true : false;
                bool result = SetAttrInModelFromList(readfromExcel);
                if (result == true)
                {
                    tbMessage.Text = "UDAs from list already in the model!";
                }
            }
            catch (Exception ex)
            {
                Logger.WriteExMessage2Temp(PathofLog, ex);
                tbMessage.Text = @"Read  Log";
            }
        }

        private bool SetAttrInModelFromList(bool ReadFromExcel)
        {
            List<TSItem> listofassm = new List<TSItem>();
            string RepAtt = tbRepAttr.Text;
            string UserAtt = tbUserAttr.Text;
            ArrayList selobj = new ArrayList();

            listofassm = (ReadFromExcel) ? GetListofAsmFromExcelFile(): GetListofAsmFromFile();
            if (listofassm == null) return false;

            switch (DataFile.objectSelectorType)
            {
                case AppDataFile.eObjectSelectorType.Model:
                    selobj = ModelOperations.SelectModelObj();
                    IEnumerator Enum_Model = selobj.GetEnumerator();
                    while (Enum_Model.MoveNext())
                    {
                        TSM.ModelObject prototype = Enum_Model.Current as TSM.ModelObject;
                        SetValueonCurrentObj(prototype, listofassm);
                    }
                    break;
                case AppDataFile.eObjectSelectorType.Drawing:
                    selobj = DrawingOperations.SelectDrawingObj();
                    IEnumerator Enum_Draw = selobj.GetEnumerator();
                    while (Enum_Draw.MoveNext())
                    {
                        TSD.DatabaseObject drawprototype = Enum_Draw.Current as TSD.DatabaseObject;
                        if (drawprototype != null)
                        {
                            TSM.ModelObject prototype = ConvertFromDrawingtoModelObj(drawprototype);
                            SetValueonCurrentObj(prototype, listofassm);
                        }
                    }
                    break;
                default:
                    break;
            }
            _model.CommitChanges();
            return true;
        }
        private void SetValueonCurrentObj(ModelObject prototype, List<TSItem> listofassm)
        {
            if (prototype != null)
            {
                object assPos = GetRepAttributeValue(prototype);
                foreach (var tsitem in listofassm)
                {
                    if (tsitem.ReportAttribute.ToString().Equals(assPos.ToString()))
                    {
#if false //set new prefix for assemblies by excel list
                        
                            TSM.Assembly _asm = asm as TSM.Assembly;
                        _asm.AssemblyNumber.Prefix = asmitem.UserAttribute;
                        _asm.Modify();
#endif
                        SetAttributeValue(prototype, tsitem);
                    }
                }
            }
        }
        private void SetAttributeValue(ModelObject prototype, TSItem tsitem)
        {
            string UserAtt = SetAttributeFromList.UserAtt.Item1;
            eUDAType UDAType = SetAttributeFromList.UserAtt.Item2;
            switch (UDAType)
            {
                case eUDAType.String:
                    string value_string = Convert.ToString(tsitem.UserAttribute);
                    if (value_string != null)
                    prototype.SetUserProperty(UserAtt, value_string);
                    break;
                case eUDAType.Int:
                    int value_int = Int32.MinValue;
                    if (tsitem.UserAttribute == null || tsitem.UserAttribute.ToString() == string.Empty)
                    {
                        prototype.SetUserProperty(UserAtt, value_int);
                    }
                    else
                    {
                        value_int = Convert.ToInt32(tsitem.UserAttribute);
                        prototype.SetUserProperty(UserAtt, value_int);
                    }
                    break;
                case eUDAType.Double:
                    double value_double = (double)Int32.MinValue;
                    if (tsitem.UserAttribute == null || tsitem.UserAttribute.ToString() == string.Empty)
                    {
                        prototype.SetUserProperty(UserAtt, value_double);
                    }
                    else
                    {
                        value_double = CommonUtils.ConvertToDouble(tsitem.UserAttribute.ToString());
                       // value_double = Convert.ToDouble(tsitem.UserAttribute);
                        prototype.SetUserProperty(UserAtt, value_double);
                    }
                    break;
            }
        }
        private List<TSItem> GetListofAsmFromExcelFile()
        {
            List<TSItem> listofassm = new List<TSItem>();

            string filepath = tbLocationExcel.Text;

            Excel.Application excel = new Excel.Application();
            Excel.Workbook wb_for_exist_xl = excel.Workbooks.Open(filepath);
            Excel.Worksheet excelSheet = wb_for_exist_xl.ActiveSheet;

            try
            {
                int rowCount = excelSheet.UsedRange.Rows.Count;
                int i = 0;
                for (i = 2; i <= rowCount; i++)
                {
                    Excel.Range range_RepAtr = excelSheet.Cells[i, 1] as Excel.Range;
                    Excel.Range range_UserAtr = excelSheet.Cells[i, 2] as Excel.Range;
                    if (range_RepAtr.Value != null)
                    {
                        object RepAtr_Value = range_RepAtr.Value;
                        if (range_UserAtr != null)
                        {
                            object UserAtr_Value = null;
                            if (range_UserAtr.Value != null)
                                UserAtr_Value = range_UserAtr.Value;
                            TSItem asmitem = new TSItem();
                            asmitem.ReportAttribute = RepAtr_Value;
                            asmitem.UserAttribute = UserAtr_Value;
                            listofassm.Add(asmitem);
                        }
                    }
                }
                wb_for_exist_xl.Close();
            }
            catch (Exception ex)
            {
                Logger.WriteExMessage2Temp(PathofLog, ex);
                tbMessage.Text = @"Read log";
            }
 
            return listofassm;
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void bBrowse_Click(object sender, EventArgs e)
        {
            FileDialog FD = new OpenFileDialog();
            //OpenFileDialog FD = new OpenFileDialog();
            FD.CheckFileExists = false;
            FD.RestoreDirectory = true;
            FD.DefaultExt = ".xlsx";
            FD.Filter = "Excel (*.xlsx)|*.xlsx|CSV (*.csv)|*.csv|Все файлы (*.*)|*.*";

            if (FD.ShowDialog() == DialogResult.OK)
            {
                string fileToOpen = FD.FileName;
                _filepath = fileToOpen;
                tbLocationExcel.Text = fileToOpen;
            }
        }

        private void bOpenExcel_Click(object sender, EventArgs e)
        {
            tbMessage.Text = string.Empty;
            string filepath = tbLocationExcel.Text;
            try
            {
                if (filepath.Contains(".xlsx") || filepath.Contains(".xls"))
                {
                    Excel.Application excel = new Excel.Application();
                    Excel.Workbook wb_for_exist_xl = excel.Workbooks.Open(filepath);
                    excel.Visible = true;
                }
                else
                {
                    Process.Start(filepath);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("File doesn't exist:" + "\n" + filepath, "Attention", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
                Logger.WriteExMessage2Temp(PathofLog, ex);
            }
        }

        private void SetAttributeFromList_Load(object sender, EventArgs e)
        {

            string lastSetting = string.Empty;

                Microsoft.Win32.RegistryKey key = Microsoft.Win32.Registry.CurrentUser.OpenSubKey("Software\\BelEnergomash\\" + Application.ProductName, true);
                if (key != null)
                {
                    lastSetting = (string)key.GetValue("LastSetting", "");
                }
                else
                {
                    Microsoft.Win32.Registry.CurrentUser.CreateSubKey("Software\\BelEnergomash\\" + Application.ProductName);
                }

                if (!File.Exists(DataFile.filename))//then create one
                {
                    DataFile.Write();
                }
            methApplyValues();

            try
            {
                TsEvents = new TSM.Events();
                TsEvents.TeklaStructuresExit += new TSM.Events.TeklaStructuresExitDelegate(Ts_Exit);
                TsEvents.Register();
            }
            catch
            { }

        }
        //TEKLA EVENTS
        private void Ts_Exit()
        {
            Application.Exit();
        }

        private void bGetExistUDA_Click(object sender, EventArgs e)
        {
#if false
            Tekla.Structures.ModelInternal.Operation.dotStartAction("Interrupt", "MainFrame");
            if (null != workerThread)
            {
                workerThread.Abort();
                workerThread = null;
            }

            workerThread = new Thread(() => CreateUDAForm());
            workerThread.Start();
#endif
            if(cBTypeOfsecondcolumn.Checked)
            {
                CreateReportDAForm(eColumn.Second);
            }
            else
            CreateUDAForm();
        }

        private void CreateUDAForm()
        {
            try
            {
                ListofExistUDAs UDAF = new ListofExistUDAs();
                UDAF.theMainForm = this;
                UDAF.ShowDialog();
               
            }
            catch (Exception ex)
            {
                Logger.WriteExMessage2Temp(PathofLog, ex);
                tbMessage.Text = @"Read Log";
            }
        }

        private void bRepAtt_Click(object sender, EventArgs e)
        {
            CreateReportDAForm(eColumn.First);
        }

        private void CreateReportDAForm(eColumn NumberOfColumn)
        {
            try
            {
                ListofDefineAttribute DAF = new ListofDefineAttribute();
                DAF.theMainForm = this;
                DAF.NumberOfColumn = NumberOfColumn;
                DAF.ShowDialog();

            }
            catch (Exception ex)
            {
                Logger.WriteExMessage2Temp(PathofLog, ex);
                tbMessage.Text = @"Read Log";
            }
        }

        private void cBTypeOfsecondcolumn_CheckedChanged(object sender, EventArgs e)
        {
            bSetFromExcelList.Enabled = (cBTypeOfsecondcolumn.Checked) ? false : true;
        }

        private void SetAttributeFromList_FormClosed(object sender, FormClosedEventArgs e)
        {
            
        }
        private void WriteLastSettings()
        {
            methOptionsWrite(false);

            DataFile.objectSelectorType = (cBModelObj.Checked == true) ? AppDataFile.eObjectSelectorType.Model : AppDataFile.eObjectSelectorType.Drawing;
            DataFile.DA.Name = tbRepAttr.Text;
            string repatrtype = cBReportAttrDatatype.Text.ToLower();
            DataFile.DA.Type = (repatrtype == "double") ? eUDAType.Double : (repatrtype == "int") ? eUDAType.Int : eUDAType.String;
            DataFile.UDA.Name = tbUserAttr.Text;
            string udatype = cBUDADatatype.Text.ToLower();
            DataFile.UDA.Type = (udatype == "double") ? eUDAType.Double : (udatype == "int") ? eUDAType.Int : eUDAType.String; 
            DataFile.ExcelPath = tbLocationExcel.Text;
            DataFile.BothRepAttribute = cBTypeOfsecondcolumn.Checked;

            DataFile.Write();
        }
        private void methOptionsRead()
        {
            try
            {
                Microsoft.Win32.RegistryKey key = Microsoft.Win32.Registry.CurrentUser.OpenSubKey(RegeditKeyforApp, true);

                if (key != null)
                {
                    foreach (string valueName in key.GetValueNames())
                    {
                        Screen[] screens = Screen.AllScreens;
                        switch (valueName)
                        {
                            case "FormHeight":
                                this.Height = (int)key.GetValue(valueName);
                                break;
                            case "FormWidth":
                                this.Width = (int)key.GetValue(valueName);
                                break;
                            case "FormLeft":
                                this.Left = (int)key.GetValue(valueName);
                                int right = 0;
                                for (int i = 0; i < screens.Length; i++)
                                {
                                    if (right < screens[i].WorkingArea.Right)
                                    {
                                        right = screens[i].WorkingArea.Right;
                                    }
                                }
                                if (!(this.Left >= Screen.PrimaryScreen.WorkingArea.Left && this.Left <= right))
                                {
                                    this.Left = 0;
                                }
                                //if (Screen.AllScreens.Count() == 1)//then there there is only one screen, make sure the form is on it
                                //{
                                //    if (!(this.Left >= Screen.PrimaryScreen.WorkingArea.Left && this.Left <= Screen.PrimaryScreen.WorkingArea.Right - 50))
                                //    {
                                //        this.Left = 0;
                                //    }
                                //}
                                break;
                            case "FormTop":
                                this.Top = (int)key.GetValue(valueName);
                                int bottom = 0;
                                
                                for (int i = 0; i < screens.Length; i++)
                                {
                                    if (bottom < screens[i].WorkingArea.Bottom)
                                    {
                                        bottom = screens[i].WorkingArea.Bottom;
                                    }
                                }
                                if (!(this.Top >= Screen.PrimaryScreen.WorkingArea.Top && this.Top <= bottom))
                                {
                                    this.Top = 0;
                                }
                                //if (this.Top > 5000)
                                //{
                                //    this.Top = 50;
                                //}
                                //if (!(this.Top >= Screen.PrimaryScreen.WorkingArea.Top && this.Top <= Screen.PrimaryScreen.WorkingArea.Bottom))
                                //{
                                //    this.Top = 0;
                                //}
                                break;
                            case "LastSetting":
                                lastSetting = (string)key.GetValue(valueName);
                                if (lastSetting == "settings")//settings is temp value
                                {
                                    lastSetting = "";
                                }
                                break;
                            default:
                                break;
                        }
                    }
                }
                else
                {
                    methOptionsWrite(true);
                    methOptionsRead();
                }

                key = Microsoft.Win32.Registry.CurrentUser.OpenSubKey(RegeditKeyforApp, true);

                if (key != null)
                {
                    foreach (string valueName in key.GetValueNames())
                    {
                        switch (valueName)
                        {
                            case "stayOnTop":
                                this.TopMost = Convert.ToBoolean(key.GetValue(valueName));
                                break;
                            default:
                                break;
                        }
                    }
                }
                else
                {
                    methOptionsWrite(true);
                    methOptionsRead();
                }
            }
            catch (Exception e)
            {
                if (e.Message == "")
                {

                }
                else
                {
                    MessageBox.Show("There was an unexpected error in the following module:\n\n" + System.Reflection.MethodBase.GetCurrentMethod().Name + "\n\nDetails:\n" + e.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    Clipboard.SetText(e.Message);
                    methOptionsWrite(true);
                    Application.Exit();
                }
            }
        }
        private void methOptionsWrite(bool reset)
        {
            
            try
            {
                Microsoft.Win32.RegistryKey key = Microsoft.Win32.Registry.CurrentUser.CreateSubKey(RegeditKeyforApp);

                if (!reset)
                {
                    key.SetValue("FormHeight", this.Height);
                    key.SetValue("FormWidth", this.Width);
                    key.SetValue("FormLeft", this.Left);
                    key.SetValue("FormTop", this.Top);
                    if (lastSetting != "")
                    {
                        key.SetValue("LastSetting", lastSetting);
                    }
                }
                else
                {
                    key.SetValue("FormHeight", 270);
                    key.SetValue("FormWidth", 640);
                    key.SetValue("FormLeft", (Screen.PrimaryScreen.Bounds.Width / 2)-240);
                    key.SetValue("FormTop", 50);
                    key.SetValue("LastSetting", "");
                }

                key = Microsoft.Win32.Registry.CurrentUser.CreateSubKey(RegeditKeyforApp);

                if (!reset)
                {
                    key.SetValue("stayOnTop", this.TopMost);
                }
                else
                {
                    key.SetValue("stayOnTop", true);
                }
            }
            catch (Exception e)
            {
                if (e.Message == "")
                {

                }
                else
                {
                    MessageBox.Show("There was an unexpected error in the following module:\n\n" + System.Reflection.MethodBase.GetCurrentMethod().Name + "\n\nDetails:\n" + e.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    Clipboard.SetText(e.Message);
                }
            }
        }
        private void SetAttributeFromList_FormClosing(object sender, FormClosingEventArgs e)
        {
            SetAttributeFromList _theMainForm = new SetAttributeFromList();
            if (this.WindowState == FormWindowState.Minimized)
            {
                this.WindowState = FormWindowState.Normal;
            }
            WriteLastSettings();
        }

        private void SetAttributeFromList_ResizeEnd(object sender, EventArgs e)
        {
            methOptionsWrite(false);
        }

        private void cBModelObj_Click(object sender, EventArgs e)
        {
            cBModelObj.Checked = true;
            cBDrawingObj.Checked = false;
            methSetObjectSelectorType();
        }
        private void methSetObjectSelectorType()
        {
            try
            {
                if (cBModelObj.Checked)
                {
                    DataFile.objectSelectorType = AppDataFile.eObjectSelectorType.Model;
                }
                else if (cBDrawingObj.Checked)
                {
                    DataFile.objectSelectorType = AppDataFile.eObjectSelectorType.Drawing;
                }
            }
            catch (Exception e)
            {
                if (e.Message == "")
                {

                }
                else
                {
                    MessageBox.Show("There was an unexpected error in the following module:\n\n" + System.Reflection.MethodBase.GetCurrentMethod().Name + "\n\nDetails:\n" + e.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    Clipboard.SetText(e.Message);
                }
            }
        }

        private void cBModelObj_CheckedChanged(object sender, EventArgs e)
        {
            //cBModelObj.Checked = true;
            //cBDrawingObj.Checked = false;
            //methSetObjectSelectorType();
        }

        private void cBDrawingObj_CheckedChanged(object sender, EventArgs e)
        {
            //cBModelObj.Checked = false;
            //cBDrawingObj.Checked = true;
            //methSetObjectSelectorType();
        }

        private void cBDrawingObj_Click(object sender, EventArgs e)
        {
            cBModelObj.Checked = false;
            cBDrawingObj.Checked = true;
            methSetObjectSelectorType();
        }

        private void bOpenlog_Click(object sender, EventArgs e)
        {
            try
            {
                if (File.Exists(PathofLog))
                {
                    Process.Start(PathofLog);
                }
                else
                {
                    tbMessage.Text = @"Log doesn't exist";
                    //MessageBox.Show(@"Log doesn't exist");
                }
            }
            catch (Exception ex)
            {
                Logger.WriteExMessage2Temp(SetAttributeFromList.PathofLog, ex);
                MessageBox.Show("Read Log");
            }
        }
    }
}
