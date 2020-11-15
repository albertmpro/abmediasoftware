using System;
using System.Collections.Generic;
using System.Text;
using static Albert.Win32.MediaCv;
using System.Windows.Media;
namespace abmediaplatform
{
    /// <summary>
    /// Format design to capture 5 Colors 
    /// </summary>
    public class ThemeFormat
    {
        public ThemeFormat()
        {
            //Nothing to do 
        }

        public ThemeFormat(Color _color1,Color _color2,Color _color3, Color _color4,Color _color5)
        {
            ColorOne = _color1.ToString();
            ColorTwo = _color2.ToString();
            ColorThree = _color3.ToString();
            ColorFour = _color4.ToString();
            ColorFive = _color5.ToString();
        }

        public string ColorOne { get; set; }
        public string ColorTwo { get; set; }
        public string ColorThree { get; set; }
        public string ColorFour { get; set; }
        public string ColorFive { get; set; }
    }

}
