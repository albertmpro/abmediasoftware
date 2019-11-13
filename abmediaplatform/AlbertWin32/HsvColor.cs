using System;
using System.Collections.Generic;
using System.Text;

namespace Albert.Win32
{
    /// <summary>
    /// Struct to defin Hsv Color Spectrum 
    /// </summary>
    public struct HsvColor
    {
        public double H;
        public double S;
        public double V;

        /// <summary>
        /// Deffault Consturctor 
        /// </summary>
        /// <param name="h"></param>
        /// <param name="s"></param>
        /// <param name="v"></param>
        public HsvColor(double h, double s, double v)
        {
            H = h;
            S = s;
            V = v;
        }
    }
}
