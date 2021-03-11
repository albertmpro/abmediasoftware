using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static System.IO.File;
using Albert.Win32;
using static Albert.Win32.Win32IO;
using System.Windows;
using ICSharpCode.AvalonEdit;
using System.Windows.Input;
using System.IO;

namespace ABHub.Code.Controls
{
    public class HubTextEditor : TextEditor, IAddCommand, IHubViewModel
    {

        HubViewModel vm = (HubViewModel)App.Current.Resources["viewModel"];


        public HubTextEditor()
        {
            string openTitle = "Open Text File";
            string saveTitle = "Save Text File";
            string saveasTitle = "Save Text As File";
            string filter = "All Formats(.)|*.*";
            //Open Command 
            AddCommand(ApplicationCommands.Open, (sender, e) =>
             {
                 OpenDialogTask(openTitle, filter, (o, i) =>
                   {
                       Text = ReadAllText(o.FileName);
                       CurrentFile = o.FileName;
                       VM.OpenFileAndLog(i);
                   });
             });
            //Save Command 
            AddCommand(ApplicationCommands.Save, (sender, e) =>
            {
             
                    SaveDialogTask(saveTitle, filter, (s, i) =>
                      {
                          //Save Text 
                          WriteAllText(s.FileName, Text);
                          VM.SavedFileAndLog(i);


                      });
                
            });
            //Save As Command 
            AddCommand(DesktopCommands.SaveAs, (sender, e) =>
            {
                SaveDialogTask(saveasTitle, filter, (s, i) =>
                {
                    //Save Text 
                    WriteAllText(s.FileName, Text);
                    VM.SavedFileAndLog(i);


                });
            });
        }


        public void AddCommand(ICommand _command, ExecutedRoutedEventHandler _method)
        {
            CommandBindings.Add(new CommandBinding(_command, _method));
        }

        public string CurrentFile { get; set; }

        public HubViewModel VM => vm;
    }
}
