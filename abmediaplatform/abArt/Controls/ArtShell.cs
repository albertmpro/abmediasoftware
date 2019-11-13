using System;
using System.Collections.Generic;
using System.Text;
using System.Windows.Media;
using Albert.Win32;
using Albert.Win32.Controls;
namespace abArt.Controls
{
    /// <summary>
    /// Default Window Shell for this Application 
    /// </summary>
    public class ArtShell: ViewShell, IArtApp
    {
        #region Field's 
        //Grab the ViewModel from your resources 
        private ArtViewModel vm = (ArtViewModel)App.Current.Resources["viewModel"];


        #endregion


        public ArtShell()
        {
            //Do nothng for now
        }
        #region IArtApp Interface Properites 

        public ArtViewModel VM 
        {
            get { return vm; }
            set { vm = value; }
        }

  


        #endregion




    }
}
