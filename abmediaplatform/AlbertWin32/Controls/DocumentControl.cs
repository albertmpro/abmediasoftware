﻿using System;
using System.IO;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;
using System.ComponentModel;
namespace Albert.Win32.Controls
{
	/// <summary>
	/// A special ContentControl designed to deal with handling tab documents. 
	/// </summary>
	public class DocumentControl : ContentControl, IAddCommand, ICurrentFile
	{
        #region Depedency Properties
        public static DependencyProperty TopDialogBarProperty = DependencyProperty.Register("TopDialogBar", typeof(object),typeof(DocumentControl),null);
        public static DependencyProperty BottomDialogBarProperty = DependencyProperty.Register("BottomDialogBar", typeof(object), typeof(DocumentControl), null);
        public static DependencyProperty TopDialogVisibilityProperty = DependencyProperty.Register("TopDialogVisibility", typeof(Visibility), typeof(DocumentControl), new PropertyMetadata(Visibility.Visible));
        public static DependencyProperty BottomDialogVisibilityProperty = DependencyProperty.Register("BottomDialogVisibility", typeof(Visibility), typeof(DocumentControl), new PropertyMetadata(Visibility.Visible));
        
        #endregion
        public DocumentControl()
		{
            //ReDraw the Control 
            DefaultStyleKey = typeof(DocumentControl);
            //Do the Logic Method 
            Logic();
	    }

        void Logic()
        {
            //Run the OnLogic Function 
            OnLogic();
        }

        #region Method's for Creating Tab's Quickly
        /// <summary>
        /// Method to Quickly Setup TabItem 
        /// </summary>
        /// <param name="_header"></param>
        /// <param name="_isClosedEnabled"></param>
        /// <param name="_tab"></param>
        public void SetupTab(string _header,bool _isClosedEnabled,TabControl _tab)
        {
            //Create a new TabItem 
            TabItem = new DocumentTabItem(_header, _isClosedEnabled , this, _tab);

        }
        /// <summary>
        /// Load File and Setup TabMethod 
        /// </summary>
        /// <param name="_tab">TabItem</param>
        /// <param name="_fileName">FileName</param>
        /// <param name="__method">Close Method</param>
        public void SetupTabAndLoadFile(TabControl _tab,FileInfo _info,Action __method)
        {
            FileInfo = _info;
            FileLocation = _info.FullName;

            //Create a new TabItem 
            TabItem = new DocumentTabItem(_info.Name, this, _tab);

            //Close Method 
            TabItem.Closed += (sender, e) =>
            {
                __method?.Invoke();
            };

            //Focus on the Tab 
            TabItem.Focus();
            this.Focus();
        }


        public void SetupTab(string _header,TabControl _tab,Action _closeMethod)
        {
            //Create a new TabItem 
            TabItem = new DocumentTabItem(_header, this, _tab);

            //Close Method 
            TabItem.Closed += (sender, e) =>
            {
                _closeMethod.Invoke();
            };

            //Focus on the Tab 
            TabItem.Focus();
            this.Focus();

        }

        #endregion


        #region Method from IAddCommand 

        /// <summary>
        /// Quick way to add a Coomamand to the control
        /// </summary>
        /// <param name="_command"></param>
        /// <param name="_method"></param>
        public void AddCommand(ICommand _command, ExecutedRoutedEventHandler _method)
		{
			CommandBindings.Add(new CommandBinding(_command, _method));
		}

        #endregion


        #region Override  Method's 
        /// <summary>
        /// Override method for creating logic or the applicaton 
        /// </summary>
        public virtual void OnLogic()
        {
            //Do nothing for now 
        }
        
        /// <summary>
        /// Ovveride method for Closing a TabItem 
        /// </summary>
        public virtual void OnTabClose()
        {
            // Do nothing for now 
        }

        #endregion



        #region Main Public Properties

        public object TopDialogBar
        {
            get { return (object)GetValue(TopDialogBarProperty); }
            set { SetValue(TopDialogBarProperty, value); }
        }

        public object BottomDialogBar
        {
            get { return (object)GetValue(BottomDialogBarProperty); }
            set { SetValue(BottomDialogBarProperty, value); }
        }

        public object TopDialogVisibility
        {
            get { return (Visibility)GetValue(TopDialogVisibilityProperty); }
            set { SetValue(TopDialogVisibilityProperty, value); }
        }


        public Visibility BottomDialogVisibility
        {
            get { return (Visibility)GetValue(BottomDialogVisibilityProperty); }
            set { SetValue(BottomDialogVisibilityProperty, value); }
        }

        /// <summary>
        /// Gets or sets a Page that ueses the DocumentControl
        /// </sBoxummary>
        public Page Page { get; set; }

        /// <summary>
        /// Gets or sets the TabItem that uses the DocumentControl 
        /// </summary>
        public DocumentTabItem TabItem { get; set; }


        /// <summary>
        /// Gets or sets the TabControl that uses the DocumentControl 
        /// </summary>
        public TabControl MainTabControl { get; set; }

        public string FileLocation { get; set; }

		public FileInfo FileInfo { get; set; }
        /// <summary>
        /// Get or sets the Number of documents created 
        /// </summary>
        public static int Count { get; set; } = 1;

        #endregion


    }
}
