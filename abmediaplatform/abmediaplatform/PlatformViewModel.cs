
using System.IO;
using static System.Text.Json.JsonSerializer;
using static System.IO.File;
using static Albert.Win32.MediaCv;
using static Albert.Win32.Win32IO;
using System.Windows;
using Albert;
using Albert.Win32;
using Albert.Win32.Controls;
using abmediaplatform;
using System.Windows.Media;



namespace abmediaplatform
{
    /// <summary>
    /// Default ViewModel for the Win32/WPF Packages 
    /// </summary>
    public class PlatformViewModel : ViewModel
    {


        #region Common 

        /// <summary>
        /// Filter Tuple
        /// </summary>
        /// <returns></returns>
        public (string Artboard, string Msg, string Png, string AllImages, string TextFiles) FilterTuple()
        {
            var art = MakeFilter("ArtBoard", ".abart");
            var msg = MakeFilter("Msg", ".abmsg");
            var allfiles = "All Text Formats(.abtxt,.)|*.abtxt;*.|AB Text Format|*.abtxt";
            var png = MakeFilter("Png Files", ".png");
            var allimages = "All Imagges(.png,.jepg,.tiff)|*.png;*.jpg;*.jpeg;*.tiff";

            return (art, msg, png, allimages, allfiles);
        }

        /// <summary>
        /// Export Png 
        /// </summary>
        /// <param name="_element"></param>
        /// <param name="_fileName"></param>
        /// <returns></returns>
        public (string FileName, FileInfo FileInfo) ExportPng(FrameworkElement _element, string _fileName)
        {

            var info = new FileInfo(_fileName);

            //Write the Png File 
            CreatePng(_fileName, 96, _element);

            return (_fileName, info);

        }



        #endregion


        #region ArtBoard 

        /// <summary>
        /// Save Artboard Tuple 
        /// </summary>
        /// <param name="_canvas"></param>
        /// <param name="_fileName"></param>
        /// <returns></returns>
        public (string FileName, FileInfo FileInfo) SaveArtBoard(DrawCanvas _canvas, string _fileName)
        {
            //Create the FileInfo
            var info = new FileInfo(_fileName);

            //Save the InkStrokes 
            SaveInkStrokes(_canvas, _fileName);


            return (_fileName, info);
        }
        /// <summary>
        /// Load ArtBoard Tuple 
        /// </summary>
        /// <param name="_fileName"></param>
        /// <param name="_canvas"></param>
        /// <returns></returns>
        public (string FileName, FileInfo FileInfo) LoadArtBoard(string _fileName, DrawCanvas _canvas)
        {
            var info = new FileInfo(_fileName);

            _canvas.Strokes.Clear();

            LoadInkStrokes(_canvas, _fileName);

            _canvas.Select(_canvas.Strokes);

            return (_fileName, info);
        }



        #endregion


        #region Msg


        public (string FileName, FileInfo Info) SaveMsgTuple(ATextField _txt, string _fileName)
        {
            //FileInfo
            var info = new FileInfo(_fileName);


            //Breakdown TextField Properties  
            var background = (SolidColorBrush)_txt.Background;
            var foreground = (SolidColorBrush)_txt.Foreground;
            var border = (SolidColorBrush)_txt.BorderBrush;
            var thickness = _txt.BorderThickness.Top;
            var cornerradius = _txt.CornerRadius.TopLeft;
            var fontfamily = _txt.FontFamily;
            var fontsize = _txt.FontSize;
            var text = _txt.Text;

            // Convet to the format 
            var format = new MsgFormat
            {
                Background = background.Color.ToString(),
                Foreground = foreground.Color.ToString(),
                Border = border.Color.ToString(),
                Thickness = thickness,
                CornerRadius = cornerradius,
                FontSize = fontsize,
                FontFamily = fontfamily.Source

            };

            //Sererlize to Json 
            var json = Serialize(format);

            //Save the Json to file 
            File.WriteAllText(_fileName, json);




            return (_fileName, info);
        }

        public (string FileName, FileInfo Info) LoadMsgTuple(string _fileName, ATextField _txt)
        {
            //FileINfo 
            var info = new FileInfo(_fileName);

            // Grab the Json 
            var json = File.ReadAllText(_fileName);
            //Convet json to MsgFormat 
            var format = Deserialize<MsgFormat>(json);


            //Convert format to the ATextField 
            _txt.Background = HexBrush(format.Background);
            _txt.Foreground = HexBrush(format.Foreground);
            _txt.BorderBrush = HexBrush(format.Border);
            _txt.BorderThickness = new Thickness(format.Thickness);
            _txt.FontFamily = new FontFamily(format.FontFamily);
            _txt.FontSize = format.FontSize;
            _txt.Text = format.Text;

            //Return FIle and FileInfo 
            return (_fileName, info);
        }


        #endregion 


        #region Theme Logic        

        public (string FileName, FileInfo Info) SaveThemeTuple(ThemeFormat _format, string _fileName)
        {
            //Create the File Info 
            var info = new FileInfo(_fileName);
            //Create the Json  
            var json = Serialize<ThemeFormat>(_format);
            //Save the FIle 
            File.WriteAllText(_fileName, json);

            return (_fileName, info);
        }

        public (string FileName, FileInfo Info, ThemeFormat Theme) LoadThemeTuple(string _fileName)
        {
            //FileInfo 
            var info = new FileInfo(_fileName);

            //Get Json File 
            var json = File.ReadAllText(_fileName);

            //Convert Json to ThemeFormat Class  
            var themeformat = Deserialize<ThemeFormat>(json);

            //Return the value 
            return (_fileName, info, themeformat);
        }

        #endregion




        #region TextEditor 

        public (string FileName, FileInfo Info) SaveText_Tuple(string _text, string _fontfamily, double _fontsize, string _filename)
        {
            //Create the File Info 
            var info = new FileInfo(_filename);

            var format = new ABTextFormat
            {
                Text = _text,
                FontFamily = _fontfamily,
                FontSize = _fontsize
            };

            //Create the Json 
            var s = Serialize(format);

            //Save the Json to file 
            WriteAllText(_filename, s);


            // Return File Name and Info 
            return (_filename, info);

        }

        public (string FileName, FileInfo Info) SaveText_Tuple(string _text, string _fileName)
        {
            var info = new FileInfo(_fileName);
            //Write The Text File
            WriteAllText(_fileName, _text);

            //return FileName and FileInfo 
            return (_fileName, info);
        }

        public (string FileName, FileInfo Info, ABTextFormat Format) LoadText_Tuple(string _filename)
        {
            //Grab the info 
            var info = new FileInfo(_filename);

            //Get the Json File 
            var file = ReadAllText(_filename);

            //Convert Json to the ABTextFormat 
            var format = Deserialize<ABTextFormat>(file);


            // Return file name, info and the format 
            return (_filename, info, format);
        }

        public (string FileName, FileInfo Info, string Text) LoadPlainText_Tuple(string _fileName)
        {
            var info = new FileInfo(_fileName);

            var text = ReadAllText(_fileName);

            return (_fileName, info, text);


        }

    

     

        #endregion


        public DirectoryInfo CurrentDirectory { get; set; }

        /// <summary>
        /// Get or set Current Saved and oPen file Names for display
        /// </summary>
        public VMList<string> CurrentFileNames { get; set; } = new VMList<string>();

   


    }
}
