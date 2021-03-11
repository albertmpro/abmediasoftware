using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Albert.Win32.Controls;
namespace ABHub.Code.Controls
{
    public class HubDialog: DocumentDialog, IHubViewModel  
    {
        HubViewModel vm = (HubViewModel)App.Current.Resources["viewModel"];
        /// <summary>
        /// Link to the default ViewModel 
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
