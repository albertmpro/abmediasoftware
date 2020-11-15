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
    /// View used to view Log Information and save sessions 
    /// </summary>
    public partial class LogView : ABView
    {
        /// <summary>
        /// Default Constructor 
        /// </summary>
        public LogView(TabControl _tab)
        {
            InitializeComponent();

            //Setup the Tab 
            SetupTab("Log", true, _tab);
        }
    }
}
