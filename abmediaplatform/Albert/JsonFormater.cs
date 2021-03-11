using System;
using System.Collections.Generic;
using System.Text;

namespace Albert
{
    /// <summary>
    /// Base Class for creating something that can be easily converted into Json File Type
    public abstract class JsonFormater: IJsonFormat
    {
   
        /// <summary>
        /// Get or set the Format Name 
        /// </summary>
        public string Format { get; init; }
        /// <summary>
        /// Get or set the Description of the format 
        /// </summary>
        public string Description { get; init; }

        /// <summary>
        /// Get or set the Author's name 
        /// </summary>
        public string Author { get; init; }
    }
}
