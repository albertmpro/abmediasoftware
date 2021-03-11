using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ABNotePad.Code
{
    /// <summary>
    /// Record defins a DrawCanvas sizes 
    /// </summary>
    public record PadDrawSize
    { 

        public PadDrawSize()
        {
            Width = 1920;
            Height = 1080;
        }
        public PadDrawSize(double _width, double _height)
        {
            Width = _width;
            Height = _height;   

        }
        public PadDrawSize(string _name,double _width, double _height)
        {
            Name = _name;
            Width = _width;
            Height = _height;

        }

        public PadDrawSize(double _square)
        {
            Width = _square;
            Height = _square;
        }
        public PadDrawSize(string _name,double _square)
        {
            Name = _name;
            Width = _square;
            Height = _square;
        }

        /// <summary>
        /// Get the Name of the DrawSize 
        /// </summary>
        public string Name { get; init; }

        /// <summary>
        /// Get the Width you want 
        /// </summary>
        public double Width { get; init; }
        /// <summary>
        /// Get the Height you want
        /// </summary>
        public double Height { get; init; }

        public override string ToString()
        {
            return $"{Name} ({Width}px  x  {Height}px)";
        }


        public void Deconstruct(out double width, out double height)
        {
            width = Width;
            height = Height;
        }
    }
}
