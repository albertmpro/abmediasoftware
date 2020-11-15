using System;
using System.Collections.Generic;
using abmediaplatform;
using Albert.Win32.Controls;
namespace abNoteBook.Controls
{
    /// <summary>
    /// Main Window Shell of this Applicaton 
    /// </summary>
    public class ABShell : ViewShell
    {
        //Field's 
        NoteBookViewModel vm = (NoteBookViewModel)App.Current.Resources["viewModel"];

        /// <summary>
        /// Get the main View Model of the Applicatin 
        /// </summary>
        public NoteBookViewModel VM => vm;
   
    }
}
