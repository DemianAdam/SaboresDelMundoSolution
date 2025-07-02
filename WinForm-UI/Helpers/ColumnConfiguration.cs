using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace WinForm_UI.Helpers
{
    public class ColumnConfiguration
    {
        public string Name { get; set; }
        public string DisplayName { get; set; }
        public int DisplayIndex { get; set; }
        public bool Visible { get; set; }

        public ColumnConfiguration(string name, int? displayIndex = null, string? displayName = null, bool? visible = true)
        {
            Name = name;
            DisplayName = displayName ?? name;
            DisplayIndex = displayIndex ?? -1;
            Visible = visible ?? true;
        }
    }
}
