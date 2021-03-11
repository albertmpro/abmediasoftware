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
using ABHub.Code;
using ABHub.Code.Controls;

namespace ABHub.View
{
    /// <summary>
    /// Interaction logic for FontEdegeView.xaml
    /// </summary>
    public partial class FontLabView : HubView
    {
        public FontLabView(TabControl _tab)
        {
            InitializeComponent();
            SetupTab("FL", false, _tab);
            TabItem.ToolTip = "Font Lab ";
        }
    }
}
