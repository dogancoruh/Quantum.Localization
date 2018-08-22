using Quantum.Localization.Core;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Quantum.Localization.Sample
{
    static class Program
    {
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            var fileName = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "Localizations", "localization.json");
            LocalizationManager.Instance.LoadLocalization(fileName);

            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Application.Run(new FormMain());
        }
    }
}
