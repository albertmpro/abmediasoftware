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

namespace abNoteBook.View
{
    /// <summary>
    /// Interaction logic for FontDesignView.xaml
    /// </summary>
    public partial class FontDesignView : ABView,ITabInitClose
    {
        public FontDesignView(TabControl _tab)
        {
            InitializeComponent();
            //Create the Tab
            SetupTab($"FontApp{Count++}",_tab, Close);

            //Init 
            Init();
        }

        public void Close()
        {
            //Dialog Lamba 
            TabDialog.Show("Closing Tab", "Do you want to close this Tab?", "Close", "Cancel", () =>
            {
                //Remove Tab 
                RemoveTab();
            });
        }

        public void Init()
        {
           
        }
    }
}
