﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using ABHub.Code.Controls;
namespace ABHub.View
{
    /// <summary>
    /// Interaction logic for ConceptDesignView.xaml
    /// </summary>
    public partial class ConceptDesignView : HubView
    {
        public ConceptDesignView(TabControl _tab)
        {
            InitializeComponent();
            SetupTab("CP", false, _tab);
            TabItem.ToolTip = "Concept Properites";
        }
    }
}
