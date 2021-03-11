using System;
using System.Collections.Generic;
using System.IO;
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
using ABHub.Code;
using ABHub.Code.Controls;
using Albert.Win32;
using Albert.Win32.Controls;
using static Albert.Win32.MediaCv;
using static Albert.Win32.Win32IO;
using Microsoft.Win32;
namespace ABHub.View
{
    /// <summary>
    /// View is used to Sketch Draw idea's to be used 
    /// </summary>
    public partial class DrawView : HubView, IHubTabInit
    {

        ArtBoardState state;
        ColumnDefinition colSplit, colArtBoard, colColorPicker, colUsedColors;
        SolidColorBrush BackBrush = new SolidColorBrush(HexColor("#CCCCCCC"));
        public DrawView(TabControl _tab)
        {
            InitializeComponent();
            //Setup Tab 
            SetupTab($"Drawing{Count++}", _tab, Close);
            //Init Method's 
            Init();
        }

        public DrawView(TabControl _tab, FileInfo _info)
        {
            InitializeComponent();

            //Setup Tab 
            SetupTab(_info.Name, _tab, Close);


            // Init Method 
            Init();

            //Load Drawing to Draw Canvas 
            LoadInkStrokes(drawCanvas, _info.FullName);

        }

        private void cmbState_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (cmbState.SelectedItem != null)
            {
                HubItem item = (HubItem)cmbState.SelectedItem;

                switch (item.Name)
                {
                    case "ArtBoardLeft":
                        State = ArtBoardState.ArtboardLeft;
                        break;
                    case "ArtBoardRight":
                        State = ArtBoardState.ArtBoardRight;
                        break;
                    case "PaintSplitLeft":
                        State = ArtBoardState.PaintSplitLeft;
                        break;
                    case "PaintSplitRight":
                        State = ArtBoardState.PaintSplitRight;
                        break;
                    case "Preview":
                        State = ArtBoardState.Preview;
                        break;
                }
            }
        }

        void Select_Click(object sender, RoutedEventArgs e)
        {
            OptionButton opt = sender as OptionButton;

            switch (opt.Tag)
            {
                case "Draw":
                    drawCanvas.DrawMode = DrawMode.Draw;
                    VM.Message("Draw Mode Selected", false);
                    break;
                case "Erase":
                    drawCanvas.DrawMode = DrawMode.Erase;
                    VM.Message("Erase Mode Selected", false);
                    break;
                case "EraseByStroke":
                    drawCanvas.DrawMode = DrawMode.EraseByStroke;
                    VM.Message("Erase by Point Selected", false);
                    break;
                case "Select":
                    drawCanvas.DrawMode = DrawMode.Select;
                    VM.Message("Select mode Selected", false);
                    break;
            }

        }
        void Draw_Click(object sender, RoutedEventArgs e)
        {
            OptionButton opt = sender as OptionButton;

            switch (opt.Tag)
            {
                case "Pencil":
                    drawCanvas.BrushOpacity = 75;
                    VM.Message("Pencil Selected", false);
                    break;
                case "Marker":
                    drawCanvas.BrushOpacity = 125;
                    VM.Message("Marker Selected", false);

                    break;
                case "Pen":
                    drawCanvas.BrushOpacity = 255;
                    VM.Message("Pen Selected", false);
                    break;
            }
        }

        void BrushBack_Click(object sender, RoutedEventArgs e)
        {
            OptionButton opt = sender as OptionButton;

            switch (opt.Tag)
            {
                case "Brush":
                    VM.Message("Brush Selected", false);
                    break;
                case "Back":
                    VM.Message("Background Selected", false);
                    break;
            }

        }
        void Transparent_Clcik(object sender, RoutedEventArgs e)
        {
            if (optTransparent.IsChecked == true)
            {
                drawCanvas.Background = Brushes.Transparent;
          
                VM.Message("Background is Transparent", false);
            }
            else if (optTransparent.IsChecked == false)
            {
                drawCanvas.Background = optBackColor.Background;
              
                VM.Message("Background is not Transparent", false);
            }
        }

        void color_Changed(Color _color)
        {
            SolidColorBrush brush = new SolidColorBrush(_color);

     

            if (optBrushColor.IsChecked == true)
            {
                drawCanvas.BrushColor = _color;
                optBrushColor.Background = brush;
                optBrushColor.BackgroundChecked = brush;
                optBrushColor.BorderBrush = brush;
                VM.Message("Brush Color Changed", false);
            }
            else if (optBackColor.IsChecked == true)
            {
                drawCanvas.Background = brush; ;
                optBackColor.Background = brush;
                optBackColor.BackgroundChecked = brush;
                optBackColor.BorderBrush = brush;
                VM.Message("Background Color Changed", false);
            }

        }

        void lstUsedColors_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (lstUsedColors.SelectedItem != null)
            {
                HubColor item = (HubColor)lstUsedColors.SelectedItem;
                SolidColorBrush brush = new SolidColorBrush(item.Color);
                



                if (optBrushColor.IsChecked == true)
                {
                    drawCanvas.BrushColor = item.Color;
                    optBrushColor.Background = brush;
                    optBrushColor.BackgroundChecked = brush;
                    optBrushColor.BorderBrush = brush;
                    VM.Message("Brush Color Changed", false);
                }
                else if (optBackColor.IsChecked == true)
                {
                    drawCanvas.Background = brush; ;
                    optBackColor.Background = brush;
                    optBackColor.BackgroundChecked = brush;
                    optBackColor.BorderBrush = brush;
                    VM.Message("Background Color Changed", false);
                }
            }

        }

        private void cmbSizes_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (cmbSizes.SelectedItem != null)
            {
                HubDrawSize item = (HubDrawSize)cmbSizes.SelectedItem;
                (double width, double height) = item;

                // Change the Canvas size 
                drawCanvas.Width = width;
                drawCanvas.Height = height;
               
            }
        }

        private void slFontSize_ValueChanged(object sender, RoutedPropertyChangedEventArgs<double> e)
        {
            OnSlideValue(e.NewValue, (v) =>
            {
                drawCanvas.BrushSize = v;
            });
        }

        public void Close()
        {
            TabDialog.Show("Closing", "Do you want close this Artboard?", "Close", "Cancel", () =>
                {
                    RemoveTab();
                });
        }

        public void Init()
        {
            #region Main Grid Oprations  
            //Define Column Defnition's 
            colArtBoard = new ColumnDefinition();
            colColorPicker = new ColumnDefinition();
            colSplit = new ColumnDefinition { MinWidth = 25 };
            colUsedColors = new ColumnDefinition { Width = GridLength.Auto };
            //Clear gridMain 
            gridMain.Children.Clear();
            #endregion

            State = ArtBoardState.ArtboardLeft;



            #region Commands 
            //Title's and Filter Tuple 
            (string saveTitle, string saveasTitle, string exportTitle, string filter, string exfilter) = ("Save ArtBoard", "Save Artboard as", "Export Artboard to image", "AB Artboard Format(.abart)|*.abart", "Png Foormat(.png)|*.png");

            //SaveDialog Method 
            void SaveDialog_Method(SaveFileDialog _dialog, FileInfo _info)
            {
                //Write the Artbaord 
                SaveInkStrokes(drawCanvas, _dialog.FileName);
                //Send message to the APplicaton 
                SetupFileAndTab(_info);
                VM.SavedFileAndLog(_info);
                VM.CurrentFileNames.Add(FileLocation);
            }

            //Save Command 
            AddCommand(ApplicationCommands.Save, (sender, e) =>
             {
                 if (FileLocation != null)
                 {
                     //Create the file info 
                     FileInfo info = new FileInfo(FileLocation);
                     //Save the ink strokes 
                     SaveInkStrokes(drawCanvas, FileLocation);
                     //Send message to the APplicaton 
                     VM.SavedFileAndLog(info);
                 }
                 else if (FileLocation == null)
                 {
                     SaveDialogTask(saveTitle, filter, SaveDialog_Method);

                 }
             });

            AddCommand(DesktopCommands.SaveAs, (sender, e) =>
            {
                SaveDialogTask(saveasTitle, filter, SaveDialog_Method);
            });

           

            
            //Export Command 
            AddCommand(DesktopCommands.Export, (sender, e) =>
            {
                SaveDialogTask(exportTitle, exfilter, (e, i) =>
                  {
                      //Create Png File from the Artboard
                      CreatePng(e.FileName, 96, drawCanvas);
                      //Send message to the Application 
                      VM.ExportFileAndLog(i);
                  });
            
            });
            

            #endregion




        }
        /// <summary>
        /// Gets or set the ArtBoardState of the DrawView
        /// </summary>
        public ArtBoardState State
        {
            get => state;
            set
            {
                state = value;

                //Method to Clear gridMain
                void CleargridMain()
                {
                    gridMain.Children.Clear();
                    gridMain.RowDefinitions.Clear();
                    gridMain.ColumnDefinitions.Clear();
                }

                switch (value)
                {
                    case ArtBoardState.ArtBoardRight:
                        //Used Color SPlit  
                        CleargridMain();
                        //Set Grid Postion 
                        Grid.SetColumn(zoomUsedColors, 1);
                        Grid.SetColumn(zoomDrawCanvas, 0);
                        //Set Column 
                        gridMain.ColumnDefinitions.Add(colArtBoard);
                        gridMain.ColumnDefinitions.Add(colUsedColors);
                        //Set the gridMain Children 
                        gridMain.Children.Add(zoomDrawCanvas);
                        gridMain.Children.Add(zoomUsedColors);

                        break;
                    case ArtBoardState.ArtboardLeft:
                        //Used Color SPlit  
                        CleargridMain();
                        //Set Grid Postion 
                        Grid.SetColumn(zoomUsedColors, 0);
                        Grid.SetColumn(zoomDrawCanvas, 1);
                        //Set Column 
                        gridMain.ColumnDefinitions.Add(colUsedColors);
                        gridMain.ColumnDefinitions.Add(colArtBoard);
                        //Set the gridMain Children 
                        gridMain.Children.Add(zoomUsedColors);
                        gridMain.Children.Add(zoomDrawCanvas);
                        break;
                    case ArtBoardState.PaintSplitLeft:
                        //PaintSPlit  
                        CleargridMain();
                        //Set Grid Postion 
                        Grid.SetColumn(zoomUsedColors, 0);
                        Grid.SetColumn(zoomDrawCanvas, 1);
                        Grid.SetColumn(gridSplit, 2);
                        Grid.SetColumn(zoomColorPicker, 3);
                        //Set Column 
                        gridMain.ColumnDefinitions.Add(colUsedColors);
                        gridMain.ColumnDefinitions.Add(colArtBoard);
                        gridMain.ColumnDefinitions.Add(colSplit);
                        gridMain.ColumnDefinitions.Add(colColorPicker);

                        //Set the gridMain Children 
                        gridMain.Children.Add(zoomUsedColors);
                        gridMain.Children.Add(zoomDrawCanvas);
                        gridMain.Children.Add(gridSplit);
                        gridMain.Children.Add(zoomColorPicker);
                        break;
                    case ArtBoardState.PaintSplitRight:
                        //PaintSPlit  
                        CleargridMain();
                        //Set Grid Postion 
                        Grid.SetColumn(zoomUsedColors, 3);
                        Grid.SetColumn(zoomDrawCanvas, 2);
                        Grid.SetColumn(gridSplit, 1);
                        Grid.SetColumn(zoomColorPicker, 0);
                        //Set Column 
                        gridMain.ColumnDefinitions.Add(colColorPicker);
                        gridMain.ColumnDefinitions.Add(colSplit);
                        gridMain.ColumnDefinitions.Add(colArtBoard);
                        gridMain.ColumnDefinitions.Add(colUsedColors);

                        //Set the gridMain Children 
                        gridMain.Children.Add(zoomColorPicker);
                        gridMain.Children.Add(gridSplit);
                        gridMain.Children.Add(zoomDrawCanvas);
                        gridMain.Children.Add(zoomUsedColors);
                        break;
                }
            }
        }
    }
}
