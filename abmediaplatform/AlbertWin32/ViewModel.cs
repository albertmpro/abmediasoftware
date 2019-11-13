using System;
using System.Diagnostics;

namespace Albert.Win32
{
	/// <summary>
	/// Base ViewModel for Wpf APplications
	/// </summary>
    public abstract class ViewModel: ABSettingsBase, IViewModel
    {

        #region Field's 
        VMList<string> logs;
        int logcount;
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
                Log?.Add(_msg);
            }
            else if(_isAddedToLog == false)
            {
                //Do Nothing 
            }
            //Run the OnMEssage Event 
            OnMessage?.Invoke(_msg);
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
        /// <summary>
        /// Get or set the list of things you hav e done in your applcation 
        /// </summary>
        public VMList<string> Log
        {
            get { return logs; }
            set { logs = value; OnPropertyChanged("LOg"); }
        }
        /// <summary>
        /// Get or set the Count of things you can save in your Applcation 
        /// </summary>
        public int LogCount
        {
            get { return logcount; }
            set { logcount = value; OnPropertyChanged("LogCount"); }
        }

        #endregion


    }
}
