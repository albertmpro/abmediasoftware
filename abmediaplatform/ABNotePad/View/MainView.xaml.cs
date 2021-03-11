using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;
using Albert.Win32;
using System.IO;
using ABNotePad.Code;
using ABNotePad.Code.Controls;
using Albert;
using Albert.Win32.Controls;

using static Albert.Win32.Win32IO;
using static System.IO.File;
using static System.Text.Json.JsonSerializer;
namespace ABNotePad.View
{
    /// <summary>
    /// Interaction logic for MainView.xaml
    /// </summary>
    public partial class MainView : PadShell
    {
        //Field's 
        StartNote startPad;
        
        public MainView()
        {
            InitializeComponent();

            //VMInit 
            VMInit();
        }

        void VMInit()
        {
            //Field's 
            string openTitle = "Open File";
            string filter = "All Fiels(.)|*.*";
            string settingsfile = StringFlieName("settings.json", Directory.GetCurrentDirectory());
            VM.VMTab = tab;
            VM.VMStatusBar = statusBar;
            
            //Set the StartPad 
            startPad = new StartNote(tab);

            

            //Load Settings  
            if (File.Exists(settingsfile))
            {
                string json2 = ReadAllText(settingsfile);
                PadSettings mysettings = Deserialize<PadSettings>(json2);

                //Deconstruct into variables 
                (WindowState winState, string startnote,string ytScript, string ytInfo, string ytTags, VMList<string> notes,VMList<PadColor> usedColors, VMList<PadDrawSize> drawSize) = mysettings;
                
                //Set your Settings 
                WindowState = winState;
                startPad.txtCode.Text = startnote;
                startPad.txtScript.Text = ytScript;
                startPad.txtInfo.Text = ytInfo;
                startPad.txtTags.Text = ytTags;
                
     
                // Fill your Lists out 
                VM.Notes = notes;
                VM.UsedColors = usedColors;
                VM.DrawSizes = drawSize;

                //Load Listbox's  
                //startPad.notesTaken.lstNotesTaken.ItemsSource = VM.Notes;
                //startPad.artBoards.lstArtBoard.ItemsSource = VM.DrawSizes;
                //startPad.usedColors.lstColor.ItemsSource = VM.UsedColors;





            }

            //New Command 
            AddCommand(ApplicationCommands.New, (sender, e) =>
             {
                 tab.SelectedIndex = 0;
                 startPad.gridNew.Visibility = Visibility.Visible;
             
             });
            //Open Command 
            AddCommand(ApplicationCommands.Open, (sender, e) =>
            {
                OpenDialogTask(openTitle, filter, (o, i) =>
                {
                    string extension = i.Extension;
                    //foreach method 
                    void forEachFile(Action<FileInfo> _method)
                    {
                        foreach (var myfile in o.FileNames)
                        {
                            
                            //Get the file info 
                            var info = new FileInfo(myfile);
                            try
                            {

                                //Do the method 
                                _method?.Invoke(info);
                            }
                            catch
                            {
                                _method?.Invoke(info);
                            }

                        }

                    }

                    switch (extension)
                    {
                        default:
                            forEachFile((i) =>
                            {
                                var note = new NoteView(VM.VMTab, i);
                            });
                            break;
                            case ".abart":

                            forEachFile((i) =>
                            {
                                var artbaord = new DrawView(VM.VMTab, i);
                            
                            });

                            break;
                        case ".abtxt":
                            forEachFile((i) =>
                            {
                                var abnote = new NoteView(VM.VMTab, i);
                            });
                            break;
                        case ".mp4":
                            forEachFile((i) =>
                            {
                                var player = new MediaPlayerView(VM.VMTab, i);

                            });
                            break;
                        case ".png":


                            var png = new ImageView(VM.VMTab, i);





                            break;
                        case ".jpeg":

                            var jpeg = new ImageView(VM.VMTab, i);



                            break;

                        case ".jpg":


                            var jpg = new ImageView(VM.VMTab, i);


                            break;

                        case ".tfff":
                            forEachFile((i) =>
                            {
                                var tiff = new ImageView(VM.VMTab, i);

                            });
                            break;

                    }

                });
            });

            //StartView  
            AddCommand(DesktopCommands.StartView, (sender, e) =>
            {
                //Notes Taken 
                NotesTakenView notes = new NotesTakenView(VM.VMTab);
                

            });;
            // About COmmand 
            AddCommand(DesktopCommands.About, (sender, e) =>
             {
                 //Help 
                 HelpView about = new HelpView(VM.VMTab);
             
             });

            AddCommand(DesktopCommands.LogInfo, (sender, e) =>
            {
                LogView log = new LogView(VM.VMTab);

            });


            //Quick Message Method 
            void On_Message(string _str)
            {
                tbStatus.Text = _str;
                MediaCv.NotifyHide(tbStatus, 10);
            }



            

            //On Closed Method  
            Closed += (sender, e) =>
            {
                //Grab the Settings 
                PadSettings settings = new PadSettings
                {
                    StartNote = startPad.txtCode.Text,
                    YoutubeScript = startPad.txtScript.Text,
                    YoutubeInformation = startPad.txtInfo.Text,
                    YoutubeTags = startPad.txtTags.Text,
                    Notes = VM.Notes,
                    UsedColors = VM.UsedColors,
                    DrawSizes = VM.DrawSizes,
                    WindowState = WindowState
                };
                //Convert to Json 
                string json = Serialize(settings);
                
                //Save File 
                WriteAllText(settingsfile, json);
            };


            //Link ON_Message 
            VM.OnMessage += On_Message;
            VM.Message("Welcome to ABNotePad 1.0",true);
        }

        void Status_Click(object sender,ref RoutedEventArgs e)
        {
            PushButton push = sender as PushButton;

            switch(push.Tag)
            {
                case "Notes":

                    break;
                case "Tube":

                    break;
            }

               
        }


    }
}
