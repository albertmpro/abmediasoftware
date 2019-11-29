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
using Albert.Win32;
using tk = Xceed.Wpf.Toolkit;
using static Albert.Win32.Win32IO;

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



        public override void OnLogic()
        {
            //New Command  
            AddCommand(ApplicationCommands.New, (sender, e) =>
             {
                 var msg = tk.MessageBox.Show("Do you want to create a new Artboard?");

                 switch(msg)
                 {
                     case MessageBoxResult.Yes:
                         //Clear the DrawCanvas 
                         drawCanvas.Strokes.Clear();
                         drawCanvas.Children.Clear();
                         
                         //Send a Message to the Application 
                         VM.Message("You have created a new Artboard.",true);
                         break;
                     default:
                         //Do nothing 
                         break;
                 }

             });

            //Open Command  
            AddCommand(ApplicationCommands.Open, (sender, e) =>
            {
                //Dialog Tuple 
                (string title, string filter) = DialogInfoTuple("Open Artboard", VM.FilterTuple().ArtBoard);

                //Open Diloag Lamba Method 
                OpenDialogTask(title, filter, (s, i) =>
                  {
                      //Load Artbaord Tuple 
                      (string fileName, FileInfo info) = VM.LoadArtBoardTuple(s.FileName, drawCanvas);
                      //Set FileLocation 
                      FileLocation = fileName;
                      //Set TabItem header 
                      TabItem.Header = info.Name;
                      //Send a MEssage to the Application  f
                      VM.Message($"You have loaded the {info.Name} file from the {info.DirectoryName} directory.", true);

                  });



            });

            //Save Command  
            AddCommand(ApplicationCommands.Save, (sender, e) =>
            {
                if (FileLocation! !=  null)
                {
                    //Save Artboard Tuple 
                    (string filename, FileInfo info) = VM.SaveArtBoardTuple(drawCanvas, FileLocation);
                    //Set TabItem header 
                    TabItem.Header = info.Name;

                    //Send a Message to the Application 
                    VM.Message($"You have saved the {info.Name} in the {info.DirectoryName} directory", true);
                }
                else if(FileLocation == null)
                {
                    //Create a Dialog Tuple 
                    (string title, string filter) = DialogInfoTuple("Save Artboard", VM.FilterTuple().ArtBoard);
                    //Save Dialog Lamba Method 
                    SaveDialogTask(title, filter, (s, i) =>
                    {
                        //Save Artbaord Tuple 
                        (string filename, FileInfo info) = VM.SaveArtBoardTuple(drawCanvas, s.FileName);
                        //Set FIle Location 
                        FileLocation = filename;
                        //Set TabItem header 
                        TabItem.Header = info.Name;
                        //Send Message to Application 
                        VM.Message($"You have saved the {info.Name} in the {info.DirectoryName} directory", true);

                    });



                }

            });

            //Save As Command  
            AddCommand(DesktopCommands.SaveAs, (sender, e) =>
            {
                //Create a Dialog Tuple 
                (string title, string filter) = DialogInfoTuple("Save Artboard", VM.FilterTuple().ArtBoard);
                //Save Dialog Lamba Method 
                SaveDialogTask(title, filter, (s,i) =>
                {
                    //Save Artbaord Tuple 
                    (string filename, FileInfo info) = VM.SaveArtBoardTuple(drawCanvas, s.FileName);
                    //Set FIle Location 
                    FileLocation = filename;
                    //Set TabItem header 
                    TabItem.Header = info.Name;
                    //Send Message to Application 
                    VM.Message($"You have saved the {info.Name} in the {info.DirectoryName} directory", true);



                });

            });

            //Expot Command 
            AddCommand(DesktopCommands.Export, (sender, e) =>
             {
                 //Create a Dialog Tuple 
                 (string title, string filter) = DialogInfoTuple("Save Artboard", VM.FilterTuple().ArtBoard);
                 //Save Dialog Lamba Method 
                 SaveDialogTask(title, filter, (s, i) =>
                 {
                     //Export Artbaord Tuple 
                     (string filename, FileInfo info) = VM.ExportPngTuple(drawCanvas, s.FileName);
                  
                     //Send Message to Application 
                     VM.Message($"You have saved the {info.Name} in the {info.DirectoryName} directory", true);



                 });

             });

        }

        /// <summary>
        /// On the TabItem being Closed method 
        /// </summary>
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
