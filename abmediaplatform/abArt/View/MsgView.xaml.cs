using System;
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
using tk = Xceed.Wpf.Toolkit;
using abArt.Controls;
namespace abArt.View
{
    /// <summary>
    /// Interaction logic for MsgView.xaml
    /// </summary>
    public partial class MsgView : ArtView
    {
        #region Field's 
        MsgType msgtype;
        #endregion

        public MsgView(TabControl _tab)
        {
            InitializeComponent();

            //Setup your TabItem 
            SetupTab($"Msg{Count++}", _tab, close);
        }

        void close()
        {
            
        }


        #region Public Properties 

        /// <summary>
        /// Get or set the Message Type being created 
        /// </summary>
        public MsgType MsgType
        {
            get => msgtype;
            set
            {
                msgtype = value;

                switch(value)
                {
                    case MsgType.Normal:

                        break;
                    case MsgType.Rich:

                        break;
                    case MsgType.ImgTop:

                        break;
                    case MsgType.ImgCenter:

                        break;
                    case MsgType.ImgBotttom:

                        break;
                }
            }
        }

        #endregion




    }
}
