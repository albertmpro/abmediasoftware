using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Albert.Win32.Controls;
namespace ABHub.Code.Controls
{
    public class HubShell: ViewShell, IHubViewModel 
    {

        HubViewModel vm = (HubViewModel)App.Current.Resources["viewModel"];
  

        
        /// <summary>
        /// Get the Deault ViewModel of the Application 
        /// </summary>
        public HubViewModel VM
        {
            get
            {
                DataContext = vm;
                return vm;
            }
        }
    }
}
