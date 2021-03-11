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
using ABNotePad.Code;
using ABNotePad.Code.Controls;

namespace ABNotePad.View
{
    /// <summary>
    /// Interaction logic for YTubeView.xaml
    /// </summary>
    public partial class YTubeView : PadView
    {
        public YTubeView(TabControl _tab)
        {
            InitializeComponent();
            //Setup Tab 
            SetupTab("Youtube Info ", true, _tab);
        }
    }
}
