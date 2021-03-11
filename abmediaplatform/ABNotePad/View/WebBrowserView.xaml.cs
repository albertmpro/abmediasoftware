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
    /// Interaction logic for WebBrowserView.xaml
    /// </summary>
    public partial class WebBrowserView : PadView, IViewInit
    {
        public WebBrowserView(TabControl _tab)
        {
            InitializeComponent();

            SetupTab("WebView", true, _tab);
        }

        public void Close()
        {
            throw new NotImplementedException();
        }

        public void Init()
        {
            throw new NotImplementedException();
        }
    }
}
