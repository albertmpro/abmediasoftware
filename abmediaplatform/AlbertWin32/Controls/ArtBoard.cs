using System;
using System.Collections.Generic;
using System.Text;
using System.Windows;
using System.Windows.Media;
using System.Windows.Controls;
using Albert.Win32;
using System.Windows.Ink;
using static Albert.Win32.MediaCv;
using System.ComponentModel;

namespace Albert.Win32.Controls
{
    /// <summary>
    /// Modified InkCanvas for doing more realistic art work
    /// </summary>
    public class ArtBoard : InkCanvas
    {
       

        #region Depedency Properties 


        private static readonly DependencyProperty BrushColorProperty = DP("BrushColor", typeof(Color), typeof(ArtBoard),Colors.Black, (sender, e) =>
               {
                   var canvas = (ArtBoard)sender;
               //Get the Brush Opacity  
               var alpha = canvas.BrushOpacity;
               //Get the Value of the Color 
               var color = (Color)e.NewValue;
               //Set the color based on opacity 
               var setcolor = Color.FromArgb(alpha, color.R, color.G, color.B);
               //Set Bursh Color on Artboard 
               canvas.DefaultDrawingAttributes.Color = setcolor;


               });

        private static readonly DependencyProperty BrushSizeProperty = DP("BrushSize", typeof(double), typeof(ArtBoard),10.4, (sender, e) =>
           {
               var board = (ArtBoard)sender;
               board.DefaultDrawingAttributes.Width = (double)e.NewValue;
               board.DefaultDrawingAttributes.Height = (double)e.NewValue;
           });

        private static readonly DependencyProperty StylusTipProperty = DP("StylusTip", typeof(StylusTip), typeof(ArtBoard),StylusTip.Ellipse, (sender, e) =>
           {
               var board = sender as ArtBoard;

               //Link to StylusTip 
               board.DefaultDrawingAttributes.StylusTip = (StylusTip)e.NewValue;

           });

        private static readonly DependencyProperty BrushOpacityProperty = DP("BrushOpacity", typeof(byte), typeof(ArtBoard));




        #endregion

        #region Constuctor  
        /// <summary>
        /// Default Constructor 
        /// </summary>
        public ArtBoard()
        {
            BrushOpacity = 75;
        }
        #endregion

        #region Method's and Tuple's 

        #endregion

        #region Public Properties 
        /// <summary>
        /// Gets or set Brush Opacity based on the ARGB scale 
        /// </summary>
        [Category("AB Common")]
        public byte BrushOpacity
        {
            get { return (byte)GetValue(BrushOpacityProperty); }
            set { SetValue(BrushOpacityProperty, value); }
        }
        /// <summary>
        /// Get or set the BrushSize that your drawing with 
        /// </summary>
        [Category("AB Common")]
        public double BrushSize
        {
            get { return (double)GetValue(BrushSizeProperty); }
            set { SetValue(BrushSizeProperty, value); }
        }
        /// <summary>
        /// Get or set Brush Color that drawing with 
        /// </summary>
        [Category("AB Common")]
        public Color BrushColor
        {
            get { return (Color)GetValue(BrushColorProperty); }
            set { SetValue(BrushColorProperty, value); }
        }
        /// <summary>
        /// Get or sets the StylusTip Type 
        /// </summary>
        [Category("AB Common")]
        public StylusTip StylusTip
        {
            get { return (StylusTip)GetValue(StylusTipProperty); }
            set { SetValue(StylusTipProperty, value); }
        }






        #endregion

    }

    public enum BrushPresets
    {
        Pencil, Marker, Pen
    }
}
