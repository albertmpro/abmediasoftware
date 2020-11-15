using System;
using System.Text.Json;
using System.Windows.Input;
using static System.Text.Json.JsonSerializer;
using Albert.Win32;
using System.IO;
using static System.IO.File;
using static Albert.Win32.Win32IO;
using abNoteBook.Controls;
using abmediaplatform;
namespace abNoteBook.View
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainView : ABShell
    {
        //Feild's 
        StartNote start;

        public MainView()
        {
            InitializeComponent();

            //INit VM 
            InitVM();

            VM.Message("Welcome to abNoteBook 1.0", true);


        }
        /// <summary>
        /// Init View Model
        /// </summary>
        void InitVM()
        {
            //Set the VM TAB 
            VM.VMTab = tab;

            //Set the My Directory 
            VM.CurrentDirectory = new DirectoryInfo("C:/AMB/Settings");
            //Not the above won't work if your testing this off GitHubb 
            // Use a diffrent path or Directory.GetCurrentDirectories()

  
            WindowState = VM.Settings.WindowState;


            //Commands

            //NewCommand 
            AddCommand(ApplicationCommands.New, (sender, e) =>
             {
                 newDialog.Show("New Idea", "Start a new Idea");

             });

            //Open Command 
            AddCommand(ApplicationCommands.Open, (sender, e) =>
             {
                 var openTitle = "Open Files (Can only open Images one at a time.)";
                 var filter = "All Files(.)|*.*";

                 //

                 //Open Dialog Task
                 OpenDialogTask(openTitle, filter, (o, i) =>
                   {
                       //Enable Multiple files 
                       o.Multiselect = true;
                       var extention = i.Extension;

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

                       switch (extention)
                       {
                           default:
                               forEachFile((i) =>
                               {
                                   var note = new NoteView(VM.VMTab, i);
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

            //About 
            AddCommand(DesktopCommands.About, (sender, e) =>
             {
                 // Go to the Help Tab 
                 var help = new HelpView(VM.VMTab);

             });
            //LogInfo 
            AddCommand(DesktopCommands.LogInfo, (sender, e) =>
            {
                //Create a Log View 
                var log = new LogView(VM.VMTab);


            });




            //Internal OnMsg Method 
            void OnMsg(string str)
            {
                tbStatus.Text = str;
                //Quickly Animate
                MediaCv.NotifyHide(tbStatus, 8);
            }

            //Link to OnMsg Event 
            VM.OnMessage += OnMsg;


            //StartNote 
            start = new StartNote(VM.VMTab);
            start.txtCode.Focus();

            //var directory = Directory.GetCurrentDirectory();
            //var dinfo = new DirectoryInfo(directory.)

            //Lamba On Closed 
            Closed += (sender, e) =>
            {
                if (start != null)
                {
                    //Create the format 
                    var format = new NBSettingsFormat
                    {
                        StartNote = start.txtCode.Text,
                        FontFamily = start.txtCode.FontFamily.Source,
                        FontSize = start.txtCode.FontSize,
                        WindowState = this.WindowState
                     
                    };

                    //Conveft format to Json 
                    var json = Serialize(format);

                    CreateFile("abnotebooksettings.json", VM.CurrentDirectory.FullName, json);
                }
                




            };

        }

      


    }
}
