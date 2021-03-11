using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using Albert.Win32.Controls;
namespace ABNotePad.Code.Controls
{
    /// <summary>
    /// Interaction logic for AddNoteDialog.xaml
    /// </summary>
    public partial class AddNoteDialog : DocumentDialog
    {
        public AddNoteDialog()
        {
            InitializeComponent();
        }


        /// <summary>
        /// Get Text to add to the code.
        /// </summary>
        public string Text => txtAdd.Text;
      
    }
}
