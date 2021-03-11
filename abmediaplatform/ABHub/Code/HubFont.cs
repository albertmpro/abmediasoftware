using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Media;

namespace ABHub.Code
{
    /// <summary>
    /// Record holds a Font and the Name of the Font 
    /// </summary>
    public record HubFont
    {
        public HubFont(string _name)
        {
            Name = _name;
        }



        public string Name { get; init; }

        public FontFamily FontFamily
        {
            get 
            {
                FontFamily rv = new FontFamily(Name);
                return rv;
            }
        }

        public override string ToString()
        {
            return Name;
        }

    }
}
