using System;
using System.Collections.Generic;
using System.Text;

namespace Albert
{
    /// <summary>
    /// Default Interface for a ViewModel for MVVM
    /// </summary>
    public interface IViewModel
    {
        /// <summary>
        /// Event to Display the Message 
        /// </summary>
        event Action<string> OnMessage;
        /// <summary>
        /// Method used to call displaying the message 
        /// </summary>
        /// <param name="_msg"></param>
        void Message(string _msg, bool _isAddedToLog);

        /// <summary>
        /// Event fires when you run the Log Method 
        /// </summary>
        event Action<int> OnLog;
        /// <summary>
        /// Method used to call your Log of functions 
        /// </summary>
        void GetLog(int _numofItems);
        /// <summary>
        /// A list of Message sent to the Applicaton 
        /// </summary>
        VMList<string> Log { get; set; }
        /// <summary>
        /// Get's or Sets the amount of data you want the log to have
        /// </summary>
        public int LogCount { get; set; }
    }
}
