using System;
using abmediaplatform;
using Albert.Win32.Controls;
namespace abNoteBook.Controls
{
    /// <summary>
    /// Control repsents a View of the Application 
    /// </summary>
    public class ABView: DocumentControl
    {
        //Field's 
        NoteBookViewModel vm = (NoteBookViewModel)App.Current.Resources["viewModel"];
        DocumentDialog dialog = new DocumentDialog { IsButtonsHidden = false };
        /// <summary>
        /// Get the main View Model of the Applicatin 
        /// </summary>
        public NoteBookViewModel VM => vm;

      

        public DocumentDialog TabDialog
        {
            get 
            {
                //set to top dialog bar 
                TopDialogBar = dialog;
                return dialog;
            }
        }

        

        

    }
}
