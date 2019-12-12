using System;
using System.Collections.Generic;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Media;
using Albert.Win32;
using static Albert.Win32.MediaCv;
namespace Albert.Win32.Controls
{
    [TemplatePart(Name = "PART_Canvas",Type = typeof(Canvas))]
    [TemplatePart(Name = "PART_ATextBox", Type = typeof(TextBox))]
    [TemplatePart(Name = "PART_RTextBox", Type = typeof(TextBox))]
    [TemplatePart(Name = "PART_GTextBox", Type = typeof(TextBox))]
    [TemplatePart(Name = "PART_BTextBox", Type = typeof(TextBox))]
    [TemplatePart(Name = "PART_ASlider", Type = typeof(Slider))]
    [TemplatePart(Name = "PART_RSlider", Type = typeof(Slider))]
    [TemplatePart(Name = "PART_GSlider", Type = typeof(Slider))]
    [TemplatePart(Name = "PART_BSlider", Type = typeof(Slider))]
    [TemplatePart(Name = "PART_HexTextBox", Type = typeof(TextBox))]
    /// <summary>
    /// My take on the Color Picker 
    /// </summary>
    public class ColorPicker:Control
    {
        #region Field's 
        Canvas canvas = new Canvas();
        TextBox txtHex = new TextBox();
        TextBox txtA = new TextBox();
        TextBox txtR = new TextBox();
        TextBox txtG = new TextBox();
        TextBox txtB = new TextBox();
        Slider aSlider = new Slider();
        Slider rSlider = new Slider();
        Slider gSlider = new Slider();
        Slider bSlider = new Slider();


        #endregion

        #region Depedency Properties 

        private static readonly DependencyProperty ColorProperty = DP("Color",typeof(Color),typeof(ColorPicker));

        private static readonly DependencyProperty HexValueProperty = DP("HexValue", typeof(string), typeof(ColorPicker));



        #endregion 

        #region Constructor and Overrides 
        public ColorPicker()
        {
            DefaultStyleKey = typeof(ColorPicker);
        }

        public override void OnApplyTemplate()
        {
            base.OnApplyTemplate();

            //Get the Template Parts 
            canvas = GetTemplateChild("PART_Canvas") as Canvas;
            txtA = GetTemplateChild("PART_ATextBox")as TextBox;
            txtR = GetTemplateChild("PART_RTextBox") as TextBox;
            txtG = GetTemplateChild("PART_GTextBox") as TextBox;
            txtB = GetTemplateChild("PART_BTextBox") as TextBox;
            aSlider = GetTemplateChild("PART_ASlider") as Slider;
            rSlider = GetTemplateChild("PART_RSlider") as Slider;
            gSlider = GetTemplateChild("PART_GSlider") as Slider;
            bSlider = GetTemplateChild("PART_BSlider") as Slider;
            txtHex = GetTemplateChild("PART_HexTextBox") as TextBox;


        }

        #endregion

        #region Method's 

        void UpdateColor()
        {

        }

        #endregion

        #region Properties 

        #endregion
    }
}
