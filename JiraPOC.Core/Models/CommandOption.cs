using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JiraPOC.Core.Models
{
    public class CommandOption
    {
        public string name { get; set; }
        public string description { get; set; }
        public string defaultValue { get; set; }
        public List<string> alias { get; set; }

        public bool isRequired { get; set; }

        public bool multipleArgs { get; set; }
    }
}
