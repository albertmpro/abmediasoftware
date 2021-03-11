using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows;
using System.Windows.Input;
using System.IO;
using static System.Text.Json.JsonSerializer;
using System.Windows.Controls.Primitives;
using Albert;
using abmediaplatform;
using static Albert.Win32.MediaCv;
using System.Windows.Media;
using ABNotePad.Code;

namespace ABNotePad
{
    public class PadViewModel : PlatformViewModel
    {


        #region JSON Method's 

        /// <summary>
        ///  Convert Obj to Json string 
        /// </summary>
        /// <param name="_obj"></param>
        /// <returns></returns>
        public string ConvertToJson(object _obj)
        {
            return Serialize(_obj);
        }
       



        #endregion

        #region Pre-Made List 

        public VMList<PadItem> ArtBoardList => new VMList<PadItem>
        {
            new PadItem("ArtBoardLeft"), 
            new PadItem("ArtBoardRight"),
            new PadItem("PaintSplitLeft"),
            new PadItem("PaintSplitRight"),
            new PadItem("Preview")
        };

        

        #endregion

        #region Public Propeties 
        /// <summary>
        /// Get or set the Status Bar of the Application 
        /// </summary>
        public StatusBar VMStatusBar { get; set; }

        public string StartNote { get; set; }

        /// <summary>
        /// Grabs a list of Draw Canvas sizes 
        /// </summary>
        public VMList<PadDrawSize> DrawSizes { get; set; } = new VMList<PadDrawSize>();

        /// <summary>
        /// Get and Collect Colors to Draw with 
        /// </summary>
        public VMList<PadColor> UsedColors { get; set; } = new VMList<PadColor>();

        /// <summary>
        /// Get and Collect Notes you want to save 
        /// </summary>
        public VMList<string> Notes { get; set; } = new VMList<string>();
        #endregion

    }
}
