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
using ABHub.Code;
using ABHub.Code.Controls;
using Albert.Win32;
using Albert.Win32.Controls;
namespace ABHub.View
{
    /// <summary>
    /// Interaction logic for ConceptProjectView.xaml
    /// </summary>
    public partial class ConceptProjectView : HubView,IHubTabInit
    {
        public ConceptProjectView(TabControl _tab)
        {
            InitializeComponent();
            Init();
            SetupTab($"Concept{Count++}", _tab, Close);

        }

        public void Close()
        {
            TabDialog.Show("Closing Tab", "Do you want to close this Conept?", "Close", "Cancel", () =>
               {
                   //Close the Tab 
                   RemoveTab();
                   //Send Message to the Application 
                   VM.Message("Closed Concept Tab", false);
               
               });
        }

        public void Init()
        {
            
        }
    }
}
