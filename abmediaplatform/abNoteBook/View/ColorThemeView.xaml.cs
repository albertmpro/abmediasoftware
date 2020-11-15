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
using Albert.Win32.Controls;
using static Albert.Win32.Win32IO;
using static Albert.Win32.MediaCv;
namespace abNoteBook.View
{
    /// <summary>
    /// Interaction logic for ColorThemeView.xaml
    /// </summary>
    public partial class ColorThemeView : ABView,ITabInitClose
    {
        public ColorThemeView(TabControl _tab)
        {
            InitializeComponent();
            //Setup the Tab 
            SetupTab($"ColorTheme{Count++}", _tab, Close);
        }

        public void Close()
        {
            TabDialog.Show("Closing", "Do you want Close this Tab?", "Close", "Cancel", () =>
                {
                    //Remove the tab
                    RemoveTab();
                
                });
        }

        public void Init()
        {
            

        }

     

        void sass_Click(object sender, RoutedEventArgs e)
        {
            //Define the Solid Color Brush 
            var primebrush = (SolidColorBrush)optPrimary.Background;
            var secondbrush = (SolidColorBrush)optSecondary.Background;
            var accentbrush = (SolidColorBrush)optAccent.Background;
            var forebrush = (SolidColorBrush)optBackground.Background;
            var backbrush = (SolidColorBrush)optBackground.Background;
      
            var primary = primebrush.Color.ToString().Replace("#FF", "#");
            var secondary = secondbrush.Color.ToString().Replace("#FF", "#");
            var accent = accentbrush.Color.ToString().Replace("#FF", "#");
            var foreground = forebrush.Color.ToString().Replace("#FF", "#");
            var background = backbrush.Color.ToString().Replace("#FF", "#");
            //Generate Sass Document 
            var str = "//Theme\n";
            str += $"$primary: {primary};\n";
            str += $"$secondary: {secondary};\n";
            str += $"$accent: {accent};\n";
            str += $"$foreground: {foreground};\n";
            str += $"$background: {background};\n\n\n";
            str += "body\n{";
            str += "\n\tbackground:$background;\n\tcolor:$forground;";
            str += "\n}";
                
            //Display it 
            txtSass.Text = str;



        }

        void opt_Click(object sender, RoutedEventArgs e )
        {
            var opt = sender as OptionButton;
            // Color Logic 
            var brush = (SolidColorBrush)opt.Background;
            var color = brush.Color;
            var str = color.ToString();
            //Create Hex Value
            var hex = str.Replace("#FF", "#");
                
            switch(opt.Tag)
            {
                case "Primary":
                    txtPrimary.Text = hex;
                    break;
                case "Secondary":
                    txtSecondary.Text = hex;
                    break;
                case "Accent":
                    txtAccent.Text = hex;
                    break;
                case "Foreground":
                    txtForeground.Text = hex;
                    break;
                case "Background":
                    txtBackground.Text = hex;
                    break;
            }
        
        }

        void OnColor__Selected(Color _color)
        {
            var brush = new SolidColorBrush(_color);
            var strcolor = _color.ToString();
            var hex = strcolor.Replace("#FF", "#");
           
            if(optPrimary.IsChecked == true)
            {
                optPrimary.Background = brush;
                optPrimary.BackgroundChecked = brush;
                txtPrimary.Text = hex;
            }
            else if (optSecondary.IsChecked == true)
            {
                optSecondary.Background = brush;
                optSecondary.BackgroundChecked = brush;
                txtSecondary.Text = hex;

            }
            else if (optAccent.IsChecked == true)
            {
                optAccent.Background = brush;
                optAccent.BackgroundChecked = brush;
                txtAccent.Text = hex;
            }
            else if (optForeground.IsChecked == true)
            {
                optForeground.Background = brush;
                optForeground.BackgroundChecked = brush;
                txtBackground.Text = hex;
            }
            else if (optBackground.IsChecked == true)
            {
                optForeground.Background = brush;
                optForeground.BackgroundChecked = brush;
                txtForeground.Text = hex;
            }
        }
    }
}
