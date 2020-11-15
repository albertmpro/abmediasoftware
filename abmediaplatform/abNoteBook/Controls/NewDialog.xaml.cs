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
using abmediaplatform;
using abNoteBook.View;
using Albert.Win32;
using Albert.Win32.Controls;
namespace abNoteBook.Controls
{
    /// <summary>
    /// Interaction logic for NewDialog.xaml
    /// </summary>
    public partial class NewDialog : DocumentDialog, IPlatform
    {
        //Field's 
        PlatformViewModel vm = (PlatformViewModel)App.Current.Resources["viewModel"];

        public NewDialog()
        {
            InitializeComponent();
        }

        void Cancel_Click(object sender, RoutedEventArgs e )
        {
            //Hide the Dialog 
            Hide();
        }

        void NewItem_Click(object sender, RoutedEventArgs e)
        {
            var push = sender as OptionButton;
            
            switch(push.Tag)
            {
                case "Note":
                    var note = new NoteView(VM.VMTab);
                    break;
            
                case "FontEx":

                    var font = new FontDesignView(VM.VMTab);

                    break;
                case "Art":
                    var art = new ArtboardView(VM.VMTab);
                    break;
            }

            //Hide 
            Hide();
        }


        /// <summary>
        /// Get the main ViewModel of the Applicatin 
        /// </summary>
        public PlatformViewModel VM
        {
            get => vm;
        }
    }
}
