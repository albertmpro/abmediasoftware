using System;
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
using Albert.Win32.Controls;
namespace ABNotePad.Code.Controls
{
    /// <summary>
    /// Interaction logic for UsedColors.xaml
    /// </summary>
    public partial class UsedColors : PadView
    {
        public UsedColors()
        {
            InitializeComponent();
        }
        void Color_Click(object sender, RoutedEventArgs e)
        {
            PushButton push = sender as PushButton;

            switch (push.Tag)
            {
                case "Add":
                    Color item = colorPicker.SelectedColor;
                    VM.UsedColors.Add(new PadColor(item.ToString()));
                    break;
                case "Remove":
                    if (lstColor.SelectedItem != null)
                    {
                        foreach (PadColor color in lstColor.SelectedItems)
                        {
                            lstColor.Items.Remove(color);
                        }
                        
                    }
                    break;
                case "Clear":
                    TabDialog.Show("Clear Color", "Do you want to clear your Colors?", "Clear", "Cancel", () =>
                    {
                        //Clear your notes 
                        VM.UsedColors.Clear();

                    });
                    break;
            }
        }
    }
}
