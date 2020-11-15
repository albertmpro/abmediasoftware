using System;
using System.Collections.Generic;
using System.Text;
using System.Windows;

using Albert;
namespace abmediaplatform
{
    /// <summary>
    /// NoteBook Settings Format 
    /// </summary>
    public class NBSettingsFormat: JsonFormater
    {
        public NBSettingsFormat()
        {
            Format = "Notebook Settings";
            Description = "Basic Notebook Settings";
            Author = "Albert M. Byrd";
            //Base Font Values 
            FontFamily = "Segoe Print";
            FontSize = 20;
        }
        /// <summary>
        /// Get or set the Start Note 
        /// </summary>
        public string StartNote { get; set; }
        /// <summary>
        /// Get or set Current font family bueing used 
        /// </summary>
        public string FontFamily { get; set; }
        /// <summary>
        /// Get or set FontSize 
        /// </summary>
        public double FontSize { get; set; }
        /// <summary>
        /// Get or set The last WIndow State the user has used 
        /// </summary>
        public WindowState WindowState { get; set;  }
        /// <summary>

    }
}
