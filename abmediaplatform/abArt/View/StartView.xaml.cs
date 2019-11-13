﻿using System;
using System.Collections.Generic;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using abArt.Controls;
namespace abArt.View
{
    /// <summary>
    /// Interaction logic for StartView.xaml
    /// </summary>
    public partial class StartView : ArtView
    {

        
        public StartView(TabControl _tab)
        {
            InitializeComponent();

            //Create the Tab 
            SetupTab("StartPage", false, _tab);

        }
    }
}
