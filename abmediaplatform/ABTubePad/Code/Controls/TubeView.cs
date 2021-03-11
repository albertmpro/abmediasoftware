using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Albert.Win32.Controls;
namespace ABTubePad.Code.Controls
{
    /// <summary>
    /// Default View Control of the Application 
    /// </summary>
    public class TubeView: DocumentControl, ITubeViewModel
    {
        
        TubeViewModel vm = (TubeViewModel)App.Current.Resources["viewModel"];

        /// <summary>
        /// Get the MainViewModel 
        /// </summary>
        public TubeViewModel VM
        {
            get
            {
                DataContext = vm;
                return vm;
            }
        }
    }
}
