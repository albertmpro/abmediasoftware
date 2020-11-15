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
using static Albert.Win32.Win32IO;
using static System.Text.Json.JsonSerializer;
using abNoteBook.Controls;
using abmediaplatform;
using System.IO;
using static System.IO.File;
using Albert.Win32;

namespace abNoteBook.View
{
    /// <summary>
    /// Interaction logic for ArtboardView.xaml
    /// </summary>
    public partial class ArtboardView : ABView, ITabInitClose
    {
        public ArtboardView(TabControl _tab)
        {
            InitializeComponent();

            
            Init();

            SetupTab($"ArtBoard{Count++}", _tab, Close); 
        }

        public void Close()
        {
            RemoveTab();
        }

        public void Init()
        {
            var savetitle = "Save ArtBoard";
            var opentitle = "Open ArtBoard";
            var filter = VM.FilterTuple().Artboard;

            //Import Command 
            AddCommand(DesktopCommands.Import, (sender, e) =>
             {
                 OpenDialogTask(opentitle, filter, (o, i) =>
                 {
                  


                    
                 
                 });
             
             });

            //Save Command 
            AddCommand(ApplicationCommands.Save, (sender, e) =>
             {
                 SaveDialogTask(savetitle, filter, (s, i) =>
                   {
                       

                   
                   });
             
             });
        }

        void opt_Click(object sender,RoutedEventArgs e)
        {

        }
    }
}
