using System;
using System.Collections.Generic;
using System.Text;

namespace abNoteBook.Controls
{
    /// <summary>
    /// Interface implments an Init and Close Method
    /// </summary>
    public interface ITabInitClose
    {
        /// <summary>
        /// Method helps start the View 
        /// </summary>
        void Init();
        /// <summary>
        /// Method help close the View
        /// </summary>
        void Close();
    }
}
