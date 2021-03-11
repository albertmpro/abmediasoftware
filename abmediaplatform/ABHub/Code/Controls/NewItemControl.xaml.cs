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
using ABHub.View;
using Albert.Win32.Controls;
namespace ABHub.Code.Controls
{
    /// <summary>
    /// Interaction logic for NewItemControl.xaml
    /// </summary>
    public partial class NewItemControl : HubDialog
    {
        public NewItemControl()
        {
            InitializeComponent();
        }

        void New_Click(object sender, RoutedEventArgs e )
        {

            OptionButton opt  = sender as OptionButton;

            switch(opt.Tag)
            {
                case "Note":
                    TextEditorView text = new TextEditorView(VM.VMTab);
                    break;
                case "Draw":
                    DrawView draw = new DrawView(VM.VMTab);
                    break;
            }

            this.Hide();
        }
    }
}
