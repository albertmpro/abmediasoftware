using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using static System.Text.Json.JsonSerializer;
using System.Threading.Tasks;
using System.IO;
using static System.IO.File;
using System.Windows;
using System.Windows.Input;
using System.Windows.Media;
using Albert;
using Albert.Win32;
using Albert.Win32.Controls;
using static Albert.Win32.MediaCv;
using static Albert.Win32.Win32IO;
using ABHub.Code;
using ABHub.Code.Controls;
namespace ABHub.View
{
    /// <summary>
    /// Interaction logic for MainHub.xaml
    /// </summary>
    public partial class MainHub : HubShell, IHubInit
    {
        StartHub start;
        YouTubeHub yt;
        FontLabView fe;
        NotesView notes;
        ConceptDesignView concept;
        public MainHub()
        {
            InitializeComponent();
            Init();
            VM.Message("Welcome to the ABHub", false);
        }

        public void Init()
        {
            #region ViewModel Logic 
            
            //Setup the Main TabControl
            VM.VMTab = tab;

            //Method for Notifcation  
            void Msg_Notify(string str)
            {
                tbStatus.Text = str;
                MediaCv.NotifyHide(tbStatus, 7);
            }
            //Setup Notification 
            VM.OnMessage += Msg_Notify;
            #endregion


            #region Pre-Made Views 
            
         
            start = new StartHub(VM.VMTab);
            notes = new NotesView(VM.VMTab);
            concept = new ConceptDesignView(VM.VMTab);
            yt = new YouTubeHub(VM.VMTab);
            fe = new FontLabView(VM.VMTab);
            

            #endregion 



            #region Load your Settings 

            if (Exists("notes.json"))
            {
                //Load Json file 
                string noteslJson = ReadAllText("notes.json");
                //Convert Back into HubNotes 
                HubNotes mynotes = Deserialize<HubNotes>(noteslJson);
                //Deconstruct and dump into the ViewModel 
                (string snote, string wnote, VMList<string> notes, VMList<HubFont> fonts, VMList<string> sfiles, VMList<VMLogInfo> logs,string flnotes) = mynotes;
                //ViewMdoel Dump 
                start.txtNote.Text = snote;
                start.txtWriter.Text = wnote;
                fe.txtSample.Text = flnotes;
                VM.Notes = notes;
                VM.Fonts = fonts;
                VM.CurrentFileNames = sfiles;
                VM.Log = logs;
            }

            if (Exists("youtube.json"))
            {
                string ytJson = ReadAllText("youtube.json");
                //Convert to HubYT 
                HubYT tube = Deserialize<HubYT>(ytJson);

                //Dump it in YTTab 
                (string yscript, string ydescription, string ytags, string ycomments) = tube;
                yt.txtScript.Text = yscript;
                yt.txtDescription.Text = ydescription;
                yt.txtTags.Text = ytags;
                yt.txtComment.Text = ycomments;

            }
            if(Exists("concept.json"))
            {
                string ccjson = ReadAllText("concept.json");
                //Convert to HubConcept 
                HubConcept myconcept = Deserialize<HubConcept>(ccjson);
                //Deconstruct into parts 
                var (usedcolors, sizes) = myconcept;
                VM.UsedColors = usedcolors;
                VM.DrawSizes = sizes;
            }



            #endregion



            #region Commands 
            AddCommand(ApplicationCommands.New, (sender, e) =>
             {
                 newItem.Show("New Item", "Select Item ");

             });
            AddCommand(ApplicationCommands.Open, (sender, e) =>
             {
                 string openTitle = "Open File";
                 string filter = "All Formats(.)|*.*";

                 OpenDialogTask(openTitle, filter, (o, i) =>
                   {

                   });

             });
            #endregion


            #region Close Application Method 
            //Save your settings on Close 
            Closed += (sender, e) =>
            {
                //Create a HubSettings Record 
                HubNotes notes = new HubNotes
                {
                    ScriptNote = start.txtNote.Text,
                    WriterNote = start.txtWriter.Text,
                    FontLabNote = fe.txtSample.Text,
                    Notes = VM.Notes,
                    Fonts = VM.Fonts,
                    SavedFiles = VM.CurrentFileNames,
                    Logs = VM.Log
                };

                HubYT ytrecord = new HubYT
                {
                    YTScript = yt.txtScript.Text,
                    YTDescription = yt.txtDescription.Text,
                    YTTags = yt.txtTags.Text,
                    YTTopComment = yt.txtComment.Text
                };

                HubConcept concept = new HubConcept
                {
                    UsedColors = VM.UsedColors,
                    Sizes = VM.DrawSizes
                };


                //Convert settings to Json here  
                string notesjson = Serialize(notes);
                string ytjson = Serialize(ytrecord);
                string conceptjson = Serialize(concept);

                //Save your settings here  
                WriteAllText("notes.json", notesjson);
                WriteAllText("youtube.json", ytjson);
                WriteAllText("concept.json", conceptjson);



            };
            #endregion


        }


        void push_Click(object sender, RoutedEventArgs  e)
        {
            PushButton push = sender as PushButton;

            switch(push.Tag)
            {
                case "Help":

                    break;
                case "Log":

                    break;
            }
        }
    }
}
