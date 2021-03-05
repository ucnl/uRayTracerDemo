using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace uRayTracerDemo
{
    public static class UIUtils
    {
        public static void TrySetCbxItem(ComboBox cbx, string item)
        {
            int idx = cbx.Items.IndexOf(item);
            if (idx >= 0)
                cbx.SelectedIndex = idx;
        }

        public static string TryGetCbxItem(ComboBox cbx)
        {
            if (cbx.SelectedItem == null)
                return string.Empty;
            else
                return cbx.SelectedItem.ToString();
        }

        public static void TrySetNEditValue(NumericUpDown nedit, double value)
        {
            decimal vl = Convert.ToDecimal(value);
            if (vl > nedit.Maximum) vl = nedit.Maximum;
            if (vl < nedit.Minimum) vl = nedit.Minimum;

            nedit.Value = vl;
        }
    }

}
