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
using static Albert.Win32.MediaCv;
namespace Albert.Win32.Controls
{
    /// <summary>
    /// Color Picker based off a Bitmap 
    /// </summary>
    public partial class BitmapColorPicker : UserControl
    {
        public static readonly DependencyProperty SourceProperty = DP("Source", typeof(ImageSource), typeof(BitmapColorPicker),(sender,e) =>
        {
            var obj = sender as BitmapColorPicker;
            //Link to the Image Canvas 
            obj.imgCanvas.Source = (ImageSource)e.NewValue;
        
        });

        public static readonly DependencyProperty StretchProperty = DP("Stretch", typeof(Stretch), typeof(BitmapColorPicker),Stretch.Uniform, (sender, e) =>
        {
            var obj = sender as BitmapColorPicker;
            //Link to the Image Canvas 
            obj.imgCanvas.Stretch = (Stretch)e.NewValue;

        });


        public static readonly DependencyProperty SelectedColorProperty = DP("SelectedColor",typeof(Color),typeof(BitmapColorPicker),(sender,e)=>
        {
            var obj = sender as BitmapColorPicker;

            obj.imgCanvas.SelectedColor = (Color)e.NewValue;

            var brush = new SolidColorBrush(obj.imgCanvas.SelectedColor);

            obj.rectangle.Fill = brush;
        
        });

        public event Action<Color> SelectedColorChanged;


        /// <summary>
        /// Ovverrideble method for when the Color changes 
        /// </summary>
        /// <param name="c"></param>
        public virtual void OnSelectedColor(Color c)
        {
            c = imgCanvas.PickColor(imgCanvas.Position.X, imgCanvas.Position.Y);
           
            SelectedColorChanged?.Invoke(c);
        }


        /// <summary>
        /// Default Constructor 
        /// </summary>
        public BitmapColorPicker()
        {
            InitializeComponent();
        }

        /// <summary>
        /// Get or set the Bitmap Source 
        /// </summary>
        public ImageSource Source
        {
            get => (ImageSource)GetValue(SourceProperty);
            set => SetValue(SourceProperty, value);
        }

        public Stretch Stretch
        {
            get => (Stretch)GetValue(StretchProperty);
            set => SetValue(StretchProperty, value);
        }
        /// <summary>
        /// Get or set the Selected Color 
        /// </summary>
        public Color SelectedColor
        {
            get => (Color)GetValue(SelectedColorProperty);
            set => SetValue(SelectedColorProperty, value);
        }



    }
}
