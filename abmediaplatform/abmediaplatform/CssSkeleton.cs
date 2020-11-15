using System;
using System.Collections.Generic;
using System.Text;
using Albert;
namespace abmediaplatform
{
    public class CssSkeleton : PropBase
    {
        private string extra, background, cbackground, fontcolor, fontsize, fontfamily;

        public CssSkeleton()
        {
            Background = "#333333";
            ContainerBackground = "#000000";
            FontColor = "#ffffff";
            FontFamily = "Verdana,Arial,sans-seif";
            FontSize = "1.3rem";
        }


        public CssSkeleton(string _extra)
        {
            Background = "#333333";
            ContainerBackground = "#000000";
            FontColor = "#ffffff";
            FontFamily = "Verdana,Arial,sans-seif";
            FontSize = "1.3rem";

            Extra = _extra;
        }



        public string CssValue(string _property, string pvalue)
        {
            return $"\t{_property}: {pvalue};\n";
        }


        public string Extra
        {
            get { return extra; }
            set { extra = value; OnPropertyChanged("Extra"); }
        }

        public string Background
        {
            get { return background; }
            set { background = value; OnPropertyChanged("Background"); }
        }

        public string ContainerBackground
        {
            get { return cbackground; }
            set { cbackground = value; OnPropertyChanged("ContainerBackground"); }
        }

        public string FontColor
        {
            get { return fontcolor; }
            set { fontcolor = value; OnPropertyChanged("FontColor"); }
        }

        public string FontSize
        {
            get { return fontsize; }
            set { fontsize = value; OnPropertyChanged("FontSize"); }
        }

        public string FontFamily
        {
            get { return fontfamily; }
            set { fontfamily = value; OnPropertyChanged("FontFamily"); }
        }
        /// <summary>
        /// Return Skelton CSS File 
        /// </summary>
        /// <returns></returns>
        public override string ToString()
        {
            var rv = "";
            //body
            rv += $"body\n{{\n";
            rv += CssValue("background-color", $"{Background}");
            rv += CssValue("color", $"{FontColor}");
            rv += CssValue("font-family", $"{FontFamily}");
            rv += CssValue("font-size", $"{FontSize}");
            rv += CssValue("width", $"100%");
            rv += CssValue("padding", $"0px");     
            rv += $"}}\n";

            //logo 
            rv += $".logo\n{{\n";
            rv += CssValue("display", $"inline-block");
            rv += CssValue("width", $"125px");
            rv += CssValue("height", "125px");
;           
            //header 
            rv += $"header\n{{\n";
            rv += CssValue("display", $"block");
            rv += CssValue("width", $"100%");
            rv += CssValue("background-color", $"{Background}");
            rv += CssValue("padding", "7px");
            rv += $"}}\n";
            //.container 
            rv += $".container\n{{\n";
            rv += CssValue("display", $"block");
            rv += CssValue("width", $"100%");
            rv += CssValue("padding", "7px");
            rv += CssValue("background-color", $"{ContainerBackground}");
            rv += $"}}\n";

            rv += $".container p \n{{\n";
            rv += CssValue("line-height", $"130%");
            rv += $"}}\n";

            rv += $".container li \n{{\n";
            rv += CssValue("line-height", $"175%");
            rv += $"}}\n";



            //Defaul article, aside,details,figcaption,figure,footer,header,hgroup,main,menu,nav,selection,summery
            rv += $"article, aside, details, figcaption, figure, footer, header,hgroup, main, menu, nav, section, summary \n{{\n";
            rv += CssValue("display", $"block");
            rv += $"}}\n";
            //Default audio, canvas, progress, video 
            rv += $"audio, canvas, progress, video\n{{\n";
            rv += CssValue("display", $"inline-block");
            rv += CssValue("vertical-align", $"baseline");
            rv += $"}}\n";
            //.cover 
            rv += $".cover\n{{\n";
            rv += CssValue("position", $"absolute");
            rv += CssValue("top", $"0px");
            rv += CssValue("width", $"100%");
            rv += $"}}\n";
            rv += $".clear\n{{\n";
            rv += CssValue("clear", $"both");
            rv += $"}}\n";
            //.cblock
            rv += $".cblock\n{{\n";
            rv += CssValue("display", $"mock");
            rv += CssValue("margin-left", $"auto");
            rv += CssValue("margin-right", $"auto");
            rv += $"}}\n";

            rv += $".left\n{{\n";
            rv += CssValue("text-align", $"left");
            rv += $"}}\n";

            rv += $".row \n{{\n";
            rv += CssValue("padding-left", $"-15px");
            rv += CssValue("padding-right", $"-15px");
            rv += $"}}\n";
            //.main 
            rv += $".main \n{{\n";
            rv += CssValue("width", $"66%");
            rv += CssValue("display", $"block");
            rv += CssValue("margin-right", $"2%");
            rv += CssValue("float", $"left");
            rv += $"}}\n";
            //.side 
            rv += $".side \n{{\n";
            rv += CssValue("width", $"30%");   
            rv += CssValue("display", $"block");
            rv += CssValue("float", $"right");
            rv += $"}}\n";

            rv += $".c1 \n{{\n";
            rv += CssValue("width", $"100%");
            rv += CssValue("float", $"left");
            rv += CssValue("padding", $"7px");
            rv += CssValue("box-sizing", $"border-box");
            rv += CssValue("margin-bottom", $"2%");
            rv += $"}}\n";

            rv += $".c2 \n{{\n";
            rv += CssValue("width", $"50%");
            rv += CssValue("float", $"left");
            rv += CssValue("padding", $"7px");
            rv += CssValue("box-sizing", $"border-box");
            rv += CssValue("margin-bottom", $"2%");
            rv += $"}}\n";


            rv += $".c3 \n{{\n";
            rv += CssValue("width", $"33.33%");
            rv += CssValue("float", $"left");
            rv += CssValue("padding", $"7px");
            rv += CssValue("box-sizing", $"border-box");
            rv += CssValue("margin-bottom", $"2%");
            rv += $"}}\n";

            rv += $".c4\n{{\n";
            rv += CssValue("width", $"25%");
            rv += CssValue("float", $"left");
            rv += CssValue("padding", $"7px");
            rv += CssValue("box-sizing", $"border-box");
            rv += CssValue("margin-bottom", $"2%");
            rv += $"}}\n";

            rv += $".c5 \n{{\n";
            rv += CssValue("width", $"20%");
            rv += CssValue("float", $"left");
            rv += CssValue("padding", $"7px");
            rv += CssValue("box-sizing", $"border-box");
            rv += CssValue("margin-bottom", $"2%");
            rv += $"}}\n";

            rv += $".c6 \n{{\n";
            rv += CssValue("width", $"16.66667%%");
            rv += CssValue("float", $"left");
            rv += CssValue("padding", $"7px");
            rv += CssValue("box-sizing", $"border-box");
            rv += CssValue("margin-bottom", $"2%");
            rv += $"}}\n";


            rv += $".c7 \n{{\n";
            rv += CssValue("width", $"14.28571%");
            rv += CssValue("float", $"left");
            rv += CssValue("padding", $"7px");
            rv += CssValue("box-sizing", $"border-box");
            rv += CssValue("margin-bottom", $"2%");
            rv += $"}}\n";

            rv += $".c8 \n{{\n";
            rv += CssValue("width", $"12.5%");
            rv += CssValue("float", $"left");
            rv += CssValue("padding", $"7px");
            rv += CssValue("box-sizing", $"border-box");
            rv += CssValue("margin-bottom", $"2%");
            rv += $"}}\n";


            rv += $".c9 \n{{\n";
            rv += CssValue("width", $"11.111111%");
            rv += CssValue("float", $"left");
            rv += CssValue("padding", $"7px");
            rv += CssValue("box-sizing", $"border-box");
            rv += CssValue("margin-bottom", $"2%");
            rv += $"}}\n";


            rv += $".c10 \n{{\n";
            rv += CssValue("width", $"10%");
            rv += CssValue("float", $"left");
            rv += CssValue("padding", $"7px");
            rv += CssValue("box-sizing", $"border-box");
            rv += CssValue("margin-bottom", $"2%");
            rv += $"}}\n";


            rv += $".c11 \n{{\n";
            rv += CssValue("width", $"9.09091%");
            rv += CssValue("float", $"left");
            rv += CssValue("padding", $"7px");
            rv += CssValue("box-sizing", $"border-box");
            rv += CssValue("margin-bottom", $"2%");
            rv += $"}}\n";



            rv += $".container li \n{{\n";
            rv += CssValue("line-height", $"175%");
            rv += $"}}\n";

            rv += $".right\n{{\n";
            rv += CssValue("text-align", $"right");
            rv += $"}}\n";

            rv += $".justify\n{{\n";
            rv += CssValue("text-align", $"justify");
            rv += $"}}\n";

            rv += $".center\n{{\n";
            rv += CssValue("text-align", $"center");
            rv += $"}}\n";

            rv += $".pright\n{{\n";
            rv += CssValue("float", $"right");
            rv += CssValue("display", $"block");
            rv += $"}}\n";

            rv += $".pleft\n{{\n";
            rv += CssValue("float", $"left");
            rv += CssValue("display", $"block");
            rv += $"}}\n";

            rv += $"\n{Extra}\n";









            return rv;

        }


    }


}         




   
