using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Ink;
using System.Windows.Media;
using System.ComponentModel;
using System.Windows.Input;
using static Albert.Win32.MediaCv;
namespace Albert.Win32.Controls
{
    /// <summary>
    /// A Control desgined to draw out Concepts with colors 
    /// </summary>
    [TemplatePart(Name = "PART_DrawCanvas", Type = typeof(DrawCanvas))]
    [TemplatePart(Name = "PART_PrimaryButton", Type = typeof(OptionButton))]
    [TemplatePart(Name = "PART_SecondaryButton", Type = typeof(OptionButton))]
    [TemplatePart(Name = "PART_Accent1Button", Type = typeof(OptionButton))]
    [TemplatePart(Name = "PART_Accent2Button", Type = typeof(OptionButton))]
    [TemplatePart(Name = "PART_Accent3Button", Type = typeof(OptionButton))]
    public class ConceptControl : Control, IAddCommand
    {

        #region Field's 
        DrawCanvas canvas = new DrawCanvas();
        OptionButton primary = new OptionButton();
        OptionButton secondary = new OptionButton();
        OptionButton accent1 = new OptionButton();
        OptionButton accent2 = new OptionButton();
        OptionButton accent3 = new OptionButton();

        #endregion

        #region Dependency Properites 

        public static readonly DependencyProperty DrawModeProperty = DP("DrawMode", typeof(DrawMode), typeof(ConceptControl), DrawMode.Draw);

        public static readonly DependencyProperty BrushColorProperty = DP("BrushColor", typeof(Color), typeof(ConceptControl), Colors.Black, (sender, e) =>
        {
            ConceptControl concept = (ConceptControl)sender;
            concept.canvas.BrushColor = (Color)e.NewValue;

        });

        public static readonly DependencyProperty PrimaryIsCheckedProperty = DP("PrimaryIsChecked", typeof(bool), typeof(ConceptControl), true);

        public static readonly DependencyProperty SecondaryIsCheckedProperty = DP("SecondaryIsChecked", typeof(bool), typeof(ConceptControl), false);

        public static readonly DependencyProperty AccentIsCheckedOneProperty = DP("AccentIsCheckedOne", typeof(bool), typeof(ConceptControl), false);

        public static readonly DependencyProperty AccentIsCheckedTwoProperty = DP("AccentIsCheckedTwo", typeof(bool), typeof(ConceptControl), false);

        public static readonly DependencyProperty AccentIsCheckedThreeProperty = DP("AccentIsCheckedThree", typeof(bool), typeof(ConceptControl), false);

        public static readonly DependencyProperty PrimaryColorProperty = DP("PrimaryColor", typeof(SolidColorBrush), typeof(ConceptControl), Brushes.Black);

        public static readonly DependencyProperty SecondaryColorProperty = DP("SecondaryColor", typeof(SolidColorBrush), typeof(ConceptControl), Brushes.White);

        public static readonly DependencyProperty AccentColorOneProperty = DP("AccentColorOne", typeof(SolidColorBrush), typeof(ConceptControl), Brushes.DarkRed);

        public static readonly DependencyProperty AccentColorTwoProperty = DP("AccentColorTwo", typeof(SolidColorBrush), typeof(ConceptControl), Brushes.Red);

        public static readonly DependencyProperty AccentColorThreeProperty = DP("AccentColorThree", typeof(SolidColorBrush), typeof(ConceptControl), Brushes.OrangeRed);


        public static readonly DependencyProperty DrawingAttributesProperty = DP("DrawingAttributes", typeof(DrawingAttributes), typeof(ConceptControl), (sender,e)=>
        {
            ConceptControl concept = sender as ConceptControl;
            concept.canvas.DefaultDrawingAttributes = (DrawingAttributes)e.NewValue;
        
        });

        public static readonly DependencyProperty BrushSizeProperty = DP("BrushSize", typeof(double), typeof(ConceptControl), 10.4, (sender, e) =>
        {
            var board = (ConceptControl)sender;
            board.canvas.DefaultDrawingAttributes.Width = (double)e.NewValue;
            board.canvas.DefaultDrawingAttributes.Height = (double)e.NewValue;
        });

        public static readonly DependencyProperty StylusTipProperty = DP("StylusTip", typeof(StylusTip), typeof(ConceptControl), StylusTip.Ellipse, (sender, e) =>
        {
            var board = sender as ConceptControl;

            //Link to StylusTip 
            board.canvas.DefaultDrawingAttributes.StylusTip = (StylusTip)e.NewValue;

        });

        public static readonly DependencyProperty BrushOpacityProperty = DP("BrushOpacity", typeof(byte), typeof(ConceptControl), (sender, e) => 
        {
            ConceptControl concept = (ConceptControl)sender;
            concept.canvas.BrushOpacity = (byte)e.NewValue;
        
        });

        public static readonly DependencyProperty CanvasProperty = DP("Canvas", typeof(DrawCanvas), typeof(ConceptControl), (sender, e) =>
        {
            ConceptControl concept = (ConceptControl)sender;
            concept.canvas = (DrawCanvas)e.NewValue;
        });










        #endregion

        #region Constructor  

        public ConceptControl()
        {
            //ReDraw the Control 
            DefaultStyleKey = typeof(ConceptControl);

        }

        public override void OnApplyTemplate()
        {
            canvas = (DrawCanvas)GetTemplateChild("PART_DrawCanvas");
            primary = (OptionButton)GetTemplateChild("PART_PrimaryButton");
            secondary = (OptionButton)GetTemplateChild("PART_SecondaryButton");
            accent1 = (OptionButton)GetTemplateChild("PART_Accent1Button");
            accent2 = (OptionButton)GetTemplateChild("PART_Accent2Button");
            accent3 = (OptionButton)GetTemplateChild("PART_Accent3Button");
        }

        protected override void OnPropertyChanged(DependencyPropertyChangedEventArgs e)
        {
            //Get the Brush Opacity  
            var alpha = BrushOpacity;
            //Color 
            var color = BrushColor;

            //Set the color based on opacity 
            var setcolor = Color.FromArgb(alpha, color.R, color.G, color.B);
            //Set Bursh Color on Artboard 
            canvas.DefaultDrawingAttributes.Color = setcolor;
            //Set the Brush Color 
            BrushColor = setcolor;

            //Set the colors 
     

            if (primary != null)
            {
                primary.Click += Option_Click; 
                primary.Background = PrimaryColor;
                primary.BackgroundChecked = PrimaryColor;
            }
            if (secondary != null)
            {
                secondary.Click += Option_Click;
                secondary.Background = SecondaryColor;
                secondary.BackgroundChecked = SecondaryColor;
            }
            if (accent1 != null)
            {
                accent1.Click += Option_Click;
                accent1.Background = AccentColorOne;
                accent1.BackgroundChecked = AccentColorOne;
            }
            if (accent2 != null)
            {
                accent2.Click += Option_Click;
                accent2.Background = AccentColorTwo;
                accent2.BackgroundChecked = AccentColorTwo;
            }
            if (accent3 != null)
            {
                accent3.Click += Option_Click;
                accent3.Background = AccentColorThree;
                accent3.BackgroundChecked = AccentColorThree;
            }

            base.OnPropertyChanged(e);
        }

        void Option_Click(object sender, RoutedEventArgs e)
        {
            OptionButton opt = sender as OptionButton;
            if (canvas != null)
            {
                SolidColorBrush brush = (SolidColorBrush)opt.Background;
                BrushColor = brush.Color;
            }

        }


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
                        canvas.EditingMode = InkCanvasEditingMode.Ink;
                        break;
                    case DrawMode.Erase:
                        canvas.EditingMode = InkCanvasEditingMode.EraseByPoint;
                        break;
                    case DrawMode.EraseByStroke:
                        canvas.EditingMode = InkCanvasEditingMode.EraseByStroke;
                        break;
                    case DrawMode.Select:
                        canvas.EditingMode = InkCanvasEditingMode.Select;
                        break;
                    case DrawMode.Rectangle:
                        canvas.EditingMode = InkCanvasEditingMode.None;
                        break;
                    case DrawMode.Circle:
                        canvas.EditingMode = InkCanvasEditingMode.None;
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



        public DrawingAttributes DrawingAttributes
        {
            get { return (DrawingAttributes)GetValue(DrawingAttributesProperty); }
            set { SetValue(DrawingAttributesProperty, value); }
        }

        public DrawCanvas Canvas
        {
            get { return (DrawCanvas)GetValue(CanvasProperty); }
            set { SetValue(CanvasProperty, value); }
        }

        public SolidColorBrush PrimaryColor
        {
            get { return (SolidColorBrush)GetValue(PrimaryColorProperty); }
            set { SetValue(PrimaryColorProperty, value); }
        }
        public SolidColorBrush SecondaryColor 
        {
            get { return (SolidColorBrush)GetValue(SecondaryColorProperty); }
            set { SetValue(SecondaryColorProperty, value); }
        }
        public SolidColorBrush AccentColorOne
        {
            get { return (SolidColorBrush)GetValue(AccentColorOneProperty); }
            set { SetValue(AccentColorOneProperty, value); }
        }
        public SolidColorBrush AccentColorTwo
        {
            get { return (SolidColorBrush)GetValue(AccentColorTwoProperty); }
            set { SetValue(AccentColorTwoProperty, value); }
        }
        public SolidColorBrush AccentColorThree
        {
            get { return (SolidColorBrush)GetValue(AccentColorThreeProperty); }
            set { SetValue(AccentColorThreeProperty, value); }
        }
        public bool PrimaryIsChecked
        {
            get { return (bool)GetValue(PrimaryIsCheckedProperty); }
            set { SetValue(PrimaryIsCheckedProperty,value); }
        }
        public bool SecondaryIsChecked
        {
            get { return (bool)GetValue(SecondaryIsCheckedProperty); }
            set { SetValue(SecondaryIsCheckedProperty, value); }
        }
        public bool AccentIsCheckedOne
        {
            get { return (bool)GetValue(AccentIsCheckedOneProperty); }
            set { SetValue(AccentIsCheckedOneProperty, value); }
        }
        public bool AccentIsCheckedTwo
        {
            get { return (bool)GetValue(AccentIsCheckedTwoProperty); }
            set { SetValue(AccentIsCheckedTwoProperty, value); }
        }
        public bool AccentIsCheckedThree
        {
            get { return (bool)GetValue(AccentIsCheckedThreeProperty); }
            set { SetValue(AccentIsCheckedThreeProperty, value); }
        }



        #endregion


        public void AddCommand(ICommand _command, ExecutedRoutedEventHandler _method)
        {
            CommandBindings.Add(new CommandBinding(_command, _method));
        }
    }
}
