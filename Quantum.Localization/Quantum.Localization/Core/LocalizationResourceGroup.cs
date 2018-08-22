using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Quantum.Localization.Core
{
    public class LocalizationResourceGroup
    {
        public string Name { get; set; }
        public Dictionary<string, string> ResourceItems { get; set; }

        public LocalizationResourceGroup()
        {
            ResourceItems = new Dictionary<string, string>();
        }
    }
}
