using System;
using System.IO;
using static System.Console;
using static Albert.Win32.Win32IO;
using static Albert.ABConsole;
using static abmediaplatform.Docs;
using Albert;
using abmediaplatform;
using Microsoft.ML;

namespace abCommad
{

    class Program
    {
        //Create a line 
        static string line = "----------------------";

        [STAThread]
        static void Main(string[] args)
        {
            //Run the Main Start Menu 
            Start();
            

            
            ReadLine();
        }
        /// <summary>
        /// Main Start Method 
        /// </summary>
        static void Start()
        {

            Clear();
            WriteLine("abCommand 1.0");
            WriteLine(line);
            WriteLine("Website Project = wsp");
            WriteLine("WP Theme Creator =  wpt");
            WriteLine("Html Page Creator = htm");
            WriteLine("Css Style Creator = css");
          
  
            WriteLine(line);
            Write("\nPick a Program: ");
            var choice = ReadLine();

            switch (choice)
            {
                case "css":
                    CreateCssStylesheet();
                    break;
                case "htm":
                    CreateHtmlPage();
                    break;
                case "wsp":
                    WebsiteProject();
                    break;
                case "wpt":
                    WPTheme();
                    break;
                default:
                    //Exit 
                    WriteExit(Start);
                    break;
            }
        }

        static void CreateCssStylesheet()
        {
            var name = "";
            var background = "";
            var cbackgrond = "";
            var color = "";
            var fontfamily = "";
            var fontsize = "";
            WriteTitle("Css Genrator");
            WriteLine("Press Enter to being...");
            ReadLine();
            Write("Name:");
            name = ReadLine();

            Write("Background:");
            background = ReadLine();


            Write("Container Background:");
            cbackgrond = ReadLine();

            Write("Color:");
            color = ReadLine();

            Write("FontFamily:");
            fontfamily = ReadLine();

            Write("FontSize:");
            fontsize = ReadLine();

            var cssk = new CssSkeleton { Background =background, ContainerBackground = cbackgrond, FontColor = color, FontFamily = fontfamily, FontSize = fontsize };
            WriteLine(cssk.ToString());

            //Save the css 
            saveCss();

            void saveCss()
            {
                Write("Do you want to save this css file?(y/n)\nAnswer:");
                var choice = ReadLine();

                switch(choice)
                {
                    case "y":
                        var filter = "Css/Sass Format|*.css;*.scss";
                        SaveDialogTask("Save the Stylesheet", filter, (s, i) =>
                          {
                              //Save Css file 
                              File.WriteAllText(s.FileName, cssk.ToString());
                          
                          });
                        WriteExit(Start, CreateCssStylesheet);
                        break;
                    default:
                        WriteExit(Start,CreateCssStylesheet);
                        break;

                        
                }
            }


        }
        /// <summary>
        /// Method for Creating a Html Page 
        /// </summary>
        static void CreateHtmlPage()
        {
            //Field's  
            
            var title = "";
            var description = "";
            var keywords = "";
            var author = "";
            var css = "";
            var js = "";
            //Define the output for saving
            var output = "";
            WriteTitle("Html Page Creator");
            WriteLine("Page = p");
            WriteLine("Page with Css ps");
            WriteLine("Page with Js and Css = psj");
            Write("Select Page Type: ");
            var ptype = ReadLine();

            switch (ptype)
            {
                case "p":
                    Write("Title:");
                    title = ReadLine();
                    Write("Description:");
                    description = ReadLine();
                    Write("Author:");
                    author = ReadLine();
                    Write("Keywords:");
                    keywords = ReadLine();
                    output = HtmlDoc(title, description, author, keywords);
                    WriteLine(output);
                 
                    WriteLine(line);
                    saveHtml();
                   
                    break;
                case "ps":
                    Write("Title:");
                    title = ReadLine();
                    Write("Description:");
                    description = ReadLine();
                    Write("Author:");
                    author = ReadLine();
                    Write("Keywords:");
                    keywords = ReadLine();
                    Write("Stylesheet: ");
                    css = ReadLine();
                    output = HtmlDoc(title, description, author, keywords,css);
                    WriteLine(output);
                    WriteLine(line);
                    saveHtml();
                    break;

                case "psj":
                    Write("Title:");
                    title = ReadLine();
                    Write("Description:");
                    description = ReadLine();
                    Write("Author:");
                    author = ReadLine();
                    Write("Keywords:");
                    keywords = ReadLine();
                    Write("Stylesheet: ");
                    css = ReadLine();
                    Write("Javascript");
                    js = ReadLine();
                    output = HtmlDoc(title, description, author, keywords, css,js);
                    WriteLine(output);
                    WriteLine(line);
                    saveHtml();
                    break;
                default:
                    WriteExit(Start, CreateHtmlPage);
                        break;
            }

            void saveHtml()
            {
                var filter = MakeFilter("ALl files",".");

                Write("Do you want to save?(y/n)\nAnswer: ");
                var ans = ReadLine();
                
                switch(ans)
                {
                    case "y":
                        SaveDialogTask("Save Html File",filter,(s,i)=>
                        {
                            //Write the File 
                            File.WriteAllText(s.FileName, output);
                            var info = new FileInfo(s.FileName);
                            WriteLine($"You have saved the {info.Name} File");
                            WriteExit(Start, CreateHtmlPage);
                        
                        });
                        break;
                    default:
                        //Just Exit 
                        WriteExit(Start, CreateHtmlPage);
                        break;
                }

            }


        }
        /// <summary>
        /// Method to create a Website project 
        /// </summary>
        static void WebsiteProject()
        { 

       
            Clear();
            WriteTitle("Website Project");

        }

        /// <summary>
        /// Method to Run the Word Press Theme Creator 
        /// </summary>
        static void WPTheme()
        {
            var name = "";
            var author = "";
            WriteTitle("Word Press Theme Creator ");
            WriteLine("Press Enter to Begin...");
            ReadLine();
            Write("Name:");
            name = ReadLine();
            Write("Author:");
            author = ReadLine();
            WriteLine("style.css");
            WriteLine(line);
            WriteLine(WPStyle(name,author));
            WriteLine(line);
            WriteLine("index.php");
            WriteLine(line);
            WriteLine(WPIndex);
            WriteLine(line);
            WriteLine("header.php");
            WriteLine(line);
            WriteLine(WPHeader);
            WriteLine(line);
            WriteLine("footer.php");
            WriteLine(line);
            WriteLine(WPFooter);
            WriteLine(line);
            WriteLine("page.php");
            WriteLine(line);
            WriteLine(WPPage);
            WriteLine(line);
            WriteLine("functions.php");
            WriteLine(line);
            WriteLine(WPFunctions);
            WriteLine(line);
            Write("Do you want to save this theme?(y/n)\nAnswer:");
            var choice = ReadLine();

            switch(choice)
            {
                case "y":
                    saveWPTheme();
                    break;
                default:
                    WriteExit(Start, WPTheme);
                    break;
            }

            void saveWPTheme()
            {
                var filter = MakeFilter("AB WordPress Theme", ".abwp");

                SaveDialogTask("Save Theme", filter, (s,i) =>
                  {
                      
                      //Grab the Directory
                      var d = new DirectoryInfo(i.DirectoryName);
                   
                      //Create main folder 
                      var main = d.CreateSubdirectory(name);
                      //Create Sub Directories 
                      main.CreateSubdirectory("images");
                      main.CreateSubdirectory("styles");
                      //Create Files 
                      CreateFile("style.css", main.FullName, WPStyle(name, author));
                      CreateFile("index.php", main.FullName, WPIndex);
                      CreateFile("header.php", main.FullName, WPHeader);
                      CreateFile("footer.php", main.FullName, WPFooter);
                      CreateFile("page.php", main.FullName, WPPage);
                      CreateFile("functions.php", main.FullName, WPFunctions);

                  });





            }


        }


    }
}
