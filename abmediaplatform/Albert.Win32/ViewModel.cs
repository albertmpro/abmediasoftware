using System;
using System.Diagnostics;
using System.IO;
using System.Xml.Linq;
using static System.Convert;
using Albert;
using static Albert.Win32.MediaCv;
using static Albert.Win32.Win32IO;
using System.Windows.Controls;

namespace Albert.Win32
{
	/// <summary>
	/// Base ViewModel for Wpf APplications
	/// </summary>
    public abstract class ViewModel: Notify
    {
        #region Field's 
        VMList<VMLogInfo> logs = new VMList<VMLogInfo>();
        TabControl tab;
       
        
        #endregion


        #region Events 
        /// <summary>
        /// This event is use to create how the Applicaton displays the message.
        /// </summary>
        public event Action<string> OnMessage;
        /// <summary>
        /// This event is used to show the Log of your application 
        /// </summary>
        public event Action<int> OnLog;
        #endregion

        #region Tuple's 



        /// <summary>
        /// Declare Dialog Titles in one method 
        /// </summary>
        /// <param name="_open"></param>
        /// <param name="_save"></param>
        /// <param name="_saveas"></param>
        /// <returns></returns>
        public (string Open, string Save, string SaveAs) DialogTitleTuple(string _open, string _save, string _saveas)
        {
            return (_open, _save, _saveas);
        }
        /// <summary>
        /// Declare Dialog Titles in one method 
        /// </summary>
        /// <param name="_open"></param>
        /// <param name="_save"></param>
        /// <param name="_saveas"></param>
        /// <param name="_export"></param>
        /// <returns></returns>
        public (string Open, string Save, string SaveAs, string Export) DialogTitleTuple(string _open, string _save, string _saveas, string _export)
        {
            return (_open, _save, _saveas, _export);
        }

        #endregion 


        #region Method's 
        /// <summary>
        /// Method allows the ViewModel to run other .exe on the system 
        /// </summary>
        /// <param name="exeFile">File path of the .exe file</param>
        public static void RunExeFile(string exeFile)
        {
            Process p = new Process();
            p.StartInfo.FileName = exeFile;
            p.Start();
        }
        /// <summary>
        /// Displays a Message to the Aplicaton 
        /// </summary>
        public void Message(string _msg,bool _isAddedToLog)
        {
            if(_isAddedToLog == true)
            {
                Log?.Add(new VMLogInfo(_msg));
            }
          
            //Run the OnMEssage Event 
            OnMessage?.Invoke(_msg);
        }
        /// <summary>
        /// F
        /// </summary>
        /// <param name="_msg"></param>
        /// <param name="_info"></param>
        public void Message(string _msg,FileInfo _info)
        {
            //Log Message and File Info 
            Log?.Add(new VMLogInfo(_msg, _info));
            
            //On Message event 
            OnMessage?.Invoke(_msg);
        }


        /// <summary>
        /// Log saving your document
        /// </summary>
        /// <param name="_fileName"></param>
        /// <param name="_directory"></param>
        public void SavedFileAndLog(FileInfo _info)
        {
            Message($"You have saved {_info.Name} file to the {_info.DirectoryName} directory.", _info);
        }
        /// <summary>
        /// Send a Message after you open a document 
        /// </summary>
        /// <param name="_info">FileInfo</param>
        public void OpenFileAndLog(FileInfo _info)
        {
            Message($"You have opened {_info.Name} file from the {_info.DirectoryName} directory.", _info);
        }

        public void ExportFileAndLog(FileInfo _info)
        {
            Message($"You have exprted  {_info.Name} file to the {_info.DirectoryName} directory.", _info);
        }

        /// <summary>
        /// Method is used to get the Log of the Applcation 
        /// </summary>
        public void GetLog(int _numofItems)
        {
            //Run the OnLog Event 
            OnLog?.Invoke(_numofItems);
        }
        #endregion


        #region Public Properties 

        public TabControl VMTab
        {
            get => tab;
            set { tab = value; OnPropertyChanged("VMTab"); }
        }



        /// <summary>
        /// Get or set the list of things you hav e done in your applcation 
        /// </summary>
        public VMList<VMLogInfo> Log
        {
            get => logs;
            set { logs = value; OnPropertyChanged("Log"); }
        }
        /// <summary>
        /// Get or set the Count of things you can save in your Applcation 
        /// </summary>
      

        #endregion


    }
}
