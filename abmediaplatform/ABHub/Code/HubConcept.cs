using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Albert;

namespace ABHub.Code
{

    /// <summary>
    /// Record stores Artboard Sizes and Colors 
    /// </summary>
    public record HubConcept : JsonRecord
    {
        public HubConcept()
        {
            Format = "Concept Properties";
            Description = "Format is designed to store Artboard siezs and Colors";
            Author = "Albert M. Byrd";

        }


        public VMList<HubColor> UsedColors { get; init; }

        public VMList<HubDrawSize> Sizes { get; init; }

        public void Deconstruct(out VMList<HubColor> colors, out VMList<HubDrawSize> sizes)
        {
            colors = UsedColors;
            sizes = Sizes;
        }


    }
}
