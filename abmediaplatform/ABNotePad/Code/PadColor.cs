using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Albert;
using static Albert.Win32.MediaCv;
using System.Windows.Media;
namespace ABNotePad.Code
{
    /// <summary>
    /// Record Discribes a Color 
    /// </summary>
    public record PadColor: IRecordName
    {


        public PadColor()
        {
            Color = Color.FromRgb(0, 0, 0);
        }

        public PadColor(Color _color)
        {
            Color = _color;
        }
        public PadColor(string _strColor)
        {
            Color = HexColor(_strColor);
        }

        public string Name { get; init; }

        /// <summary>
        /// Get or set the Color 
        /// </summary>
        public Color Color { get; init; }

        public string HtmlHex
        {
            get
            {
                string rv = Color.ToString();
                return rv.Replace("#FF", "#");
            }
        }

        /// <summary>
        /// Deconstruct Method 
        /// </summary>
        /// <param name="color"></param>
        public void Deconstruct(out Color color)
        {
            color = Color;
        }


        public override string ToString()
        {
            return Color.ToString();
        }
    }
}
