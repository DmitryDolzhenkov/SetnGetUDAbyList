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
using System.IO;
using System.Xml;
using System.Globalization;

namespace SetnGetAttribute
{
    public class AppDataFile
    {
        public enum eObjectSelectorType { Model, Drawing }

        string appName = Application.ExecutablePath;
        TSM.Model myModel = new TSM.Model();

        string _appTitle = Application.ProductName;
        string _settingsfile = Application.LocalUserAppDataPath + '\\' + "LastSettings.xml";
        public string filename { get { return _settingsfile; } set { this._settingsfile = value; } }
        public UDA DA { get; set; }
        public UDA UDA { get; set; }
        public double Coefficient4Double { get; set; }
        public int Decimals4Double { get; set; }
        public bool BothRepAttribute { get; set; }
        public string ExcelPath { get; set; }
        public eObjectSelectorType objectSelectorType { get; set; }

        AppDataFile _dataFile;
        public AppDataFile dataFile { get { return _dataFile; } set { this._dataFile = value; } }


        public AppDataFile()
        {
            Reset();
        }
        public AppDataFile(AppDataFile dataFile)
        {
            Reset();
            _dataFile = dataFile;
        }
        public void Reset()
        {
            objectSelectorType = eObjectSelectorType.Model;
            DA = new UDA();
            DA.Name = "ASSEMBLY_POS";
            DA.Type = eUDAType.String;
            UDA = new UDA();
            UDA.Name = "sap_cover_1";
            UDA.Type = eUDAType.Double;
            Coefficient4Double = 1;
            Decimals4Double = 2;
            BothRepAttribute = false;
            string filename = @"\Attribute_Value.xlsx";
            string _excelfilepath = SetAttributeFromList.GetModelDirectory() + filename;
            ExcelPath = _excelfilepath;
        }
        public void Read()
        {
            try
            {
                Reset();
                XmlTextReader reader = null;
                reader = new XmlTextReader(_settingsfile);
                reader.MoveToContent();
                string elementName = "";
                string branchName = "";
                if (reader.NodeType == XmlNodeType.Element)
                {
                    branchName = reader.Name;
                    while (reader.Read())
                    {
                        if (reader.NodeType == XmlNodeType.Element)
                        {
                            elementName = reader.Name;
                            if (elementName == "appSettings")
                            {
                                branchName = "appSettings";
                            }
                            else if (elementName == "attributeRep")
                            {
                                branchName = "attributeRep";
                            }
                            else if (elementName == "attributeUDA")
                            {
                                branchName = "attributeUDA";
                            }
                        }
                        else
                        {
                            //Reports - defined attributes
                            if ((reader.NodeType == XmlNodeType.Text) && branchName == "attributeRep" && (reader.HasValue))
                            {
                                switch (elementName)
                                {
                                    case "name":
                                        DA.Name = reader.Value;
                                        break;
                                    case "type":
                                        DA.Type = (eUDAType)Enum.Parse(typeof(eUDAType), reader.Value);
                                        break;
                                }
                            }
                            //UDA - user defined attributes
                            if ((reader.NodeType == XmlNodeType.Text) && branchName == "attributeUDA" && (reader.HasValue))
                            {
                                switch (elementName)
                                {
                                    case "name":
                                        UDA.Name = reader.Value;
                                        break;
                                    case "type":
                                        UDA.Type = (eUDAType)Enum.Parse(typeof(eUDAType), reader.Value);
                                        break;
                                }
                            }
                            //BASIC APP SETTINGS ARE READ HERE
                            else if ((reader.NodeType == XmlNodeType.Text) && branchName == "appSettings" && (reader.HasValue))
                            {
                                switch (elementName)
                                {
                                    case "appTitle":
                                        _appTitle = reader.Value;
                                        break;
                                    case "coefficient4Double":
                                        Coefficient4Double = CommonUtils.ConvertToDouble(reader.Value);
                                        break;
                                    case "decimals4Double":
                                        Decimals4Double = Int32.Parse(reader.Value);
                                        break;
                                    case "bothRepAttribute":
                                        BothRepAttribute = Convert.ToBoolean(reader.Value);
                                        break;
                                    case "excelPath":
                                        ExcelPath = reader.Value;
                                        break;
                                    case "objectSelectorType":
                                        objectSelectorType = (eObjectSelectorType)Enum.Parse(typeof(eObjectSelectorType), reader.Value);
                                        break;
                                }
                            }
                        }
                    }
                    reader.Close();
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
        public void Write()
        {
            try
            {
                XmlWriterSettings settings = new XmlWriterSettings();
                settings.Indent = true;
                settings.IndentChars = "    ";

                using (XmlWriter writer = XmlWriter.Create(_settingsfile, settings))
                {

                    writer.WriteStartDocument();
                    writer.WriteStartElement("appSettings");

                    writer.WriteElementString("appTitle", _appTitle);
                    writer.WriteElementString("coefficient4Double", Coefficient4Double.ToString());
                    writer.WriteElementString("decimals4Double", Decimals4Double.ToString());
                    writer.WriteElementString("bothRepAttribute", BothRepAttribute.ToString());
                    writer.WriteElementString("excelPath", ExcelPath);
                    writer.WriteElementString("objectSelectorType", objectSelectorType.ToString());

                    writer.WriteStartElement("attributeRep");
                    writer.WriteElementString("name", DA.Name);
                    writer.WriteElementString("type", DA.Type.ToString());
                    writer.WriteEndElement();
                    writer.WriteStartElement("attributeUDA");
                    writer.WriteElementString("name", UDA.Name);
                    writer.WriteElementString("type", UDA.Type.ToString());
                    writer.WriteEndElement();

                    writer.WriteEndElement();
                    writer.WriteEndDocument();
                }
            }
            catch
            {
            }
        }
       
    }
}
