using System;
using System.Collections.Generic;
using System.Text;
using System.Windows.Media;
namespace abArt.Controls
{
    /// <summary>
    /// An Interface that helps keep the App consistant 
    /// </summary>
    internal interface IArtApp
    {

  
        //Default ViewModel 
        ArtViewModel VM { get; set; }
        
    
    }
}
