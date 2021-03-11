using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Albert.Win32.Controls;
namespace ABNotePad.Code.Controls
{
    /// <summary>
    /// Main Window Class for the Application 
    /// </summary>
    public class PadShell: ViewShell,IPadViewModel
    {
        PadViewModel vm = (PadViewModel)App.Current.Resources["viewModel"];

        /// <summary>
        /// Get Default ViewModel
        /// </summary>
        public PadViewModel VM => vm;
    }
}
