using System;
using System.Collections.Generic;
using System.Text;
using static System.IO.File;
using static System.Text.Json.JsonSerializer;
using abmediaplatform;
namespace abNoteBook
{
    public class NoteBookViewModel: PlatformViewModel
    {
       
  

        public NBSettingsFormat Settings
        {
            get
            {
                var json = ReadAllText("C:/AMB/Settings/abnotebooksettings.json");
                var format = Deserialize<NBSettingsFormat>(json);
                return format;
            }
        }
    }
}
