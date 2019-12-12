using System;
using System.Collections.Generic;
using System.Text;
using Albert.Win32;
using static Albert.Win32.Win32IO;
using static Albert.Win32.MediaCv;
using System.IO;
using System.Xml.Linq;
using System.Windows;
using Albert.Win32.Controls;
using System.Windows.Controls;

namespace abArtBoard
{
    public class ArtBoardViewModel : ViewModel
    {
        #region Field's 


        #endregion


        #region Constructor
        /// <summary>
        /// Default Constructor 
        /// </summary>
        public ArtBoardViewModel()
        {

        }
        #endregion

        #region Common 

        /// <summary>
        /// Filter Tuple
        /// </summary>
        /// <returns></returns>
        (string Artboard,string Storyboard,string AllFiles)FilterTuple()
        {
            var art = MakeFilter("ArtBoard", ".abart");
            var storyboard = MakeFilter("StoryBoard", ".abstory");
            var allfiles = MakeFilter("All Files", ".");

            return (art, storyboard, allfiles);
        }

        /// <summary>
        /// Export Png 
        /// </summary>
        /// <param name="_element"></param>
        /// <param name="_fileName"></param>
        /// <returns></returns>
        (string FileName, FileInfo FileInfo) ExportPng(FrameworkElement _element, string _fileName)
        {

            var info = new FileInfo(_fileName);

            //Write the Png File 
            CreatePng(_fileName, 96, _element);

            return (_fileName, info);
            
        }

        /// <summary>
        /// Get or set the Current TabControl 
        /// </summary>
        public TabControl VMTab { get; set; }


        #endregion

        #region ArtBoard 

        (string FileName, FileInfo FileInfo) SaveArtBoard(DrawCanvas _canvas,string _fileName)
        {
            var info = new FileInfo(_fileName);
            //Clear Canvas 
            _canvas.Strokes.Clear();
            SaveInkStrokes(_canvas, _fileName);
            //Select all strokes 
            _canvas.Select(_canvas.Strokes);

            return (_fileName, info);
        }

        (string FileName, FileInfo FileInfo) LoardArtBoard(string _fileName, DrawCanvas _canvas)
        {
            var info = new FileInfo(_fileName);

            _canvas.Strokes.Clear();

            LoadInkStrokes(_canvas, _fileName);
            
            _canvas.Select(_canvas.Strokes);

            return (_fileName, info);
        }

        #endregion


        #region StoryBord

        #endregion


        #region TextEditor 


        #endregion


    }
}
