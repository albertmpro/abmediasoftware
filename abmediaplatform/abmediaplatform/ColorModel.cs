using System;
using System.Collections.Generic;
using System.Text;
using System.Windows.Media;
using Albert;
using Albert.Win32;
using static Albert.Win32.MediaCv;
namespace abmediaplatform
{
    public class ColorModel: PropBase
    {
        Color color;
        

        public ColorModel()
        {
            //Default Color is Black 
            Color = HexColor("#ff0000000");
        }

        public ColorModel(string _name, string _colorstring)
        {
            Name = _name;
            Color = HexColor(_colorstring);
        }

        public ColorModel(string _name, Color _color)
        {
            Name = _name;
            Color = _color;
        }

        public ColorModel(Color _color)
        {
            Color = _color;
        }


       



        /// <summary>
        /// Get or set the Color 
        /// </summary>
        public Color Color
        {
            get => color;
            set
            {
                color = value;
                OnPropertyChanged("Color");
            }
        }


    }
}
