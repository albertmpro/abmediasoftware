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
    /// Interaction logic for Artboards.xaml
    /// </summary>
    public partial class Artboards : PadView
    {
        public Artboards()
        {
            InitializeComponent();
        }

        void AddRemoveCancel_Click(object sender, RoutedEventArgs e)
        {
            PushButton push = sender as PushButton; 

            switch(push.Tag)
            {
              
                case "Remove":
                    //Remove Color 
                    PadColor color = (PadColor)lstArtBoard?.SelectedItem;
                    VM.UsedColors.Remove(color);
                    break;
                case "Clear":
                    //Clear the list 
                    TabDialog.Show("Clearing","Do you want clear all your sizes?","Clear","Cancel",()=>
                    {
                        VM.DrawSizes.Clear();
                    });
                    break;
            }

        }
        void Artboard_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                string name = txtName.Text;
                double width = Convert.ToDouble(txtWidth.Text);
                double height = Convert.ToDouble(txtHeight.Text);
                //Add to the List 
                VM.DrawSizes.Add(new PadDrawSize(name,width, height));
                txtName.Text = "";
                txtWidth.Text = "";
                txtHeight.Text = "";

            }
            catch (Exception ex)
            {
                TabDialog.Show("Error", ex.Message, "Ok", "Cancel", () =>
                {
                    txtWidth.Text = "";
                    txtHeight.Text = "";

                });
            }
        }


    }
}
