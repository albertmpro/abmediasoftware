using System;
using System.Collections.Generic;
using System.Text;
using System.Xml.Linq;
using Albert;
using System.IO;
using static Albert.Win32.XmlUtility;
using static Albert.Win32.Win32IO;
namespace Albert.Win32
{
    /// <summary>
    /// Base Class for saving settings to an xml file on a local Win32 Alpplcation 
    /// </summary>
    public abstract class ABSettingsBase : Notify
    {
        //Field's 
        XElement  document;

        #region Events 
        /// <summary>
        /// Save Method Preform before you save your settings 
        /// </summary>
        public event Action OnSaved;
        /// <summary>
        /// Load metthod after you load your xml settings
        /// </summary>
        public event Action OnLoaded;
        #endregion

        #region Public Properties 


        /// <summary>
        /// Get or Seet the Xml Document 
        /// </summary>
        public XElement Document
        {
            get
            {
                return document;
            }

            set
            {
                document = value;
                OnPropertyChanged("Document");
            }
        }

        #endregion


        #region Method's 
        /// <summary>
        /// Load Settings from Local Path 
        /// </summary>
        /// <param name="_fileName"></param>
        /// <returns></returns>
        public XElement LoadSettings(string _fileName)
        {
            Document =  LoadXmlFromLocalFolder(_fileName);
            OnLoaded.Invoke();
            return Document;
        }
        /// <summary>
        /// Save Settings to local Path 
        /// </summary>
        /// <param name="_firsttag"></param>
        /// <param name="_fileName"></param>
        public void SaveSettings(string _fileName)
        {
           if(Document != null)
            {
                OnSaved.Invoke();
                //Save the xml to a local file 
                SaveXmlToLocalPath(_fileName, Document);
            }
            



        }

        #endregion

    }
}
