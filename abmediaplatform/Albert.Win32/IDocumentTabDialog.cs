using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Albert.Win32.Controls;
namespace Albert.Win32
{
    /// <summary>
    /// Interface helps create a Tab Dialog;
    /// </summary>
    public interface IDocumentTabDialog
    {
        DocumentDialog TabDialog { get; }
    }
}
