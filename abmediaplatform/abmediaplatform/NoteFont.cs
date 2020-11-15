using System;
using System.Collections.Generic;
using System.Text;
using System.Windows.Media;
using Albert;
namespace abmediaplatform
{
    /// <summary>
    /// Grab's a Spacific Font ot be used 
    /// </summary>
    public class NoteFont: PropBase
    {
        
        FontFamily font;
      
    

        public FontFamily FontFamily
        {
            get
            {
                font = new FontFamily(Name);
                return font;
            }
            
        }

        public override string ToString()
        {
            //Return the Font Name 
            return Name;
        }

    }
}
