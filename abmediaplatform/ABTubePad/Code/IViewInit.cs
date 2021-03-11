using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ABTubePad.Code
{
    /// <summary>
    /// Interfce to INit the Shell 
    /// </summary>
    public interface IViewInit
    {
        void Init();

    }

    /// <summary>
    /// Interface to Init Tab View 
    /// </summary>
    public interface ITabViewIint : IViewInit
    {
        void Close();
    }
}
