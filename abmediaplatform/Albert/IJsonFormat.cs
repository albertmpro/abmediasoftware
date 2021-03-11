using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Albert
{
    /// <summary>
    /// Basic Interface for Writing a Json Format 
    /// </summary>
    public interface IJsonFormat
    {
       string Format { get; init; }
       string Description { get; init; }
       string Author { get; init; }
    }
    
}
