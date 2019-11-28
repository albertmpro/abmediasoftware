using System;
using System.Collections.Generic;
using System.Text;
using System.Windows.Media;
using Albert.Win32;
using Albert.Win32.Controls;
namespace abArt.Controls
{
    /// <summary>
    /// Base Control for doing projects with this application 
    /// </summary>
    public class ArtView: DocumentControl, IArtViewModel
    {
        #region Field's 
        //Grab the ViewModel from your resources 
        private ArtViewModel vm = (ArtViewModel)App.Current.Resources["viewModel"];
        


        #endregion

        #region IArtApp Interface Properites 

        public ArtViewModel VM
        {
            get { return vm; }
            set { vm = value; }
        }

  
        #endregion

    }
}
