using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using TS = Tekla.Structures;
using TSM = Tekla.Structures.Model;
using TSMUI = Tekla.Structures.Model.UI;
using System.Collections;
using System.IO;
using System.Diagnostics;

namespace SetnGetAttribute
{
    public enum eColumn
    {
        First,
        Second
    }
    public partial class ListofDefineAttribute : Form
    {
        TSM.Model _model = new TSM.Model();
        SetAttributeFromList _theMainForm = new SetAttributeFromList();
        public SetAttributeFromList theMainForm { get; set; }
        public eColumn NumberOfColumn { get; set; }

        public ListofDefineAttribute()
        {
            TopMost = true;
            InitializeComponent();
            
        }
        private void ListofDefineAttribute_Load(object sender, EventArgs e)
        {
            //methSizeToFitColumns();
            this.Left = theMainForm.Left;
            this.Top = theMainForm.Bottom;
            GetList();
            methSizeToFitColumns();
        }

        private void GetList()
        {
            List<UDA> UDAList = UDA.GetExternalAttributes();
            FillDataGridView(UDAList);
        }


        private void bOpenFullList_Click(object sender, EventArgs e)
        {
            OpenListwithGlobalAttr();
        }

        private void OpenListwithGlobalAttr()
        {
            string result = string.Empty;
            string _filepathRDA = string.Empty;
            TS.TeklaStructuresSettings.GetAdvancedOption("XSDATADIR", ref result);
            
            // opens the folder in explorer
            _filepathRDA = result + @"nt\TplEd\settings\contentattributes_global.lst";
            if (!File.Exists(_filepathRDA))
            {
                _filepathRDA = result + @"nt\bin\TplEd\settings\contentattributes_global.lst";
            }
            try
            {
                Process.Start("notepad.exe", _filepathRDA);
                //Process.Start(_filepathRDA);
            }
            catch (Exception ex)
            {
                Logger.WriteExMessage2Temp(SetAttributeFromList.PathofLog, ex);
                MessageBox.Show("Read Log");
            }
        }

        public void methSizeToFitColumns()
        {
            try
            {
                int columnWidths = 0;
                int columnCount = 0;

                columnCount = dGV_Main.Columns.Count;

                for (int i = 0; i < columnCount; i++)
                {
                    if (dGV_Main.Columns[i].Visible)
                    {
                        columnWidths += dGV_Main.Columns[i].Width;
                    }
                }

                this.Width = columnWidths + dGV_Main.RowHeadersWidth + 100;

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
        private void CopytoMainForm()
        {
            string value = string.Empty;
            foreach (DataGridViewCell oneCell in dGV_Main.SelectedCells)
            {
                if (oneCell.Selected)
                {
                    int i = oneCell.RowIndex;
                    value = dGV_Main.Rows[i].Cells[0].Value.ToString();
                    if (NumberOfColumn == eColumn.First)
                    theMainForm.tbRepAttr.Text = value;
                    else
                        theMainForm.tbUserAttr.Text = value;
                    
                        value = dGV_Main.Rows[i].Cells[1].Value.ToString();
                    if (NumberOfColumn == eColumn.First)
                        theMainForm.cBReportAttrDatatype.Text = value;
                    else
                        theMainForm.cBUDADatatype.Text = value;

                }
            }
        }

        private void bCopyStr2MainForm_Click(object sender, EventArgs e)
        {
            try
            {
                CopytoMainForm();
            }
            catch (Exception ex)
            {
                Logger.WriteExMessage2Temp(SetAttributeFromList.PathofLog, ex);
                MessageBox.Show("Read Log");
            }
        }
        public void FillDataGridView(List<UDA> UDAList)
        {
            RemoveRows();

            int i = UDAList.Count;
            dGV_Main.ReadOnly = false;
            int j = 0;
            if (i > 1)
                dGV_Main.Rows.Add(i - 1);

            foreach (var item in UDAList)
            {
                dGV_Main.Rows[j].Cells[0].Value = item.Name;
                dGV_Main.Rows[j].Cells[1].Value = item.Type;
                j++;
            }
        }
        private void RemoveRows()
        {
            dGV_Main.SelectAll();
            foreach (DataGridViewRow row in dGV_Main.SelectedRows)
            {
                if (!row.IsNewRow)
                    dGV_Main.Rows.Remove(row);
            }
        }

        private void bOpenorCreateAttrList_Click(object sender, EventArgs e)
        {
            OpenPreloadedAttributes();
            GetList();
        }

        private void OpenPreloadedAttributes()
        {
            string path = SetAttributeFromList.GetModelDirectory() + @"\ListOfAdditionalAttributes.txt";
            if (!File.Exists(path))
                CreateFileWithPreloadAttr(path);
            
            try
            {
                Process.Start(path);
            }
            catch (Exception ex)
            {
                Logger.WriteExMessage2Temp(SetAttributeFromList.PathofLog, ex);
                MessageBox.Show("Read Log");
            }
        }

        private void CreateFileWithPreloadAttr(string path)
        {
            List<string> listoftemplatestrings = new List<string>()
            {
                @"// This file contains global attributes which are defined in C:\TeklaStructures\2016(version)\nt\TplEd\settings\contentattributes_global.lst",
                @"// ",
                @"// The columns are",
                @"// ",
                @"// 1. Attribute name (maximum of 63 characters. Use only letters, numbers, dots and underlines)",
                @"//",
                @"// 2. Data type (double, string, int)",
                @"// FLOAT = double, CHARACTER = string , INTEGER = int",
                @"//",
                @"//Format of string: Name$Datatype",
                @"//",
                @"//Name   Separator Datatype",
                "NUMBER$int",
                "AREA_PROJECTION_GXY_NET$double",
                "ASSEMBLY_POS$string",
                "GUID$string",
                "ID$int",
                "PART_POS$string"
            };

            foreach (var item in listoftemplatestrings)
            {
                WriteList2Path(path, item);
            }
        }
        public static void WriteList2Path(string filepath, string value)
        {
            using (StreamWriter writer = new StreamWriter(filepath, true, SetAttributeFromList.enc))
            {
                writer.WriteLine(value);
            }
        }

        private void bRefresh_Click(object sender, EventArgs e)
        {
            GetList();
        }
        public void SettingsForDouble()
        {
            string path = @"C:\temp\SettingsforDouble.txt";
            if (!File.Exists(path))
                CreateFileWithSettings(path);

            try
            {
                string fulllist = UDA.ReadTextFile(path);
                List<string> parseattributes = UDA.Listofstring(fulllist);
                tbKoef.Text = parseattributes[0];
                nUpDownDecimals.Value = 0;
            }
            catch (Exception ex)
            {
                Logger.WriteExMessage2Temp(SetAttributeFromList.PathofLog, ex);
                MessageBox.Show("Read Log");
            }
        }

        private void CreateFileWithSettings(string path)
        {
            List<string> listoftemplatesettings = new List<string>()
            {
                @"1",
                @"2"
            };

            foreach (var item in listoftemplatesettings)
            {
                WriteList2Path(path, item);
            }
        }

        private void ListofDefineAttribute_Shown(object sender, EventArgs e)
        {
            tbKoef.Text = theMainForm.DataFile.Coefficient4Double.ToString();
            nUpDownDecimals.Value = theMainForm.DataFile.Decimals4Double;
        }

        private void ListofDefineAttribute_FormClosed(object sender, FormClosedEventArgs e)
        {
            theMainForm.DataFile.Coefficient4Double = CommonUtils.ConvertToDouble(tbKoef.Text);
            theMainForm.DataFile.Decimals4Double = Int32.Parse(nUpDownDecimals.Value.ToString());
        }
    }
}
