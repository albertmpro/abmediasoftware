using System;
using System.Collections.Generic;
using System.Text;
using System.Windows;
using System.Windows.Shapes;
using System.Windows.Media;
using System.Windows.Controls;
using Albert.Win32;
using System.Windows.Ink;
using static Albert.Win32.MediaCv;
using System.ComponentModel;
using System.Windows.Input;

namespace Albert.Win32.Controls
{
    /// <summary>
    /// Modified InkCanvas for doing more realistic art work
    /// </summary>
    public class DrawCanvas : InkCanvas, IAddCommand
    {

      

        #region Depedency Properties 

        public static readonly DependencyProperty DrawModeProperty = DP("DrawMode", typeof(DrawMode), typeof(DrawCanvas), DrawMode.Draw);

        public static readonly DependencyProperty BrushColorProperty = DP("BrushColor", typeof(Color), typeof(DrawCanvas), Colors.Black);

        public static readonly DependencyProperty BrushSizeProperty = DP("BrushSize", typeof(double), typeof(DrawCanvas), 10.4, (sender, e) =>
            {
                var board = (DrawCanvas)sender;
                board.DefaultDrawingAttributes.Width = (double)e.NewValue;
                board.DefaultDrawingAttributes.Height = (double)e.NewValue;
            });

        public static readonly DependencyProperty StylusTipProperty = DP("StylusTip", typeof(StylusTip), typeof(DrawCanvas), StylusTip.Ellipse, (sender, e) =>
            {
                var board = sender as DrawCanvas;

                //Link to StylusTip 
                board.DefaultDrawingAttributes.StylusTip = (StylusTip)e.NewValue;

            });

        public static readonly DependencyProperty BrushOpacityProperty = DP("BrushOpacity", typeof(byte), typeof(DrawCanvas));


        protected override void OnPropertyChanged(DependencyPropertyChangedEventArgs e)
        {
            //Get the Brush Opacity  
            var alpha = BrushOpacity;
            //Color 
            var color = BrushColor;
        
            //Set the color based on opacity 
            var setcolor = Color.FromArgb(alpha, color.R, color.G, color.B);
            //Set Bursh Color on Artboard 
            DefaultDrawingAttributes.Color = setcolor;
            //Set the Brush Color 
            BrushColor = setcolor;

            base.OnPropertyChanged(e);
        }





        #endregion

        #region Constuctor  
        /// <summary>
        /// Default Constructor 
        /// </summary>
        public DrawCanvas()
        {
            BrushOpacity = 75;







        }
        #endregion

        #region Method's and Tuple's 




        #endregion

        #region Public Properties 

        /// <summary>
        /// Get or set the Current DrawMode 
        /// </summary>
        public DrawMode DrawMode
        {
            get { return (DrawMode)GetValue(DrawModeProperty); }
            set
            {
                SetValue(DrawModeProperty, value);

                switch (value)
                {
                    case DrawMode.Draw:
                        EditingMode = InkCanvasEditingMode.Ink;
                        break;
                    case DrawMode.Erase:
                        EditingMode = InkCanvasEditingMode.EraseByPoint;
                        break;
                    case DrawMode.EraseByStroke:
                        EditingMode = InkCanvasEditingMode.EraseByStroke;
                        break;
                    case DrawMode.Select:
                        EditingMode = InkCanvasEditingMode.Select;
                        break;
                    case DrawMode.Rectangle:
                        EditingMode = InkCanvasEditingMode.None;
                        break;
                    case DrawMode.Circle:
                        EditingMode = InkCanvasEditingMode.None;
                        break;
                }
            }
        }

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
        [Category("Common")]
        public double BrushSize
        {
            get { return (double)GetValue(BrushSizeProperty); }
            set { SetValue(BrushSizeProperty, value); }
        }
        /// <summary>
        /// Get or set Brush Color that drawing with 
        /// </summary>
        [Category("Common")]
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

        /// <summary>
        /// Add a Command Quickly 
        /// </summary>
        /// <param name="_command"></param>
        /// <param name="_method"></param>
        public void AddCommand(ICommand _command, ExecutedRoutedEventHandler _method)
        {
            CommandBindings.Add(new CommandBinding(_command, _method));
        }






        #endregion

    }

    public enum DrawMode
    {
        Draw, Erase, EraseByStroke, Select, Rectangle, Circle, Line
    }


}
