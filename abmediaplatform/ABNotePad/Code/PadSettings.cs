using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Albert;
using Albert.Win32;
using System.Windows;
using System.Windows.Media;

namespace ABNotePad.Code
{
    /// <summary>
    /// A record thate stores the settings of this application 
    /// </summary>
    public record PadSettings : JsonRecord
    {

        public PadSettings()
        {
            Format = "PadSettings";
            Description = "PadSettings saves the WindowState, StartInfo,Youtube Informatiion, Youtube Tags, and Notes";
            Author = "Albert M. Byrd";
        }


        /// <summary>
        /// Gets the WIndow State of the Application 
        /// </summary>
        public WindowState WindowState { get; init; }
        /// <summary>
        /// Save Your youtube subscribtion INformation here 
        /// </summary>
        public string YoutubeInformation { get; init; }

        public string YoutubeScript { get; init; }

        /// <summary>
        /// Save youre Youtube tags here 
        /// </summary>
        /// 
        public string YoutubeTags { get; init; }

        /// <summary>
        /// Gets the Main Start Note 
        /// </summary>
        public string StartNote { get; init; }
        /// <summary>
        /// Get a group of notes that have been written  
        /// </summary>
        public VMList<string> Notes { get; init; }
        /// <summary>
        /// Get used Colors 
        /// </summary>
        public VMList<PadColor> UsedColors { get; init; }

        public VMList<PadDrawSize> DrawSizes { get; init; }
        
        #region Deconstruct Method 

        public void Deconstruct(out WindowState winstate, out string startnote, out string ytscript, out string ytInfo,out string ytTags, out VMList<string> notes,out VMList<PadColor> ucolors,out VMList<PadDrawSize> drawSizes)
        {
            winstate = WindowState;
            startnote = StartNote;
            ytscript = YoutubeScript;
            ytInfo = YoutubeInformation;
            ytTags = YoutubeTags;
            notes = Notes;
            ucolors = UsedColors;
            drawSizes = DrawSizes;
        }
        #endregion

    }


}



