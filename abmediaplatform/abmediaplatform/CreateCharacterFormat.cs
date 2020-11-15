using System;
using System.Collections.Generic;
using System.Security.Policy;
using System.Security.RightsManagement;
using System.Text;
using System.Windows.Media;
using Albert;
namespace abmediaplatform
{
    /// <summary>
    /// Format design to discribe characters 
    /// </summary>
    public class CreateCharacterFormat : JsonFormater
    {
        public CreateCharacterFormat()
        {
            Format = "CreateCharacter";
            Description = "Format is designed to discirbe crharacters I create for games and other concepts.";
            Author = "Albert M. Byrd";
            var black = Color.FromRgb(0, 0, 0);
            var white = Color.FromRgb(255, 255, 255);
            Colors = new VMList<Color>();
            Colors.Add(black);
            Colors.Add(white);
        }

        public string Name { get; set; }
        public string Bio { get; set; }
        public GenderType Gender { get; set; }
        public VMList<Color> Colors { get; set; }
  
        
    }
    public enum GenderType
    {
        Male,Female,Other 
    }
}
