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
using ABHub.Code.Controls;
namespace ABHub.View
{
    /// <summary>
    /// Interaction logic for YouTubeHub.xaml
    /// </summary>
    public partial class YouTubeHub : HubView
    {
        public YouTubeHub(TabControl _tab)
        {
            InitializeComponent();
            SetupTab("YT", false, _tab);
            TabItem.ToolTip = "Youtube Tab";
        }
    }
}
