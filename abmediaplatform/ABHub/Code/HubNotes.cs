using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Albert;
using Albert.Win32;
namespace ABHub.Code
{
    /// <summary>
    /// Settiings for the Application 
    /// </summary>
    public record HubNotes : JsonRecord
    {
        /// <summary>
        /// Get the Script Note that has been taken 
        /// </summary>
        public string ScriptNote { get; init; }
        /// <summary>
        /// Get the Writer that has been taken 
        /// </summary>
        public string WriterNote { get; init; }

        public string FontLabNote { get; init; }

        /// <summary>
        /// Get the Notes that have been taken 
        /// </summary>
        public VMList<string> Notes { get; init; }
        /// <summary>
        /// Get the Saved Fonts of the Application 
        /// </summary>
        public VMList<HubFont> Fonts { get; init; }
        /// <summary>
        /// Get the Save Files of the APplication 
        /// </summary>
        public VMList<string> SavedFiles { get; init; }
        /// <summary>
        /// Get the Logs of the Application  
        /// </summary>
        public VMList<VMLogInfo> Logs { get; init; }

        
        /// <summary>
        /// Deconstruct your settings 
        /// </summary>
        /// <param name="scriptnote"></param>
        /// <param name="writernote"></param>
        /// <param name="notes"></param>
        /// <param name="fonts"></param>
        /// <param name="savedFiles"></param>
        /// <param name="logs"></param>
        public void Deconstruct(out string scriptnote, out string writernote, out VMList<string> notes,out VMList<HubFont> fonts, out VMList<string> savedFiles, out VMList<VMLogInfo> logs,out string flnotes)
        {
            scriptnote = ScriptNote;
            writernote = WriterNote;
            notes = Notes;
            fonts = Fonts;
            savedFiles = SavedFiles;
            logs = Logs;
            flnotes = FontLabNote;
        }



    }
}
