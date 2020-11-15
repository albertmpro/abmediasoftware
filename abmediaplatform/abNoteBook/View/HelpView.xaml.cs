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
using Albert.Win32;
using Albert.Win32.Controls;
using abNoteBook.Controls;
namespace abNoteBook.View
{
    /// <summary>
    /// Interaction logic for HelpView.xaml
    /// </summary>
    public partial class HelpView : ABView
    {
        public HelpView(TabControl _tab)
        {
            InitializeComponent();
            SetupTab("Help", true, _tab);
        }
    }
}
