using abArt.Controls;
using System;
using System.Collections.Generic;
using System.IO;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using tk = Xceed.Wpf.Toolkit;

namespace abArt.View
{
    /// <summary>
    /// Interaction logic for ArtBoardView.xaml
    /// </summary>
    public partial class ArtBoardView : ArtView
    {
        #region Field's 

        #endregion

        #region Constructor's 
        /// <summary>
        /// Default Constructor 
        /// </summary>
        /// <param name="_tab"></param>
        public ArtBoardView(TabControl _tab)
        {
            InitializeComponent();

            SetupTab("Artboard{Count++}", _tab, OnTabClose);
        }
        /// <summary>
        /// Load Constructor 
        /// </summary>
        /// <param name="_tab"></param>
        /// <param name="_filename"></param>
        public ArtBoardView(TabControl _tab, string _fileName)
        {
            InitializeComponent();

       
            //Load the Document via Tuple 
            (string name, FileInfo info) = VM.LoadArtBoardTuple(_fileName, drawCanvas);

            //Setup the Tab 
            SetupTabAndLoadFile(_tab, info, OnTabClose);
           

        }

        public override void OnTabClose()
        {
            var msg = tk.MessageBox.Show("Do you want to close this tab?", "Closing Tab", MessageBoxButton.YesNo);

            switch(msg)
            {
                case MessageBoxResult.Yes:
                    TabItem.RemoveTab();
                    break;
                default:
                    // Do nothing 
                    break;
            }
        }




        #endregion



        #region Method's 




        #endregion
    }
}
