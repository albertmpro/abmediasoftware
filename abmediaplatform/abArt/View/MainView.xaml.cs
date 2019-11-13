using System;
using System.Collections.Generic;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;
using System.Xml.Linq;
using abArt.Controls;
using Albert.Win32.Controls;
using static Albert.Win32.XmlUtility;
namespace abArt.View
{
    /// <summary>
    /// Interaction logic for MainView.xaml
    /// </summary>
    public partial class MainView : ArtShell
    {

        StartView startView;
        public MainView()
        {
            InitializeComponent();

            //Init Application 
            InitApplication();

        }

        void InitApplication()
        {
            //Create the Start View 
            startView = new StartView(tab);
            startView.Focus();

            //Link to tab to ViewModel 
            VM.VMTab = tab;
            //Link WindowState to ViewModel 
            VM.WindowState = WindowState;

        }
     
    }
}
