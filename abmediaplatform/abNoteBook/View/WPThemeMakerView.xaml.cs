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
using System.Windows.Navigation;
using System.Windows.Shapes;
using abNoteBook.Controls;
using System.IO;
using Albert.Win32;
using static Albert.Win32.Win32IO;
namespace abNoteBook.View
{
    /// <summary>
    /// Interaction logic for WPThemeMakerView.xaml
    /// </summary>
    public partial class WPThemeMakerView : ABView
    {
        public WPThemeMakerView(TabControl _tab)
        {
            InitializeComponent();
            SetupTab("WP Theme", true, _tab);
        }

        void Generate_Click(object sender, RoutedEventArgs e)
        {
         


             
        }
    
    }
}
