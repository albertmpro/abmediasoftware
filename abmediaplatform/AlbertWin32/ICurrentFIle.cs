using System;
using System.Collections.Generic;
using System.Text;
using System.IO;
namespace Albert.Win32
{
    /// <summary>
    /// Interface to Capture  File Information of a single file 
    /// </summary>
    public interface ICurrentFile
    {
        /// <summary>
        /// Get or set FileInfo 
        /// </summary>
        FileInfo FileInfo { get; set; }
        /// <summary>
        /// Get or set FileLocation 
        /// </summary>
        string FileLocation { get; set; }

    }
}
