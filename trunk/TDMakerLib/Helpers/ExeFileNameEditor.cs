using System;
using System.Windows.Forms;
using System.Windows.Forms.Design;

namespace TDMakerLib
{
    class ExeFileNameEditor : FileNameEditor
    {
        public override object EditValue(System.ComponentModel.ITypeDescriptorContext context, IServiceProvider provider, object value)
        {
            if (context == null || provider == null)
            {
                return base.EditValue(context, provider, value);
            }
            OpenFileDialog dlg = new OpenFileDialog();
            dlg.FileName = "mtn.exe";
            dlg.Title = "Browse for MTN executable...";
            dlg.Filter = "Applications (*.exe)|*.exe";
            if (dlg.ShowDialog() == DialogResult.OK)
            {
                value = dlg.FileName;
            }
            return value;
        }
    }
}
