using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Albert.Win32.Controls;
namespace ABHub.Code.Controls
{
    public class HubView: DocumentControl, IHubViewModel 
    {
        //Field's 
        HubViewModel vm = (HubViewModel)App.Current.Resources["viewModel"];
        HubDialog dlg; 

        /// <summary>
        /// Set the Top Dialog Bar 
        /// </summary>
        public HubDialog TabDialog
        {
            get
            {
                dlg = new HubDialog();
                TopDialogBar = dlg;
                return dlg;

            }
        }





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
