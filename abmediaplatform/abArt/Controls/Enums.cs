using System;
using System.Collections.Generic;
using System.Text;

namespace abArt.Controls
{
    /// <summary>
    /// Discribes the Msg you want to send 
    /// </summary>
    public enum MsgType
    {
        Normal,Rich,ImgTop,ImgBotttom, ImgCenter 
    }
    /// <summary>
    /// Defines Text Editor Mode 
    /// </summary>
    public enum TextEditorMode
    {
        Code,Writer 
    }
    /// <summary>
    /// Define diffrent ArtBoard Modes 
    /// </summary>
    public enum ArtBoardMode
    {
        Draw,Overlay,Ref,Theme
    }
}
