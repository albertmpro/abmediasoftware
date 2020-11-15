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
    /// Interaction logic for MsgView.xaml
    /// </summary>
    public partial class MsgView : ABView,ITabInitClose
    {
        public MsgView(TabControl _tab)
        {
            InitializeComponent();

            //Setup Tab 
            SetupTab($"Msg{Count++}", _tab, Close);
        }

        public void Close()
        {
            //Setup CLose Dialog 
            TabDialog.Show("Closing", "Do you want to Close this Tab?", "Close", "Cancel",()=>
                {
                    RemoveTab();
                });
        }

        public void Init()
        {
            
        }
    }
}
