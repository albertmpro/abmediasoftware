using System;
using System.Collections.Generic;
using System.Text;

namespace abmediaplatform
{
    /// <summary>
    /// Class designed to setup the mesg format 
    /// </summary>
    public class MsgFormat
    {
        public string Text { get; set; }
        public string Border { get; set; }
        public string Background { get; set; }
        public string Foreground { get; set; }
        public string FontFamily { get; set; }
        public double FontSize { get; set; }
        public double Thickness { get; set; }
        public double CornerRadius { get; set; }
    }
}
