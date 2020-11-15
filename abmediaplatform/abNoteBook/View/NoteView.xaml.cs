using System;
using System.Collections.Generic;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using static System.IO.File;
using static System.Text.Json.JsonSerializer;
using abNoteBook.Controls;
using System.IO;
using Albert.Win32;
using Albert.Win32.Controls;
using static Albert.Win32.Win32IO;
using abmediaplatform;
using abNoteBook.Controls;
using abmediaplatform;
namespace abNoteBook.View
{
    /// <summary>
    /// Text Editor of the Application 
    /// </summary>
    public partial class NoteView : ABView, ITabInitClose
    {
        WriterState state;
        public NoteView(TabControl _tab)
        {
            InitializeComponent();
            SetupTab($"Note{Count++}", _tab, Close);
            Init();
            txtCode.Focus();
        }

        public NoteView(TabControl _tab, FileInfo _info)
        {
            InitializeComponent();
            var name = _info.Name;
            var ext = _info.Extension;
            var file = ReadAllText(_info.FullName);

            //Setup tab file 
            SetupTab(name, _tab, Close);
            //File Location 
            FileLocation = _info.FullName;
            Init();

            switch(ext)
            {
                case ".abtxt":
                    //Convet Json to ABTextFormat 
                    var format = Deserialize<ABTextFormat>(file);
                    txtCode.Text = format.Text;
                    txtCode.FontFamily = new FontFamily(format.FontFamily);
                    txtCode.FontSize = format.FontSize;
                    break;
                default: // Default Text File 
                    
                    txtCode.Text = file;
                    break;
            }

            VM.OpenFileAndLog(_info);
            VM.CurrentFileNames.Add(_info.FullName);

            txtCode.Focus();

        }



        public void Close()
        {
            //Dialog Lamba 
            TabDialog.Show("Closing Tab", "Do you want to close this Tab?", "Close", "Cancel", () =>
                { 
                    //Remove Tab 
                    RemoveTab(); 
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

        public void Init()
        {
           
            
            var savetitle = "Save Text File";
            var saveastitle = "Save Text File As";
            var filter = VM.FilterTuple().TextFiles;

            //Set the Writer State 
            State = WriterState.Code;

            //Save Command 
            AddCommand(ApplicationCommands.Save, (sender, e) =>
            {
                State = WriterState.Code;
                if (FileLocation != null)
                {
                    //Create the FileINfo 
                    var info = new FileInfo(FileLocation);
                    var ext1 = info.Extension;

                    switch (ext1)
                    {
                        default: // When saved as any other format 

                            var (FileName, Info) = VM.SaveText_Tuple(txtCode.Text, FileLocation);

                            break;
                        case ".abtxt": // Default format 

                            var abformat = VM.SaveText_Tuple(txtCode.Text, txtCode.FontFamily.Source, txtCode.FontSize, FileLocation);

                            break;
                    }

                    // Take care of Business 
                    var i = new FileInfo(FileLocation);
                    SetupFileAndTab(i);
                    VM.SavedFileAndLog(i);
                    VM.CurrentFileNames.Add(FileLocation);



                }
                else if (FileLocation == null)
                {
                    SaveDialogTask(saveastitle, filter, (s, i) =>
                    {
                        var ext = i.Extension;


                        switch (ext)
                        {
                            default: // When saved as any other format 

                                (string FileName, FileInfo Info) plain = VM.SaveText_Tuple(txtCode.Text, s.FileName);

                                break;
                            case ".abtxt": // Default format 

                                var (FileName, Info) = VM.SaveText_Tuple(txtCode.Text, txtCode.FontFamily.Source, txtCode.FontSize, s.FileName);

                                break;
                        }


                        // Take care of Business 
                        SetupFileAndTab(i);
                        VM.SavedFileAndLog(i);
                        VM.CurrentFileNames.Add(s.FileName);

                    });


                }
            });
            //Save As Command 
            AddCommand(DesktopCommands.SaveAs, (sender, e) =>
            {
                State = WriterState.Writer;
                State = WriterState.Code;
                SaveDialogTask(saveastitle, filter, (s, i) =>
                {
                    var ext = i.Extension;


                    switch (ext)
                    {
                        default: // When saved as any other format 

                            var plain = VM.SaveText_Tuple(txtCode.Text, s.FileName);

                            break;
                        case ".abtxt": // Default format 

                            var abformat = VM.SaveText_Tuple(txtCode.Text, txtCode.FontFamily.Source, txtCode.FontSize, s.FileName);

                            break;
                    }


                    // Take care of Business 
                    SetupFileAndTab(i);
                    VM.SavedFileAndLog(i);
                    VM.CurrentFileNames.Add(s.FileName);

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
