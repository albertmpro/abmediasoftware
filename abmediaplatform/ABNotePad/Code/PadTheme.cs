using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Media;
using Albert;
using static Albert.Win32.MediaCv;
namespace ABNotePad.Code
{
    /// <summary>
    /// Discribes a 5 color Theme 
    /// </summary>
    public class PadTheme: PropBase
    {
        //Field's 
        Color one, two, three, four, five;

        public PadTheme()
        {
            ColorOne = HexColor("#0000cc");
            ColorTwo = HexColor("#0000ff");
            ColorFour = HexColor("#ffffff");
            ColorFive = HexColor("#000000");
        
        }

        public Color ColorOne
        {
            get => one; 
            set { one = value; OnPropertyChanged("ColorOne"); }
        }
        public Color ColorTwo
        {
            get => two;
            set { two = value; OnPropertyChanged("ColorTwo"); }
        }
        public Color ColorTree
        {
            get => three;
            set { three = value; OnPropertyChanged("ColorThree"); }
        }

        public Color ColorFour
        {
            get => four;
            set { four = value; OnPropertyChanged("ColorFour"); }
        }


        public Color ColorFive
        {
            get => five;
            set { five = value; OnPropertyChanged("ColorFive"); }
        }
    }
}
