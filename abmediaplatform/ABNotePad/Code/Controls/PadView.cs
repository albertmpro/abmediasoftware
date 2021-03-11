using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Albert.Win32;
using Albert.Win32.Controls;
namespace ABNotePad.Code.Controls
{
    /// <summary>
    /// Defines a Pad View to be VIed by the user 
    /// </summary>
    public class PadView: DocumentControl,IPadViewModel,IDocumentTabDialog
    {
        PadViewModel vm = (PadViewModel)App.Current.Resources["viewModel"];
        DocumentDialog tabd;



        public DocumentDialog TabDialog
        {
            get
            {
                tabd = new DocumentDialog();
                TopDialogBar = tabd;
                return tabd;
            }
        }

        /// <summary>
        /// Get Default ViewModel
        /// </summary>
        public PadViewModel VM
        {
            get
            {
                DataContext = vm;
                return vm;
            }
        }

    }
}
