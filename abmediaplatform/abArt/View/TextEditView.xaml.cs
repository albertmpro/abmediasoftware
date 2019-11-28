using System;
using System.Collections.Generic;
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
using Albert.Win32;
using abArt.Controls;
namespace abArt.View
{
    /// <summary>
    /// Interaction logic for TextEditView.xaml
    /// </summary>
    public partial class TextEditView : ArtView
    {
        #region Field's 
        private TextEditorMode state;

        #endregion

        #region Constructor 
        /// <summary>
        /// Default Constructor 
        /// </summary>
        /// <param name="_tab">Takes a TabContorl</param>
        public TextEditView(TabControl _tab)
        {
            InitializeComponent();
            //Setup your tab 
            SetupTab($"TextFile{Count++}", _tab, tabClose);
             
            //Run the Logic 
            Logic();
        }

        void tabClose()
        {

        }

        void Logic()
        {
            //New Commands 
            AddCommand(ApplicationCommands.New, (sender, e) =>
             { 
             
             });

            //Open Commands 
            AddCommand(ApplicationCommands.Open, (sender, e) =>
            {

            });


            //Save Commands 
            AddCommand(ApplicationCommands.Save, (sender, e) =>
            {

            });

            //Save As Commands 
            AddCommand(DesktopCommands.SaveAs, (sender, e) =>
            {

            });

            //Import Commands 
            AddCommand(DesktopCommands.Import, (sender, e) =>
            {

            });

            //Export Commands 
            AddCommand(DesktopCommands.Export, (sender, e) =>
            {

            });



        }

        #endregion

        #region Method's 

        #endregion

        #region Public Properties 


        /// <summary>
        /// Get or set TextEditorState
        /// </summary>
        public TextEditorMode State 
        { 
            get => state;
            set 
            { 
                state = value; 

                switch(value)
                {
                    case TextEditorMode.Code: //Code Visiable 
                        //Show txtCode 
                        txtCode.Visibility = Visibility.Visible;
                        txtWriter.Visibility = Visibility.Collapsed;
                        //Grab the text if any 
                        var ctext = txtWriter?.Text;
                        txtCode.Text = ctext;

                        break;

                    case TextEditorMode.Writer: //Writer Visable 
                        //Show the txtWriter 
                        txtCode.Visibility = Visibility.Collapsed;
                        txtWriter.Visibility = Visibility.Visible;
                        //Grab the Text if any
                        var wtext = txtCode?.Text;
                        txtWriter.Text = wtext;


                        break;
                }
            }
        
        }

        #endregion

    }
}
