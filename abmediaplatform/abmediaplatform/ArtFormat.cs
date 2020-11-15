using System;
using System.Collections.Generic;
using System.Text;
using Albert;
namespace abmediaplatform
{
    /// <summary>
    /// Designed to form the Width and Height of a document
    /// </summary>
    public class ArtFormat : PropBase
    {
        double width, height;

        public ArtFormat()
        {
            Width = 1920;
            Height = 1080;
        }

        public ArtFormat(double _square)
        {
            Width = _square;
            Height = _square;
        }

        public ArtFormat(double _width,double _height)
        {
            Width = _width;
            Height = _height;
        }
        public double Width
        {
            get => width;
            set { width = value; OnPropertyChanged("Width"); }
        }

        public double Height
        {
            get => height;
            set { height = value; OnPropertyChanged("Height"); }
        }

        public override string ToString()
        {
            //Return the Format 
            return $"{Width}px x {Height}px";
        }

    }
}
