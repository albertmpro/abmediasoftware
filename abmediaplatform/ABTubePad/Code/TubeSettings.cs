using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Albert;
namespace ABTubePad.Code
{
    /// <summary>
    /// Record for Application Settings 
    /// </summary>
    public record TubeSettings
    {

        public string YTScript { get; init; }

        public string YTInfo { get; init; }

        public string YTTags { get; init; }

        public string YTPinComment { get; init; }

        public VMList<string> Scripts { get; init; }

        public void Deconstruct(out string ytscript, out string ytinfo, out string yttags, out string ytpincomment, out VMList<string> notes)
        {
            // Break it Down 
            ytscript = YTScript;
            ytinfo = YTInfo;
            yttags = YTTags;
            ytpincomment = YTPinComment;
            notes = Scripts;
        }
    }
}
