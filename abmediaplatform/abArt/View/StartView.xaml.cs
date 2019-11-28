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
using abArt.Controls;
using tk = Xceed.Wpf.Toolkit;
using Albert.Win32;
using static Albert.Win32.Win32IO;
namespace abArt.View
{
    /// <summary>
    /// Interaction logic for StartView.xaml
    /// </summary>
    public partial class StartView : ArtView
    {

        
        public StartView(TabControl _tab)
        {
            InitializeComponent();

            //Create the Tab 
            SetupTab("StartPage", false, _tab);

        }

        public override void OnLogic()
        {
            tk.MessageBox.Show("Test Logic!");
        }

        void Hyper_Click(object sender, RoutedEventArgs e)
        {
            var hyperlink = sender as Hyperlink;
            switch(hyperlink.Tag)
            {
                case "ArtBoard":

                    break;
                case "Msg":

                    break;
                case "Text":

                    break;
                case "Browser":

                    break;
                case "Load":
                    Load_Files();
                    break;
                default:
                    //Do Nothing  
                    break;
            }
        }

        void Load_Files()
        {
            //Fill out Dialog Tuple 
            (string title, string filter) = DialogInfoTuple("Open a Project or File", VM.FilterTuple().All);

            OpenDialogTask(title, filter, (o, i) =>
             { 
                 switch(i.Extension)
                 {
                     case "abartboard":

                         break;
                     case "abmsg":

                         break;
                     case "abbrand":

                         break;
                     default:

                         break;
                 }
             
             });

        }




    }
}
