using System;
using System.Collections.Generic;
using System.Text;
using System.IO;
using System.Configuration;
using System.Xml.Linq;
using static Albert.Win32.MediaCv;
using static System.Convert;
using static Albert.Core;
using static Albert.Win32.Win32IO;
using System.Windows;
using System.Windows.Media;

namespace Albert.Win32
{
    public enum NopeError
    {
        Nope, Nothing
    }
    /// <summary>
    /// Utilities for dealing with xml documents 
    /// </summary>
    public static class XmlUtility
    {

        /// <summary>
        /// Tuple to Create an Xml Document 
        /// </summary>
        /// <param name="_filetag">Top Tag Name</param>
        /// <param name="_maintag">Document Tab Name</param>
        /// <returns></returns>
        public static (XElement Xml, XElement Document)CreateXmlDocument(string _filetag,string _maintag)
        {
            //Create the core xml 
            var xml = new XElement(_filetag);
            //Create the document you want to define 
            var document = new XElement(_maintag);
            //Add document to xml  file 
            xml.Add(document);
            return (xml, document);

        }
           
        public static string GetLocalFile(string _fileName)
        {
            var appData = Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData);
            return Path.Combine(appData, _fileName);
        }
        /// <summary>
        /// Method to Grab local xml file 
        /// </summary>
        /// <param name="_name"></param>
        /// <returns></returns>
        public static XElement LoadXmlFromLocalFolder(string _name)
        {
            XElement xml;
            var file = GetLocalFile(_name);
            if (File.Exists(file))
            {
                xml = XElement.Load(file);
                return xml;
            }
            else
            {
                xml = new XElement("Nope", "You loaded nothing");
                MessageBox.Show("Nope, you loaded nothing ");
                return xml;

            }

        }
        /// <summary>
        /// Save Xml to a Local Folder of an Application 
        /// </summary>
        /// <param name="_name">Name </param>
        /// <param name="_xmlDoc">Xml Document you want to save</param>
        public static void SaveXmlToLocalPath(string _name, XElement _xmlDoc)
        {
            if (_xmlDoc != null)
            {
                var file = GetLocalFile(_name);
                //Save Local file 
                _xmlDoc.Save(file);
            }
        }

        /// <summary>
        /// Method to get a Double from an Xml Value 
        /// </summary>
        /// <param name="_Value"></param>
        /// <returns></returns>
        public static double GetDoubleFromXml(string _Value)
        {
            try
            {
                var mydouble = ToDouble(_Value);
                return mydouble;
            }
            catch
            {
                MessageBox.Show("Value was not a double, you get 0.0");
                return 0.0;
            }
        }

        /// <summary>
        /// Method to get an Int32 from an zXml value 
        /// </summary>
        /// <param name="_Value"></param>
        /// <returns></returns>
        public static int GetInt32FromXml(string _Value)
        {
            try
            {
                var myint = ToInt32(_Value);
                return myint;
            }
            catch
            {
                MessageBox.Show("Value was not a int, You get 0");
                return 0;
            }
        }
        public static decimal GetDecimalFromXml(string _Value)
        {
            try
            {
                var mydecimal = ToDecimal(_Value);
                return mydecimal;
            }
            catch
            {
                MessageBox.Show("Value was not a decimal,you get 0.0");
                return 0.0m;
            }
        }
        /// <summary>
        /// Convert Xml Value to Color
        /// </summary>
        /// <param name="_Value"></param>
        /// <returns></returns>
        public static Color GetColorFromXml(string _Value)
        {
            try
            {
                var myColor = HexColor(_Value);
                return myColor;
            }
            catch
            {
                MessageBox.Show("Value was not a color,you get Black");
                return HexColor("#ff000000");
            }
        }


        /// <summary>
        /// Get a Enum Type from a Xml Value 
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="_value"></param>
        /// <returns></returns>
        public static T GetENumFroXml<T>(string _value)
        {
            return ConvertEnum<T>(_value);
        }

    }






}
