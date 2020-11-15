using System;
using System.Collections.Generic;
using System.Text;
using System.Windows;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Controls;
using static Albert.Win32.MediaCv;
namespace Albert.Win32.Controls
{
    /// <summary>
    /// Color Picker based on a targeted Bitmap 
    /// </summary>
    [TemplatePart(Name = "PART_ImageColorCanvas", Type = typeof(ImageColorCanvas))]
    public class BitmapColorPicker: Control
    {
        #region Field's 
        ImageColorCanvas imgcanvas = new ImageColorCanvas();
        #endregion

        #region Depdencey Properties 
        
        public static readonly DependencyProperty SourceProperty = DP("Source",typeof(ImageSource),typeof(BitmapColorPicker));
        public static readonly DependencyProperty SelectedColorProperty = DP("SelectedColor", typeof(Color), typeof(BitmapColorPicker));
        public static readonly DependencyProperty StretchProperty = DP("Stretch", typeof(Stretch), typeof(BitmapColorPicker));
        public static readonly DependencyProperty HexProperty = DP("Hex", typeof(string), typeof(BitmapColorPicker));
        public static readonly DependencyProperty HtmlHexProperty = DP("HtmlHex", typeof(string), typeof(BitmapColorPicker));



        #endregion

        #region Constructor and Overrides 

        public BitmapColorPicker()
        {
            //ReDraw the Control 
            DefaultStyleKey = typeof(BitmapColorPicker);
        }

        public override void OnApplyTemplate()
        {
            base.OnApplyTemplate();
            //Get the ImageColorCanvas 
            imgcanvas = (ImageColorCanvas)GetTemplateChild("PART_ImageColorCanvas");


        }
        
        protected override void OnPropertyChanged(DependencyPropertyChangedEventArgs e)
        {
            //Get the Selected Color
            SelectedColor = (Color)imgcanvas?.SelectedColor;
            //Convert Selected Color to string 
            Hex = SelectedColor.ToString();
            //Create an Html Hex Color 
            HtmlHex = Hex.Replace("#FF", "#");
            //Call the OnSelectedColor 
            OnColorSelected?.Invoke(SelectedColor); 

            base.OnPropertyChanged(e);


        }
        #endregion

        #region Events

        /// <summary>
        /// Event Happens when Color is Changed 
        /// </summary>
        public event Action<Color> OnColorSelected;

        #endregion

        #region Public Properties
        
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


        public Color SelectedColor
        {
            get => (Color)GetValue(SelectedColorProperty);
            set => SetValue(SelectedColorProperty, value);
        }

        public string Hex
        {
            get => (string)GetValue(HexProperty);
            set => SetValue(HexProperty, value);
        }

        public string HtmlHex
        {
            get => (string)GetValue(HtmlHexProperty);
            set => SetValue(HtmlHexProperty, value);
        }



        #endregion

    }
}


