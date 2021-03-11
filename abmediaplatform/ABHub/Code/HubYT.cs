using Albert;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ABHub.Code
{
    public record HubYT: JsonRecord
    {
        public HubYT()
        {
            Format = "Youtube Info ";
            Description = "Captures Youtube Info for making a video";
            Author = "ALbert M. Byrd";
        }
        public string YTScript { get; init; }

        public string YTDescription { get; init; }

        public string YTTags { get; init; }

        public string YTTopComment { get; init; }

        public void Deconstruct(out string yscript,out string yinfo,out string ytags, out string ycomment)
        {
            yscript = YTScript;
            yinfo = YTDescription;
            ytags = YTTags;
            ycomment = YTTopComment;
                
        }
    }
}
