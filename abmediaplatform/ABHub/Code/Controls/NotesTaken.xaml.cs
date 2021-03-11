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
namespace ABHub.Code.Controls
{
    /// <summary>
    /// Interaction logic for NotesTaken.xaml
    /// </summary>
    public partial class NotesTaken : HubView
    {
        public NotesTaken()
        {
            InitializeComponent();
           
        }

        void Note_Click(object sender, RoutedEventArgs e)
        {
            PushButton push = sender as PushButton;

            switch (push.Tag)
            {
                case "Add":
                    string str = txtEdit?.Text;
                    VM.Notes.Add(str);
                    break;
                case "Reomove":
                    
                    break;
                case "Clear":
                    TabDialog.Show("Clear Notes", "Do you want to clear notes", "Clear", "Cancel", () =>
                    {
                        //Clear your notes 
                        VM.Notes.Clear();

                    });
                    break;
            }
        }


        private void lstNotesTaken_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (lstNotesTaken.SelectedItem != null)
            {
                string item = (string)lstNotesTaken.SelectedItem;

                txtEdit.Text = item;
            }
        }
    }
}
