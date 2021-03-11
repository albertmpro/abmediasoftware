using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ABNotePad.Code
{
    /// <summary>
    /// Enum designed to set the WriterState Code or Writer
    /// </summary>
   public enum WriterState
    {
        Code,Writer 
    }

    public enum ArtBoardMode
    {
        Pen,Background 
    }
    /// <summary>
    /// Enum defines a ArtboardState
    /// </summary>
    public enum ArtBoardState
    {
        ArtboardLeft,ArtBoardRight,PaintSplitLeft,PaintSplitRight,Preview
    }
}
