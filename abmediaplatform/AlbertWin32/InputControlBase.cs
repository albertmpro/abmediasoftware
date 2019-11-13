﻿using System;
using System.Globalization;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;

namespace Albert.Win32
{
    /// <summary>
    /// Base Class for Input Controls 
    /// </summary>
    public abstract class InputControlBase: Control
    {

        #region Properties

        #region AllowTextInput

        public static readonly DependencyProperty AllowTextInputProperty = DependencyProperty.Register("AllowTextInput", typeof(bool), typeof(InputControlBase), new UIPropertyMetadata(true, OnAllowTextInputChanged));
        public bool AllowTextInput
        {
            get
            {
                return (bool)GetValue(AllowTextInputProperty);
            }
            set
            {
                SetValue(AllowTextInputProperty, value);
            }
        }

        private static void OnAllowTextInputChanged(DependencyObject o, DependencyPropertyChangedEventArgs e)
        {
            InputControlBase inputBase = o as InputControlBase;
            if (inputBase != null)
                inputBase.OnAllowTextInputChanged((bool)e.OldValue, (bool)e.NewValue);
        }

        protected virtual void OnAllowTextInputChanged(bool oldValue, bool newValue)
        {
        }

        #endregion //AllowTextInput

        #region CultureInfo

        public static readonly DependencyProperty CultureInfoProperty = DependencyProperty.Register("CultureInfo", typeof(CultureInfo), typeof(InputControlBase), new UIPropertyMetadata(CultureInfo.CurrentCulture, OnCultureInfoChanged));
        public CultureInfo CultureInfo
        {
            get
            {
                return (CultureInfo)GetValue(CultureInfoProperty);
            }
            set
            {
                SetValue(CultureInfoProperty, value);
            }
        }

        private static void OnCultureInfoChanged(DependencyObject o, DependencyPropertyChangedEventArgs e)
        {
            InputControlBase inputBase = o as InputControlBase;
            if (inputBase != null)
                inputBase.OnCultureInfoChanged((CultureInfo)e.OldValue, (CultureInfo)e.NewValue);
        }

        protected virtual void OnCultureInfoChanged(CultureInfo oldValue, CultureInfo newValue)
        {

        }

        #endregion //CultureInfo

        #region IsReadOnly

        public static readonly DependencyProperty IsReadOnlyProperty = DependencyProperty.Register("IsReadOnly", typeof(bool), typeof(InputControlBase), new UIPropertyMetadata(false, OnReadOnlyChanged));
        public bool IsReadOnly
        {
            get
            {
                return (bool)GetValue(IsReadOnlyProperty);
            }
            set
            {
                SetValue(IsReadOnlyProperty, value);
            }
        }

        private static void OnReadOnlyChanged(DependencyObject o, DependencyPropertyChangedEventArgs e)
        {
            InputControlBase inputBase = o as InputControlBase;
            if (inputBase != null)
                inputBase.OnReadOnlyChanged((bool)e.OldValue, (bool)e.NewValue);
        }

        protected virtual void OnReadOnlyChanged(bool oldValue, bool newValue)
        {
        }

        #endregion //IsReadOnly

        #region IsUndoEnabled

        public static readonly DependencyProperty IsUndoEnabledProperty = DependencyProperty.Register("IsUndoEnabled", typeof(bool), typeof(InputControlBase), new UIPropertyMetadata(true, OnIsUndoEnabledChanged));
        public bool IsUndoEnabled
        {
            get
            {
                return (bool)GetValue(IsUndoEnabledProperty);
            }
            set
            {
                SetValue(IsUndoEnabledProperty, value);
            }
        }

        private static void OnIsUndoEnabledChanged(DependencyObject o, DependencyPropertyChangedEventArgs e)
        {
            InputControlBase inputBase = o as InputControlBase;
            if (inputBase != null)
                inputBase.OnIsUndoEnabledChanged((bool)e.OldValue, (bool)e.NewValue);
        }

        protected virtual void OnIsUndoEnabledChanged(bool oldValue, bool newValue)
        {
        }

        #endregion //IsUndoEnabled

        #region Text

        public static readonly DependencyProperty TextProperty = DependencyProperty.Register("Text", typeof(string), typeof(InputControlBase), new FrameworkPropertyMetadata(default(String), FrameworkPropertyMetadataOptions.BindsTwoWayByDefault, OnTextChanged, null, false, UpdateSourceTrigger.LostFocus));
        public string Text
        {
            get
            {
                return (string)GetValue(TextProperty);
            }
            set
            {
                SetValue(TextProperty, value);
            }
        }

        private static void OnTextChanged(DependencyObject o, DependencyPropertyChangedEventArgs e)
        {
            InputControlBase inputBase = o as InputControlBase;
            if (inputBase != null)
                inputBase.OnTextChanged((string)e.OldValue, (string)e.NewValue);
        }

        protected virtual void OnTextChanged(string oldValue, string newValue)
        {

        }

        #endregion //Text

        #region TextAlignment

        public static readonly DependencyProperty TextAlignmentProperty = DependencyProperty.Register("TextAlignment", typeof(TextAlignment), typeof(InputControlBase), new UIPropertyMetadata(TextAlignment.Left));
        public TextAlignment TextAlignment
        {
            get
            {
                return (TextAlignment)GetValue(TextAlignmentProperty);
            }
            set
            {
                SetValue(TextAlignmentProperty, value);
            }
        }


        #endregion //TextAlignment

        #region Watermark

        public static readonly DependencyProperty WatermarkProperty = DependencyProperty.Register("Watermark", typeof(object), typeof(InputControlBase), new UIPropertyMetadata(null));
        public object Watermark
        {
            get
            {
                return (object)GetValue(WatermarkProperty);
            }
            set
            {
                SetValue(WatermarkProperty, value);
            }
        }

        #endregion //Watermark

        #region WatermarkTemplate

        public static readonly DependencyProperty WatermarkTemplateProperty = DependencyProperty.Register("WatermarkTemplate", typeof(DataTemplate), typeof(InputControlBase), new UIPropertyMetadata(null));
        public DataTemplate WatermarkTemplate
        {
            get
            {
                return (DataTemplate)GetValue(WatermarkTemplateProperty);
            }
            set
            {
                SetValue(WatermarkTemplateProperty, value);
            }
        }

        #endregion //WatermarkTemplate

        #endregion //Properties

    }
}
