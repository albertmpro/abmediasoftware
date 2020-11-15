using System;
using System.Collections.Generic;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;
using System.Windows.Media;
using abmediaplatform;
using System.IO;
using static System.IO.File;
using static System.Text.Json.JsonSerializer;
using Albert.Win32;
using Albert.Win32.Controls;
using static Albert.Win32.Win32IO;
using abNoteBook.Controls;
using abmediaplatform;

namespace abNoteBook.View
{
    /// <summary>
    /// Interaction logic for StartNote.xaml
    /// </summary>
    public partial class StartNote : ABView
    {
        //Field's 
        WriterState state;

        public StartNote(TabControl _tab)
        {
            InitializeComponent();

            Init();

            SetupTab("StartNote", false, _tab);

            //Focus on the code editor 
            txtCode.Focus();

          
        }

     

        public void Init()
        {
            //Load Settings if Avliable 
             if(File.Exists("C:/AMB/Settings/abnotebooksettings.json"))
            {
          
                //Load Settings 
                //Load Text  from format 
                txtCode.Text = VM.Settings.StartNote;
                txtCode.FontFamily = new FontFamily(VM.Settings.FontFamily);
                txtWriter.FontFamily = new FontFamily(VM.Settings.FontFamily);
                txtCode.FontSize = VM.Settings.FontSize;
                slFontSize.Value = VM.Settings.FontSize;
    
            }
            
            // Dialog Strings 
           
            var exporttitle = "Export Text File";
            var importtitle = "Import Text File ";
            var filter = VM.FilterTuple().TextFiles;

            //Set the Writer State 
            State = WriterState.Code;



            //Export Command 
            AddCommand(DesktopCommands.Export, (sender, e) =>
            {
                State = WriterState.Code;

                SaveDialogTask(exporttitle, filter, (s, i) =>
                  {
                      var ext = i.Extension;

                      switch(ext)
                      {
                          case ".abtxt": //Convert to the ab Text forma t
                              var (filename, info) = VM.SaveText_Tuple(txtCode.Text, txtCode.FontFamily.Source, txtCode.FontSize, s.FileName);
                              break;
                          default: // Save regular text formats
                              var (filename2, info2) = VM.SaveText_Tuple(txtCode.Text, s.FileName);
                              break;
                      }
                  
                  });
     
            });
            //Import Command  
            AddCommand(DesktopCommands.Import, (sender, e) =>
             {
                 OpenDialogTask(importtitle, filter, (o, i) =>
                 {
                     var ext = i.Extension; 

                     switch(ext)
                     {
                         case ".abtxt":
                             var (filename, info, abtxt) = VM.LoadText_Tuple(o.FileName);
                             txtCode.Text = abtxt.Text;
                             txtCode.FontFamily = new FontFamily(abtxt.FontFamily);
                             txtWriter.FontFamily = new FontFamily(abtxt.FontFamily);
                             txtCode.FontSize = abtxt.FontSize;
                             txtWriter.FontSize = abtxt.FontSize;
                             break;
           
                         default:
                             var (filename2, info2, txt) = VM.LoadPlainText_Tuple(o.FileName);
                             //Load Text 
                             txtCode.Text = txt;
                             break;
                     }
                 });
             });
      



        }

        private void slFontSize_ValueChanged(object sender, RoutedPropertyChangedEventArgs<double> e)
        {
            //On SlideValue Lamba 
            MediaCv.OnSlideValue(e.NewValue, (v) =>
             {
                 txtCode.FontSize = v;
                 txtWriter.FontSize = v;
             
             });
        }


        void WriterState_Click(object sender, RoutedEventArgs e)
        {
            var opt = sender as OptionButton;

            switch (opt.Tag)
            {
                case "Code":
                    State = WriterState.Code;
                    break;
                case "Writer":
                    State = WriterState.Writer;
                    break;
            }
        }

        public WriterState State
        {
            get => state;
            set
            {
                state = value;

                switch (value)
                {
                    case WriterState.Code:
                        txtCode.Visibility = Visibility.Visible;
                        txtWriter.Visibility = Visibility.Collapsed;
                       
                        if (txtWriter.Text != null && txtCode.Visibility == Visibility.Collapsed)
                        {
                            txtCode.Text = txtWriter.Text;
                        }
                       
                     
                        break;

                    case WriterState.Writer:
                        txtCode.Visibility = Visibility.Collapsed;
                        txtWriter.Visibility = Visibility.Visible;
                        if (txtCode.Text != null && txtCode.Visibility == Visibility.Collapsed) 
                        {
                            txtWriter.Text = txtCode.Text;
                        }
                       

                        break;
                }

            }
        }

        private void cmbFontType_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            var item = (NoteFont)cmbFontType.SelectedItem;
            txtCode.FontFamily = item.FontFamily;
            txtWriter.FontFamily = item.FontFamily;
        }
    }
}
