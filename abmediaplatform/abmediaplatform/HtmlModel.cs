using Albert;
using System;
using System.Collections.Generic;
using System.Text;

namespace abmediaplatform
{
    /// <summary>
    /// Model to Generate a Html Document  
    /// </summary>
    public class HtmlModel : PropBase
    {
        string title, description, keywords, author, head, body,header,footer, js, style;


        public HtmlModel()
        {
            Name = "";
            Title = "";
            Author = "";
            Description = "";
            Keywords = "";
            Head = "";
            Body = "";

        }
         

       
        /// <summary>
        /// Get or sets the Title of your webpage
        /// </summary>
        public string Title
        {
            get 
            {
                return title;
            }
            set { title = value; OnPropertyChanged("Title"); }
        }
        /// <summary>
        /// Get or sets the Decritpion of the Page
        /// </summary>
        public string Description 
        {
            get { return description; }
            set { description = value; OnPropertyChanged("Description"); }
        }
        /// <summary>
        /// Get or sets the Author of the page 
        /// </summary>
        public string Author
        {
            get { return author; }
            set { author = value; OnPropertyChanged("Author"); }
        }
        /// <summary>
        /// Get or sets the Keywords of the Pag e 
        /// </summary>
        public string Keywords
        {
            get { return keywords; }
            set { keywords = value; OnPropertyChanged("Keywords"); }
        }

        public string Head
        {
            get { return head; }
            set { head = value; OnPropertyChanged("Head"); }
        }

        public string Header
        {
            get { return header; }
            set { header = value; OnPropertyChanged("Header"); }
        }

        public string Body
        {
            get { return body; }
            set { body = value; OnPropertyChanged("Body"); }
        }

        public string Footer
        {
            get { return footer; }
            set { footer = value; OnPropertyChanged("Footer"); }
        }
        public string Style
        {
            get { return style; }
            set { style = value; OnPropertyChanged("Style"); }
        }
        /// <summary>
        /// Gets or sets the Default Javascript file
        /// </summary>
        public string Script
        {
            get { return js; }
            set { js = value; OnPropertyChanged("Script"); }
        }
        /// <summary>
        /// String Outout's html document 
        /// </summary>
        /// <returns>Html Document</returns>
        public override string ToString()
        {
            return $"$<!DOCTYPE html >\n < html lang =\"en\">\n<head>\n<meta charset= \"utf-8\" />\n<meta name=\"viewport\" content=\"width = device - width,initial-scale=+1\">\n<meta name=\"description\" content=\"{Description}\"  />\n<meta name=\"author\" content=\"{Author}\" />\n<meta name=\"keywords\" content=\"{Keywords}\"  />\n<title>{Title}</title>\n<link rel=\"\" type=\"text/css\" media=\"screen\" href=\"{Style}\" />\n\n{Head}\n</head>\n<body>\n<div class=\"container\">{Header}\n{Body}\n{Footer}</div>\n\n<script src=\"{Script}\"></script>\n\n</body>\n</html>";
        }

    }
}
