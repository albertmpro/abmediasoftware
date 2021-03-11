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
using ABNotePad.Code;
using ABNotePad.Code.Controls;
using Albert.Win32.Controls;

namespace ABNotePad.View
{
    /// <summary>
    /// Interaction logic for NotesTakenView.xaml
    /// </summary>
    public partial class NotesTakenView : PadView
    {
        public NotesTakenView(TabControl _tab)
        {
            InitializeComponent();
            SetupTab("Notes Taken", true, _tab);
        }
        public NotesTakenView(TabControl _tab,string _name)
        {
            InitializeComponent();
            SetupTab("Notes Taken", true, _tab);
            switch(_name)
            {
                case "Notes":
                    tabNotesTaken.SelectedIndex = 0;
                    break;
                case "UsedColors":
                    tabNotesTaken.SelectedIndex = 1;
                    break;
            }
        }


        void Note_Click(object sender, RoutedEventArgs e)
        {
            PushButton push = sender as PushButton;

            switch (push.Tag)
            {
                case "Add":
                    string str = txtEdit?.Text;
                    VM.Notes.Add(str);
                    break;
                case "Reomove":
                    string item = (string)lstNotesTaken.SelectedItem;
                    VM.Notes.Remove(item);
                    break;
                case "Clear":
                    TabDialog.Show("Clear Notes","Do you want to clear notes","Clear","Cancel",()=> 
                        {
                            //Clear your notes 
                            VM.Notes.Clear();
                        
                        });
                    break;
            }
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
                        PadColor removeitem = (PadColor)lstColor?.SelectedItem;
                        VM.UsedColors.Remove(removeitem);
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

        void Artboard_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                double width = Convert.ToDouble(txtWidth.Text);
                double height = Convert.ToDouble(txtHeight.Text);
                //Add to the List 
                VM.DrawSizes.Add(new PadDrawSize(width, height));


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

        private void lstNotesTaken_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if(lstNotesTaken.SelectedItem != null)
            {
                string item = (string)lstNotesTaken.SelectedItem;

                txtEdit.Text = item;
            }
        }
    }
}
