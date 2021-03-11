using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Albert;
using Albert.Win32;
using Albert.Win32.Controls;
using abmediaplatform;
namespace ABHub.Code
{
    /// <summary>
    /// Default ViewModel 
    /// </summary>
    public class HubViewModel : PlatformViewModel
    {
        #region Private Field's 
        string ytScript, ytInfo, ytTags,ytTopComment,scriptNote,writerNote;
        VMList<string> notes = new VMList<string>();
        VMList<HubFont> fonts = new VMList<HubFont>();
        #endregion

        #region Constructor 
        public HubViewModel()
        {
            notes = new VMList<string>();
        }
        #endregion


        #region Pre-Made List 

        public VMList<HubItem> ArtBoardList => new VMList<HubItem>
        {
            new HubItem("ArtBoardLeft"),
            new HubItem("ArtBoardRight"),
            new HubItem("PaintSplitLeft"),
            new HubItem("PaintSplitRight"),
            new HubItem("Preview")
        };



        #endregion


        #region Public Properties 

        public string WriterNote
        {
            get { return writerNote; }
            set { writerNote = value; OnPropertyChanged("WriterNote"); }
        }

        public string ScriptNote
        {
            get { return scriptNote; }
            set { scriptNote = value; OnPropertyChanged("ScriptNote"); }
        }


        /// <summary>
        /// Grabs a list of Draw Canvas sizes 
        /// </summary>
        public VMList<HubDrawSize> DrawSizes { get; set; } = new VMList<HubDrawSize>();

        /// <summary>
        /// Get and Collect Colors to Draw with 
        /// </summary>
        public VMList<HubColor> UsedColors { get; set; } = new VMList<HubColor>();



        public VMList<string> Notes
        {
            get { return notes; }
            set { notes = value; OnPropertyChanged("Notes"); }
        }

        public VMList<HubFont> Fonts
        {
            get { return fonts; }
            set { fonts = value; OnPropertyChanged("Fonts"); }
        }

        /// <summary>
        /// Get or set Youtube Script for a video  
        /// </summary>
        public string YTScript
        {
            get { return ytScript; }
            set { ytScript = value; OnPropertyChanged("YTScript"); }
        }
        /// <summary>
        /// Get or set Youtube Description  
        /// </summary>
        public string YTDescription 
        {
            get { return ytInfo; }
            set { ytInfo = value; OnPropertyChanged("YTDescription"); }
        }
        public string YTTags
        {
            get { return ytTags; }
            set { ytTags = value; OnPropertyChanged("YTTags"); }
        }
        public string YTTopComments
        {
            get { return ytTopComment; }
            set { ytTopComment = value; OnPropertyChanged("YTTopComments"); }
        }

        #endregion 
    }
}
