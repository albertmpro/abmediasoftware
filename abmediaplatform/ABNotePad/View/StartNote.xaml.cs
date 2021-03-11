using System;
using System.Windows;
using System.Windows.Controls;
using Albert.Win32;
using static Albert.Win32.Win32IO;
using static System.IO.File;
using ABNotePad.Code;
using ABNotePad.Code.Controls;
using static System.Text.Json.JsonSerializer;
using System.Windows.Documents;
using Albert.Win32.Controls;
using System.Windows.Media;

namespace ABNotePad.View
{
    /// <summary>
    /// Interaction logic for StartNote.xaml
    /// </summary>
    public partial class StartNote : PadView
    {
        
        public StartNote(TabControl _tab)
        {
            InitializeComponent();
            
            //Extra Initialized Code 
            Init();

            SetupTab("StartPad", false, _tab);
        }


 
        public void Init()
        {
           

            #region Unit Test Code 
            /* Unit Test Code 
            TabDialog.Show("Unit Test", "Unit Test For", "Ok", "Cancel", () =>
                {
                });
            */
            #endregion

        }
        void hyperLink_Click(object sender, RoutedEventArgs e )
        {
            Hyperlink link = sender as Hyperlink; 

            switch(link.Tag)
            {
                case "Text":
                    NoteView note = new NoteView(VM.VMTab); 
                    break;
                case "Draw":
                    DrawView draw = new DrawView(VM.VMTab);
                    break;
            }

            //Hide 
            gridNew.Visibility = Visibility.Collapsed;

        }

        void AddNote_Click(object sender, RoutedEventArgs e )
        {
            //Add to Notes 
            VM.Notes.Add(txtCode.Text);

            //Clear the TextBox 
            txtCode.Text = "";
            //Send Message 
            VM.Message("Note Added.", true);
        }








    }
}
