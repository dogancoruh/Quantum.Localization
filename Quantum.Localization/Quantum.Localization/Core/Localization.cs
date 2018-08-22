using Newtonsoft.Json.Linq;
using Quantum.Localization.Core;
using Quantum.Localization.Utilities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Quantum.Localization.Core
{
    public class Localization
    {
        public string Id { get; set; }
        public string Name { get; set; }
        public List<LocalizationResourceGroup> ResourceGroups { get; set; }

        public Localization()
        {
            ResourceGroups = new List<LocalizationResourceGroup>();
        }

        public LocalizationResourceGroup GetResourceGroup(string name)
        {
            foreach (var resourceGroup in ResourceGroups)
                if (resourceGroup.Name == name)
                    return resourceGroup;

            return null;
        }

        public static Localization Parse(JObject jObject)
        {
            var localization = new Localization();

            localization.Id = JObjectHelper.GetString(jObject, "id");
            localization.Name = JObjectHelper.GetString(jObject, "name");

            if (jObject["resourceGroups"] != null)
            {
                var jArrayResourceGroups = (JArray)jObject["resourceGroups"];
                foreach (JObject jObjectResourceGroup in jArrayResourceGroups)
                {
                    var resourceGroupName = JObjectHelper.GetString(jObjectResourceGroup, "name");

                    if (jObjectResourceGroup["resourceItems"] != null)
                    {
                        var jArrayResourceItems = (JArray)jObjectResourceGroup["resourceItems"];
                        foreach (JObject jObjectResourceItem in jArrayResourceGroups)
                        {

                        }
                    }
                }
            }

            return localization;
        }
    }
}
