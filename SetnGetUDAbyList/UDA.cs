using System;
using System.Text;
using System.IO;
using System.Collections;
using System.ComponentModel;
using System.Collections.Generic;
using System.Windows.Forms;
using TSMUI = Tekla.Structures.Model.UI;
using Tekla.Structures.Model.Operations;

using TSM = Tekla.Structures.Model;

using Tekla.Structures.Model;
using System.Runtime.InteropServices;
using System.Globalization;
using System.Linq;

namespace SetnGetAttribute
{
    public enum eUDAType
    {
        String = 0,
        Int = 1,
        Double = 2
    }
    public enum eDefineAType
    {
        String = 0,
        Int = 1,
        Double = 2
    }
    public class UDA
    {
        public static List<string> listOfExceptionalUDA;
        public static List<UDA> listOfExternalAttributes;

        public string Name { get; set; }
        public string Value { get; set; }
        public eUDAType Type { get; set; }

        public UDA()
        {
        }
        public string UDAToString()
        {
            string value = string.Empty;
            value = Name + "$" + Value;
            return value;
        }
        public static List<UDA> GetUDAList(TSM.ModelObject Prototype)
        {
            List<UDA> _udaList = new List<UDA>();
            AddUDA(ref _udaList, Prototype);
            return _udaList;
        }
        private static void AddUDA(ref List<UDA> _udaList, ModelObject Prototype)
        {
            AddUDAbyType(ref _udaList, Prototype, eUDAType.String);
            AddUDAbyType(ref _udaList, Prototype, eUDAType.Int);
            AddUDAbyType(ref _udaList, Prototype, eUDAType.Double);
        }
        private static void AddUDAbyType(ref List<UDA> _udaList, ModelObject Prototype, eUDAType Type)
        {
            Hashtable ht = new Hashtable();
            switch (Type)
            {
                case eUDAType.String:
                    Add2MainList(Prototype.GetStringUserProperties(ref ht), Type, ref _udaList, ht);
                    break;
                case eUDAType.Int:
                    Add2MainList(Prototype.GetIntegerUserProperties(ref ht), Type, ref _udaList, ht);
                    break;
                case eUDAType.Double:
                    Add2MainList(Prototype.GetDoubleUserProperties(ref ht), Type, ref _udaList, ht);
                    break;
                default:
                    break;
            }
        }
        private static void AddAdditionalAttributes(ref List<UDA> _udaList, ModelObject Prototype)
        {
            AddAdditionalAttributesbyType(ref _udaList, Prototype, eUDAType.String);
            AddAdditionalAttributesbyType(ref _udaList, Prototype, eUDAType.Int);
            AddAdditionalAttributesbyType(ref _udaList, Prototype, eUDAType.Double);
        }
        private static void AddAdditionalAttributesbyType(ref List<UDA> _udaList, ModelObject Prototype, eUDAType Type)
        {
            Hashtable ht = new Hashtable();
            ArrayList prop = NamesofProperties(Type);
            switch (Type)
            {
                case eUDAType.String:
                    Add2MainList(Prototype.GetStringReportProperties(prop, ref ht), Type, ref _udaList, ht);
                    break;
                case eUDAType.Int:
                    Add2MainList(Prototype.GetIntegerReportProperties(prop, ref ht), Type, ref _udaList, ht);
                    break;
                case eUDAType.Double:
                    Add2MainList(Prototype.GetDoubleReportProperties(prop, ref ht), Type, ref _udaList, ht);
                    break;
                default:
                    break;
            }
        }
        private static void Add2MainList(bool getproperties, eUDAType Type, ref List<UDA> _udaList, Hashtable ht)
        {
            List<UDA> temp_list = GetListofUDAwithType(Type, ht);
            AddList2List(ref _udaList, temp_list);
        }
        private static ArrayList NamesofProperties(eUDAType Type)
        {
            ArrayList prop = new ArrayList();
            switch (Type)
            {
                case eUDAType.String:
                    foreach (var item in listOfExternalAttributes)
                    {
                        if (item.Type == eUDAType.String)
                            prop.Add(item.Name);
                    }
                    break;
                case eUDAType.Int:
                    foreach (var item in listOfExternalAttributes)
                    {
                        if (item.Type == eUDAType.Int)
                            prop.Add(item.Name);
                    }
                    break;
                case eUDAType.Double:
                    foreach (var item in listOfExternalAttributes)
                    {
                        if (item.Type == eUDAType.Double)
                            prop.Add(item.Name);
                    }
                    break;
                default:
                    break;
            }

            return prop;
        }
        private static void AddList2List(ref List<UDA> _udaList, List<UDA> string_uda)
        {
            foreach (var uda_item in string_uda)
            {
                _udaList.Add(uda_item);
            }
        }
        private static List<UDA> GetListofUDAwithType(eUDAType UDAType, Hashtable ht)
        {
            List<UDA> _udaList = new List<UDA>();
            foreach (DictionaryEntry item in ht)
            {
                UDA UDAItem = new UDA();
                UDAItem.Name = item.Key.ToString();
                UDAItem.Value = item.Value.ToString();
                UDAItem.Type = UDAType;
                if (listOfExceptionalUDA != null && listOfExceptionalUDA.Count > 0) 
                {
                    if (!listOfExceptionalUDA.Contains(UDAItem.Name))
                    {
                        _udaList.Add(UDAItem);
                    }
                }
                else
                _udaList.Add(UDAItem);
            }
            return _udaList;
        }
        public static string GetStringFromUDAList(List<UDA> UDAList)
        {
            string value = string.Empty;
            char delimeter = '$';

            if (UDAList == null)
                return null;

            foreach (var uda in UDAList)
            {
                value = value + uda.UDAToString() + delimeter;
            }
            return value;
        }
        public static string ReadTextFile(string path)
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
                Logger.WriteExMessage2Temp(SetAttributeFromList.PathofLog, ex);
                MessageBox.Show(@"Read Log");
            }
            return text;
        }
        public static List<string> ListOfExceptionalUDA()
        {
            string path = @"\\zmk-wrk07\sapr_image\ts\utils\ListofExceptionUDA.txt";
            string fulllist = ReadTextFile(path);
            List<string> parseattributes = Listofstring(fulllist);

            return parseattributes;
        }
        public static List<UDA> GetExternalAttributes()
        {
            List<UDA> listextermalAtt = new List<UDA>();
            string path = SetAttributeFromList.GetModelDirectory() + @"\ListOfAdditionalAttributes.txt";
            string fulllist = ReadTextFile(path);
            List<string> parseattributes = Listofstring(fulllist);
            try
            {
                listextermalAtt = GetListOfExtAtt(parseattributes);
            }
            catch (Exception ex)
            {
                Logger.WriteExMessage2Temp(SetAttributeFromList.PathofLog, ex);
                MessageBox.Show(@"Read Log");
            }
            return listextermalAtt;
        }
        private static List<UDA> GetListOfExtAtt(List<string> parseattributes)
        {
            List<UDA> listextermalAtt = new List<UDA>();
            foreach (var item in parseattributes)
            {
                UDA udaitem = new UDA();
                List<string> attributes = new List<string>();
                attributes = item.Split('$').ToList();
                if (attributes.Count > 1)
                { 
                udaitem.Name = attributes[0];
                udaitem.Type = (attributes[1] == "int")? eUDAType.Int : (attributes[1] == "double") ? eUDAType.Double: eUDAType.String;
                listextermalAtt.Add(udaitem);
                }
            }
            return listextermalAtt;
        }
        public static List<string> Listofstring(string fulllist)
        {
            List<string> attributes = new List<string>();
            List<string> parseattributes = new List<string>();
            attributes = fulllist.Split('\n').ToList();
            foreach (var item in attributes)
            {
                string new_name = item.TrimEnd('\r');
                if(!new_name.Contains(@"//"))
                parseattributes.Add(new_name);
            }
            return parseattributes;
        }
    }
}
