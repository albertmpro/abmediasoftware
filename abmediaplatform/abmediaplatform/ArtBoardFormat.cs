using System;
using System.Collections.Generic;
using System.Text;
using System.Windows.Controls;
using System.Windows.Ink;
using System.Windows.Media;
using Albert;
namespace abmediaplatform
{
    public class ArtBoardFormat: JsonFormater 
    {
        /// <summary>
        /// Default Constructor 
        /// </summary>
        public ArtBoardFormat()
        {

         
            Format = "ArtBoard";
            Description = "Artboard Format is design to sae strokes and other information";
            Author = "Albert M. Byrd";
        }
        
        public StrokeCollection Strokes { get; set; }
    }
}
