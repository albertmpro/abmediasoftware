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
        /// NewXmlDocTuple create Xml Document fast 
        /// </summary>
        /// <param name="_root"></param>
        /// <param name="_document"></param>
        /// <returns></returns>
        public static (XElement Root, XElement Document) NewXmlDocTuple(string _root, string _document)
        {
            //Define the root xml element 
            var root = new XElement(_root);
            //Define the document xml eleemnt
            var document = new XElement(_document);

            //Add document to root element 
            root.Add(document);

            //Return the Values 
            return (root, document);

        }

        #region Converter's
        
        /// <summary>
        /// Convert Xml to Double  
        /// </summary>
        /// <param name="_element">XElement</param>
        /// <returns></returns>
        public static double ToXmlDouble(XElement _element)
        {
            try
            {
                return ToDouble(_element.Value);
            }
            catch
            {
                MessageBox.Show($"{_element.Value} not a double");
                return 0;
            }
        }
        /// <summary>
        /// Convert Xml to Double 
        /// </summary>
        /// <param name="_element"></param>
        /// <returns></returns>
        public static double ToXmlDouble(XAttribute _element)
        {
            try
            {
                return ToDouble(_element.Value);
            }
            catch
            {
                MessageBox.Show($"{_element.Value} not a double");
                return 0;
            }
        }
        /// <summary>
        /// Convert Xml Value to a Byte
        /// </summary>
        /// <param name="_element"></param>
        /// <returns></returns>
        public static byte ToXmlByte(XElement _element)
        {
            try
            {
                return ToByte(_element.Value);
            }
            catch
            {
                MessageBox.Show($"{_element.Value} is not a byte");
                return 0;
            }
        }
        /// <summary>
        /// Convert Xml to a Byte
        /// </summary>
        /// <param name="_element"></param>
        /// <returns></returns>
        public static byte ToXmlByte(XAttribute _element)
        {
            try
            {
                return ToByte(_element.Value);
            }
            catch
            {
                MessageBox.Show($"{_element.Value} is not a byte");
                return 0;
            }
        }


        /// <summary>
        /// Convert Xml to Decimal  
        /// </summary>
        /// <param name="_element"></param>
        /// <returns></returns>
        public static decimal ToXmlDecimal(XElement _element)
        {
            try
            {
                return ToDecimal(_element.Value);
            }
            catch
            {
                MessageBox.Show($"{_element.Value} is not a decimal");
                return 0;
            }
        }
        /// <summary>
        /// Convert Xml to Decimal 
        /// </summary>
        /// <param name="_element"></param>
        /// <returns></returns>
        public static decimal ToXmlDecimal(XAttribute _element)
        {
            try
            {
                return ToDecimal(_element.Value);
            }
            catch
            {
                MessageBox.Show($"{_element.Value} is not a decimal");
                return 0;
            }
        }
        /// <summary>
        /// Convert to Xml to Int32
        /// </summary>
        /// <param name="_element"></param>
        /// <returns></returns>
        public static int ToXmlInt32(XElement _element)
        {
            try
            {
                return ToInt32(_element.Value);
            }
            catch
            {
                MessageBox.Show($"{_element.Value} is not a Int32");
                return 0;
            }
        }
        /// <summary>
        /// Convert to Xml to Int32
        /// </summary>
        /// <param name="_element"></param>
        /// <returns></returns>
        public static int ToXmlInt32(XAttribute _element)
        {
            try
            {
                return ToInt32(_element.Value);
            }
            catch
            {
                MessageBox.Show($"{_element.Value} is not a Int32");
                return 0;
            }
        }



        #endregion





    }




}
