using System;
using System.Collections.Generic;
using System.Text;
using System.IO;

namespace Albert.Win32
{
    /// <summary>
    /// Class is designed to be ViewModel Information that you want to keep track of while running your application 
    /// </summary>
    /// 
    public class VMLogInfo: Notify 
    {
        //Field's 
        string information;
        FileInfo fileinfo;
        /// <summary>
        /// Default Constuctor  
        /// </summary>
        public VMLogInfo()
        {
            // Do nothing for now
        }
        /// <summary>
        /// Second Counstructor  
        /// </summary>
        /// <param name="_Info"></param>
        public VMLogInfo(string _Info)
        {
            Information = _Info;
        }
        /// <summary>
        /// Third Consturctor 
        /// </summary>
        /// <param name="_Info">Log Information </param>
        /// <param name="_fileinfo">File Info </param>
        public VMLogInfo(string _Info, FileInfo _fileinfo)
        {
            Information = _Info;
            Info = _fileinfo;
        }
        /// <summary>
        /// Forth Contrucgtor 
        /// </summary>
        /// <param name="_Info">Log Information </param>
        /// <param name="_fileName">The FileName</param>
        public VMLogInfo(string _Info,string _fileName)
        {
            Information = _Info;
            Info = new FileInfo(_fileName);
        }

        public override string ToString()
        {
            if(Info != null)
            {
                return $"Log: {Information}\nDate: {DateTime.Now}\nFile: {Info.Name}";
            }
            else 
            {
                return $"Log: {Information}\nDate: {DateTime.Now}";
            }
        }




        /// <summary>
        /// Get or set the Information 
        /// </summary>
        public string Information
        {
            get => information;
            set { information = value; OnPropertyChanged("Information"); }
        }
        /// <summary>
        /// Get or Set the File Info if any 
        /// </summary>
        public FileInfo Info
        {
            get => fileinfo;
            set { fileinfo = value; OnPropertyChanged("Info"); }
        }
    }
}
