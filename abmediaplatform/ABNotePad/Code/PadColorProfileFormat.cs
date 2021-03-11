using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Albert;
namespace ABNotePad.Code
{
    public record PadColorProfileFormat: JsonRecord
    {
        /// <summary>
        /// Record discribes a Color Profile of of Colros 
        /// </summary>
        public PadColorProfileFormat()
        {
            Format = "Color Profile";
            Description = "Collect's Colors and stores them.";
            Author = "Albert M. Byrd";
            
        }

        

        public VMList<PadColor> Colors { get; init; }

        /// <summary>
        /// Return the list of colors 
        /// </summary>
        /// <param name="colors">Color VMList</param>
        public void Deconstruct(out VMList<PadColor> colors)
        {
            colors = Colors;
        }
    }
}
