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
using System.Windows.Shapes;
using ABTubePad.Code;
using ABTubePad.Code.Controls;
namespace ABTubePad.View
{
    /// <summary>
    /// Interaction logic for MainView.xaml
    /// </summary>
    public partial class MainView : TubeShell, IViewInit
    {
        public MainView()
        {
            InitializeComponent();
            Init();
            
        }

        public void Init()
        {
            #region Load Settings 


            #endregion

            #region ON Closed 
            //On Application Closed Lamba 
            Closed += (sender, e) =>
            {

            };
            #endregion
        }
    }
}
