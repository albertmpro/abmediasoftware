using System;
using System.Collections.Generic;
using System.Text;
using Albert.Win32.Controls;
namespace abArtBoard.Controls
{
    /// <summary>
    /// Default View of the Applicaton 
    /// </summary>
    public class ABview: DocumentControl
    {

        ArtBoardViewModel vm = (ArtBoardViewModel)App.Current.Resources["viewModel"];
        /// <summary>
        /// Get or set the main View Model
        /// </summary>
        public ArtBoardViewModel VM
        {
            get => vm;
            
        }

    }
}
