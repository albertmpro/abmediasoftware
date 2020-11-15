using System;
using Albert;

namespace abmediaplatform
{
    /// <summary>
    /// Format for Notes 
    /// </summary>
    public class ABTextFormat: JsonFormater
    {
        /// <summary>
        /// Default Constructor 
        /// </summary>
        public ABTextFormat()
        {
            Format = "ABText";
            Description = "AB Text is a Format that saves the Text, the Font Family, and the Font Size.";
            Author = "Albert M. Byrd";
        }
        public string Text { get; set; }
        public string FontFamily { get; set; }
        public double FontSize { get; set; }
    }
}
