using Albert;
using Albert.Win32;
using Albert.Win32.Controls;
using System;
using System.Collections.Generic;
using System.IO;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Media;
using System.Xml.Linq;
using ICSharpCode.AvalonEdit;
using static System.Convert;
using static Albert.Win32.MediaCv;
using static Albert.Win32.Win32IO;
using System.Windows.Documents;

namespace abArt
{
    /// <summary>
    /// Default ViewModel of abArtBoard
    /// </summary>
    public class ArtViewModel: ViewModel
    {
        WindowState winState;
        string notes;
        TabControl tab;
        
        #region Constructor 
        public ArtViewModel()
        {
            //Do ArtBoard Logic 
            ArtBoardLogic();


        }
        #endregion

        #region Application Logic 

        #region Common 
        /// <summary>
        /// A Tuple to handle Filters for saving and Loading files 
        /// </summary>
        /// <returns></returns>
        public (string ArtBoard, string Msg,string Brand, string Png, string All) FilterTuple()
        {
          
            //ArtBoard Filter 
            var art = MakeFilter("AB ArtBoard", ".abartboard");
            
            //Msg Filter 
            var msg = MakeFilter("AB Msg", ".abmsg");

            //Brand Filter 
            var brand = MakeFilter("AB Brand", ".abbrand");

            //Png Filter 
            var png = MakeFilter("Png Format", ".png");

            //All Text Files 
            var all = MakeFilter("All Formats", ".");

            return ( art, msg,brand, png, all);
        }



        /// <summary>
        /// Tuple update TabItem info Quickly 
        /// </summary>
        /// <param name="_fileName"></param>
        /// <param name="_tabitem"></param>
        /// <returns></returns>
        public (string FileName, FileInfo FileInfo) UpdateTabInfo(string _fileName, DocumentTabItem _tabitem)
        {
            //Setup FileInfo
            _tabitem.FileInfo = new FileInfo(_fileName);
            _tabitem.CurrentFile = _fileName;
            _tabitem.Header = _tabitem.FileInfo.Name;

            //Send a Message
            Message($"Your TabItem is hosting {_tabitem.FileInfo.Name} from the{_tabitem.FileInfo.DirectoryName} directory",true);


            //Return Value 
            return (_fileName, _tabitem.FileInfo);


        }




        #endregion

        #region ArtBoad
        //Lists 
        private VMList<ArtBoardModel> presetBrusheSizes, presetthemes, presetBoardSizes;
        //ArtBoard Logic 
        void ArtBoardLogic()
        {
            //Preset ArtBoard Sizes 
            presetBoardSizes = new VMList<ArtBoardModel>
            { 
                new ArtBoardModel(1080),
                new ArtBoardModel(1920,1080),
                new ArtBoardModel(1080,1980),
                new ArtBoardModel(1365,768),
                new ArtBoardModel(1024,1024),
                new ArtBoardModel(1024,768),
                new ArtBoardModel(800,600),
                new ArtBoardModel(504,504),
                new ArtBoardModel(300,300),
                new ArtBoardModel(100,100)
            
            };


            //Preset Your Brush Sizes 
            presetBoardSizes = new VMList<ArtBoardModel>
            {
                new ArtBoardModel{BrushSize = 5 },
                new ArtBoardModel{BrushSize = 10},
                new ArtBoardModel{BrushSize = 15 },
                new ArtBoardModel{BrushSize = 20 },
                new ArtBoardModel{BrushSize = 25 },
                new ArtBoardModel{BrushSize = 30},
                new ArtBoardModel{BrushSize = 35},
                new ArtBoardModel{BrushSize = 40},
                new ArtBoardModel{BrushSize = 45 },
                new ArtBoardModel{BrushSize = 50 },
                new ArtBoardModel{BrushSize = 55 },
                new ArtBoardModel{BrushSize = 60},
                new ArtBoardModel{BrushSize = 65 },
                new ArtBoardModel{BrushSize = 70},
                new ArtBoardModel{BrushSize = 75 },
                new ArtBoardModel{BrushSize = 80 },


            };

            //Preset Themes 
            presetthemes = new VMList<ArtBoardModel>
            {
                new ArtBoardModel("#ff000000","#ffc2c2c2"){ Name= "Default" },
                new ArtBoardModel("#ffffffff","#ff000000"){ Name= "BlackBoard" },
                new ArtBoardModel("#ffffffff","#fff060A54"){ Name= "ChaulkBord" },
                new ArtBoardModel("#ffffffff","#ff097620"){ Name= "BluePrint" },
                new ArtBoardModel("#ffffffff","#ff9B0303"){ Name= "RedPrint" }

            };


        }

        /// <summary>
        /// Tuple to Save the Artboard
        /// </summary>
        /// <param name="_inkCanvas"></param>
        /// <param name="_fileName"></param>
        /// <returns></returns>
        public (string FileName, FileInfo FileInfo) SaveArtBoardTuple(DrawCanvas _inkCanvas, string _fileName)
        {
            //Save the Ink Strokes 
            SaveInkStrokes(_inkCanvas, _fileName);
            //Setup File Info 
            var fileinfo = new FileInfo(_fileName);

            return (_fileName, fileinfo);
        }
        /// <summary>
        /// Load Artboard Tuple 
        /// </summary>
        /// <param name="_fileName"></param>
        /// <param name="_inkcanvas"></param>
        /// <returns></returns>
        public (string FileName, FileInfo FileIffo) LoadArtBoardTuple(string _fileName, DrawCanvas _inkcanvas)
        {
            //Save the Ink Strokes 
            LoadInkStrokes(_inkcanvas, _fileName);
            //Setup File Info 
            var fileinfo = new FileInfo(_fileName);

            _inkcanvas.Select(_inkcanvas.Strokes);
            _inkcanvas.EditingMode = InkCanvasEditingMode.Select;

            return (_fileName, fileinfo);
        }


        /// <summary>
        /// Tuple ot create new ArtBoard
        /// </summary>
        /// <returns>Width, Height,SolidBrush,Color,InkCanvas</returns>
        public (double width, double height, SolidColorBrush background, Color brushcolor) NewArtBoard(ArtBoardModel _model)
        {
            return (_model.Width, _model.Height, new SolidColorBrush(_model.BackgroundColor), _model.BrushColor);
        }
        /// <summary>
        /// Get or set Preset ArtBoard Sizes
        /// </summary>
        public VMList<ArtBoardModel> PresetArtBoardSizes
        {
            get { return presetthemes; }
            set { PresetThemes = value; OnPropertyChanged("PresetArtBoardSizes"); }
        }
        /// <summary>
        /// Get or set Preset ArtBrush Siezes 
        /// </summary>
        public VMList<ArtBoardModel> PresetArtBrushSizes
        {
            get { return presetBrusheSizes; }
            set { presetBrusheSizes = value; OnPropertyChanged("PresetArtBrushSizes"); }
        }
        /// <summary>
        /// Get or set Preset Themes for Artboard's 
        /// </summary>
        public VMList<ArtBoardModel> PresetThemes
        {
            get { return presetthemes; }
            set { presetthemes = value; OnPropertyChanged("PresetThemes"); }
        }
        /// <summary>
        /// Gets or sets the Alpha value of the Artboard Brush 
        /// </summary>
        public byte AlphaColor { get; set; }
        /// <summary>
        /// Get or sets the Old Color Used 
        /// </summary>
        public Color OldColor { get; set; }
        /// <summary>
        /// Get or Set the New Board
        /// </summary>
        public ArtBoardModel NewBoard { get; set; }







        #endregion

        #region Msg 
        /// <summary>
        /// Tuple to save a Rich Msg Document 
        /// </summary>
        /// <param name="_rtb">RichTextBlock</param>
        /// <param name="_filename"></param>
        /// <returns>Return's a XElement and the File Name</returns>
        public (XElement Output, string FileName) SaveMsg(RichTextBlock _rtb, string _filename)
        {
            //Setup your Xml file 
            var xml = new XElement("abflowdoc");
            var document = new XElement("msg");


            //Convert the Color's 
            var background = (SolidColorBrush)_rtb.Background;
            var textcolor = (SolidColorBrush)_rtb.Foreground;
            var bordercolor = (SolidColorBrush)_rtb.BorderBrush;

            //Grab the Text
            var textrange = new TextRange(_rtb.Document.ContentStart, _rtb.Document.ContentEnd);
            var text = textrange.Text;



            //Create your Xml Document 
            document.Add(new XElement("text", text));
            document.Add(new XAttribute("fontfamily", _rtb.FontFamily));
            document.Add(new XAttribute("width", _rtb.Width));
            document.Add(new XAttribute("height", _rtb.Height));
            document.Add(new XAttribute("fontsize", _rtb.FontSize));
            document.Add(new XAttribute("borderthickness", _rtb.BorderThickness.Top));
            document.Add(new XAttribute("cornerradius", _rtb.CornerRadius.TopLeft));
            document.Add(new XAttribute("background", background.Color));
            document.Add(new XAttribute("foreground", textcolor.Color));
            document.Add(new XAttribute("border", bordercolor.Color));


            //add to the xml output 
            xml.Add(document);
            //Save the Xml File 
            xml.Save(_filename);

            //Return the Xml Document 
            return (xml, _filename);

        }
        /// <summary>
        /// Tuple to save a Msg Document 

        /// </summary>
        /// <param name="_txt">ATextField</param>
        /// <param name="_filename">File Name</param>

        /// <returns></returns>
        public (XElement Output, string FileName) SaveMsg(ATextField _txt, string _filename)
        {
            //Setup your Xml file 
            var xml = new XElement("abflowdoc");
            var document = new XElement("msg");

            //Convert the Color's 
            var background = (SolidColorBrush)_txt.Background;
            var textcolor = (SolidColorBrush)_txt.Foreground;
            var bordercolor = (SolidColorBrush)_txt.BorderBrush;

            //Grab the text 
            var text = _txt.Text;

            //Create your Xml Document 
            document.Add(new XElement("text", text));
            document.Add(new XAttribute("width", _txt.Width));
            document.Add(new XAttribute("heihgt", _txt.Height));
            document.Add(new XAttribute("fontfamily", _txt.FontFamily));
            document.Add(new XAttribute("fontsize", _txt.FontSize));
            document.Add(new XAttribute("borderthickness", _txt.BorderThickness.Top));
            document.Add(new XAttribute("cornerradius", _txt.CornerRadius.TopLeft));
            document.Add(new XAttribute("background", background.Color));
            document.Add(new XAttribute("foreground", textcolor.Color));
            document.Add(new XAttribute("border", bordercolor.Color));



            xml.Add(document);
            xml.Save(_filename);

            //Return the Xml Document 
            return (xml, _filename);
        }
        /// <summary>
        /// Tuple to Load Msg to RichTextBlock
        /// </summary>
        /// <param name="_fileName">File Name</param>
        /// <param name="_rtb">RichText Block to Populate</param>
        /// <returns>Xml Output and File Name</returns>
        public (XElement Output, string FileName) LoadMsg(string _fileName, RichTextBlock _rtb)
        {
            var xml = XElement.Load(_fileName);

            //Grab the Document 
            var document = xml.Element("msg");
            //Convert doubles
            var width = ToDouble(document.Attribute("width").Value);
            var height = ToDouble(document.Attribute("heght").Value);
            var thickness = ToDouble(document.Attribute("borderthickness").Value);
            var cornerradius = ToDouble(document.Attribute("cornerradius").Value);
            var fontsize = ToDouble(document.Attribute("fontsize"));
            //Convert Colors 
            var background = HexBrush(document.Attribute("background").Value);
            var foreground = HexBrush(document.Attribute("foreground").Value);
            var border = HexBrush(document.Attribute("border").Value);
            //Font Family 
            var fontfamily = document.Attribute("fontfamily").Value;

            //Grab the Text 
            var text = document.Element("text").Value;

            //Fill up the RichTextBlock 
            var textrange = new TextRange(_rtb.Document.ContentStart, _rtb.Document.ContentEnd);
            textrange.Text = "";
            textrange.Text = text;
            _rtb.FontFamily = new FontFamily(fontfamily);
            _rtb.FontSize = fontsize;
            _rtb.Width = width;
            _rtb.Height = height;
            _rtb.CornerRadius = new CornerRadius(cornerradius);
            _rtb.BorderThickness = new Thickness(thickness);
            _rtb.Background = background;
            _rtb.Foreground = foreground;
            _rtb.BorderBrush = border;

            return (xml, _fileName);
        }
        /// <summary>
        /// Tuple to Load Msg to ATextField
        /// </summary>
        /// <param name="_filename">File Name</param>
        /// <param name="_txt">ATextField to populate</param>
        /// <returns></returns>
        public (XElement Output, string FileName) LoadMsg(string _filename, ATextField _txt)
        {
            var xml = XElement.Load(_filename);

            //Grab the Document 
            var document = xml.Element("msg");
            //Convert doubles
            var width = ToDouble(document.Attribute("width").Value);
            var height = ToDouble(document.Attribute("heght").Value);
            var thickness = ToDouble(document.Attribute("borderthickness").Value);
            var cornerradius = ToDouble(document.Attribute("cornerradius").Value);
            var fontsize = ToDouble(document.Attribute("fontsize"));
            //Convert Colors 
            var background = HexBrush(document.Attribute("background").Value);
            var foreground = HexBrush(document.Attribute("foreground").Value);
            var border = HexBrush(document.Attribute("border").Value);
            //Font Family 
            var fontfamily = document.Attribute("fontfamily").Value;
            //Grab the Text 
            var text = document.Element("text").Value;

            //Fill up the ATextField 
            _txt.Text = text;
            _txt.FontFamily = new FontFamily(fontfamily);
            _txt.FontSize = fontsize;
            _txt.Width = width;
            _txt.Height = height;
            _txt.CornerRadius = new CornerRadius(cornerradius);
            _txt.BorderThickness = new Thickness(thickness);
            _txt.Background = background;
            _txt.Foreground = foreground;
            _txt.BorderBrush = border;


            return (xml, _filename);
        }



        #endregion


        #region TextEdit
        /// <summary>
        /// Tuple to Export Text File  
        /// </summary>
        /// <param name="_filename"></param>
        /// <param name="_txt"></param>
        /// <returns></returns>
        public (string FileName,FileInfo) ExportTextTuple(string _filename,TextBox _txt)
        {
            //Grab the Text 
            var text = _txt.Text;
            //Save the Text 
            File.WriteAllText(_filename, text);
            //Create the File Info 
            var info = new FileInfo(_filename);
            //Return your value's 
            return (text, info);
        }
        /// <summary>
        /// Tuple to Export TextFile 
        /// </summary>
        /// <param name="_filename"></param>
        /// <param name="_txt"></param>
        /// <returns></returns>
        public (string FileName, FileInfo) ExportTextTuple(string _filename, TextEditor _txt)
        {
            //Grab the Text 
            var text = _txt.Text;
            //Save the Text 
            File.WriteAllText(_filename, text);
            //Create the File Info 
            var info = new FileInfo(_filename);
            //Return your value's 
            return (text, info);
        }



        #endregion


        #region PDF Reader 

        #endregion

        #region Browser 

        #endregion


        #endregion



        #region Application Public Properties 

        public TabControl VMTab
        {
            get { return tab; }
            set { tab = value; OnPropertyChanged("VMTab"); }

        }

        public WindowState WindowState
        {
            get { return winState; }
            set { winState = value; OnPropertyChanged("WindowState"); }
        }

        #endregion


    }
}
