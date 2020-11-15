using System;
using System.Collections.Generic;
using System.Text;
using System.Windows.Media;
using Albert;
using Albert.Win32;
using static Albert.Win32.MediaCv;
namespace abmediaplatform
{
    public class BrushModel: PropBase
    {
        double brushsize;
        byte brushOpacity;
        Color brushColor;

        public double BrushSize
        {
            get => brushsize;
            set { brushsize = value; OnPropertyChanged("BrushSize"); }
        }

        public byte BrushOpacity
        {
            get => brushOpacity;
            set { brushOpacity = value; OnPropertyChanged("BrushOpacity"); }
        }

        public Color BrushColor
        {
            get => brushColor;
            set { brushColor = value;OnPropertyChanged("BrushColor"); }
        }
    }
}
