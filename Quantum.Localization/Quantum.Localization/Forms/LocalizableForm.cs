using Quantum.Localization.Core;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Quantum.Localization.Forms
{
    public class LocalizableForm : Form
    {
        public LocalizableForm()
        {
            Load += LocalizableForm_Load;
        }

        private void LocalizableForm_Load(object sender, EventArgs e)
        {
            LocalizeControl(this);
        }

        private void LocalizeControl(Control control)
        {
            foreach (Control control in Controls)
            {
                var controlType = control.GetType();
                var controlNamespace = controlType.Namespace;
                var controlName = control.Name;
                LocalizationManager.Instance.GetString(controlNamespace + "." + controlName, )
                if (control.Name == )
            }
        }
    }
}
