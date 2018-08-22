using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Quantum.Localization.Core
{
    public class LocalizationManager
    {
        #region Singleton Members

        private static LocalizationManager instance;

        public static LocalizationManager Instance
        {
            get
            {
                if (instance == null)
                    instance = new LocalizationManager();

                return instance;
            }
        }

        #endregion

        private readonly List<Localization> localizations;

        private string currentLocalizationId;

        public string CurrentLocalizationId
        {
            get { return currentLocalizationId; }
            set
            {
                foreach (var localization in localizations)
                {
                    if (localization.Id == currentLocalizationId)
                    {
                        currentLocalizationId = value;
                        currentLocalizationName = localization.Name;
                    }
                }
            }
        }

        private string currentLocalizationName;

        public string CurrentLocalizationName
        {
            get { return currentLocalizationName; }
            set
            {
                currentLocalizationName = value;

                foreach (var localization in localizations)
                {
                    if (localization.Name == currentLocalizationName)
                    {
                        currentLocalizationName = value;
                        currentLocalizationId = localization.Id;
                    }
                }
            }
        }

        private Localization CurrentLocalization
        {
            get
            {
                foreach (var localization in localizations)
                    if (localization.Id == currentLocalizationId)
                        return localization;

                return null;
            }
        }

        public LocalizationManager()
        {
            localizations = new List<Localization>();
        }

        public void LoadLocalization(string fileName)
        {
            var contents = File.ReadAllText(fileName, Encoding.UTF8);
            var jArrayLocalizations = JArray.Parse(contents);
            foreach (JObject jObjectLocalization in jArrayLocalizations)
            {
                var localization = Localization.Parse(jObjectLocalization);
                localizations.Add(localization);
            }
        }

        public LocalizationResourceGroup GetResourceGroup(string name)
        {
            var localization = CurrentLocalization;
            if (localization != null)
            {
                var resourceGroup = CurrentLocalization.GetResourceGroup(name);
                if (resourceGroup != null)
                    return resourceGroup;
                else
                    return null;
            }
            else
                return null;
        }

        public string GetString(string resourceName)
        {
            return GetString("default", resourceName);
        }

        public string GetString(string resourceGroupName, string resourceName)
        {
            var localization = CurrentLocalization;
            if (localization != null)
            {
                var resourceGroup = CurrentLocalization.GetResourceGroup(resourceGroupName);
                if (resourceGroup != null)
                {
                    if (resourceGroup.ResourceItems.ContainsKey(resourceName))
                        return resourceGroup.ResourceItems[resourceName];
                    else
                        return resourceName;
                }
                else
                    return resourceName;
            }
            else
                return resourceName;
        }
    }
}
