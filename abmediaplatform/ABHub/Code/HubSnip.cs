using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Albert;
namespace ABHub.Code
{
    /// <summary>
    /// A special class design to record pecies of code
    /// </summary>
    public class HubSnip: Notify
    {
        string name, code, type;

        public string SnipName
        {
            get { return name;  }
            set { name = value; OnPropertyChanged("Name"); }

        }
        public string SnipCode
        {
            get { return code;  }
            set { code = value; OnPropertyChanged("Code"); }
        }

        public string SNopType
        {
            get { return type; }
            set { type = value; OnPropertyChanged("Type"); }
        }

        public override string ToString()
        {
            return SnipName;
        }
    }
}
