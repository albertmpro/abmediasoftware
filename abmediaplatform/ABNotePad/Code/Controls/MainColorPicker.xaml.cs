using System;
using System.CodeDom;
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
using static Albert.Win32.MediaCv;
using static Albert.Win32.Win32IO;
namespace ABNotePad.Code.Controls
{
    /// <summary>
    /// Interaction logic for MainColorPicker.xaml
    /// </summary>
    public partial class MainColorPicker : UserControl
    {
       

    

        public MainColorPicker()
        {
            InitializeComponent();
         
        }

        void select_Click(object sender, RoutedEventArgs  e )
        {
            //Vars
            var opt = sender as OptionButton;
            var color1Source = optColor1.Source;
            var color2Source = optColor2.Source;
            var color3Source = optColor3.Source;
            var color4Source = optColor4.Source;
            var custom = optCustom.Source;
            switch (opt.Tag)
            {
                case "Color1":
                    imgColor.Source = color1Source;
                    break;
                case "Color2":
                    imgColor.Source = color2Source;
                    break;
                case "Color3":
                    imgColor.Source = color3Source;
                    break;
                case "Color4":
                    imgColor.Source = color4Source;
                    break;
                case "Custom":
                    imgColor.Source = custom;
                    break;
            }
        }

        void Load_Click(object sender,RoutedEventArgs e)
        {
            var title = "Load Image to paint with";
            var filter = "Image Files|*.png;*.jpg;*.jepg;*.tiff";

            OpenDialogTask(title, filter, (o, i) =>
              {
                  //Load the Image file 
                  ImageFile(optCustom, o.FileName, Stretch.Uniform);

                  imgColor.Source = optCustom.Source;
              
              });
        }

        public event Action<Color> OnSelectedColor;

        protected override void OnPropertyChanged(DependencyPropertyChangedEventArgs e)
        {
            //Enable the ON ColorSelected 
            OnSelectedColor?.Invoke(imgColor.SelectedColor);
            base.OnPropertyChanged(e);
        }

        /// <summary>
        /// Get Current Color 
        /// </summary>
        public Color SelectedColor => imgColor.SelectedColor;
        /// <summary>
        /// Get selcted Brush
        /// </summary>
        public SolidColorBrush SelectedBrush => new SolidColorBrush(imgColor.SelectedColor);
    }
}
