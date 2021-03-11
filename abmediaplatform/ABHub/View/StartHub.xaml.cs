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
using System.Windows.Navigation;
using System.Windows.Shapes;
using Albert.Win32.Controls;
using ABHub.Code;
using ABHub.Code.Controls;
namespace ABHub.View
{
    /// <summary>
    /// Main Start Hub 
    /// </summary>
    public partial class StartHub : HubView, IHubInit
    {

        NoteState state;

        public StartHub(TabControl _tab)
        {
            InitializeComponent();
            Init();
            //Set up your Tab
            SetupTab("ST", false, _tab);
            TabItem.ToolTip = "Start Hub";
        }

        public void Init()
        {

        }

        void Add_Click(object sender, RoutedEventArgs e)
        {
            switch(NoteState)
            {
                case NoteState.Script:
                    VM.Notes.Add(txtNote.Text);
                    txtNote.Text = "";
                    break;
                case NoteState.Writer:
                    VM.Notes.Add(txtWriter.Text);
                    txtWriter.Text = "";
                    break;
            }
        
        }

        void NoteState_Click(object sender, RoutedEventArgs e)
        {
            OptionButton opt = sender as OptionButton;

            switch(opt.Tag)
            {
                case "Script":
                    NoteState = NoteState.Script;
                    break;
                case "Writer":
                    NoteState = NoteState.Writer;
                    break;
            }
        }

        public  NoteState NoteState
        {
            get { return state; }
            set
            {
                state = value; 

                switch(value)
                {
                    case NoteState.Script:
                        txtNote.Visibility = Visibility.Visible;
                        txtWriter.Visibility = Visibility.Collapsed;
                        break;

                    case NoteState.Writer:
                        txtNote.Visibility = Visibility.Collapsed;
                        txtWriter.Visibility = Visibility.Visible;
                        break;
                }

            }
        }
    }
}
