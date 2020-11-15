using System;
using System.Collections.Generic;
using System.Text;
using System.Windows;
using System.Windows.Controls;
namespace Albert.Win32
{
    /// <summary>
    /// A group of method's to deal with Grid's  
    /// </summary>
    public interface IDocGridBuilder
    {
       
        void GridClear(Grid grid);
        void GridFixedDoc(Grid gird, UIElement el1, UIElement el2, double fixedamount);
        void GridSingle(Grid grid, UIElement el1);
        void GridSplitter(Grid grid, UIElement el1, UIElement el2);
    }
        
}
