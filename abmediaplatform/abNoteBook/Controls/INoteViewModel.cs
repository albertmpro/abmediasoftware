using System;
using System.Collections.Generic;
using System.Text;
using abmediaplatform;
namespace abNoteBook.Controls
{

    /// <summary>
    /// Interface implments the NoteViewModel
    /// </summary>
    public interface IPlatformViewModel
    {
        /// <summary>
        /// Main read-only ViewModel
        /// </summary>
        PlatformViewModel VM { get; }
    }
}
