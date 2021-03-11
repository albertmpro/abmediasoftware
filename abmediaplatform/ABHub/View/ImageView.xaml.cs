using System;
using System.Collections.Generic;
using System.IO;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using static Albert.Win32.MediaCv;
using ABHub.Code.Controls;
using Microsoft.Win32;
using Albert.Win32.Controls;
namespace ABHub.View
{
    /// <summary>
    /// Interaction logic for ImageView.xaml
    /// </summary>
    public partial class ImageView : HubView
    {
        public ImageView(TabControl _tab)
        {
            InitializeComponent();
        }


        public ImageView(TabControl _tab, FileInfo _info)
        {
            InitializeComponent();
            var thename = _info?.Name;
            var fullname = _info.FullName;

            

            //Setup the tab 
            SetupTab(thename, true, _tab);

        

            //Load the IMage 
            ImageFile(img, fullname, Stretch.Uniform);

            VM.OpenFileAndLog(_info);
            VM.CurrentFileNames.Add(_info.FullName);
        }
    }
}
