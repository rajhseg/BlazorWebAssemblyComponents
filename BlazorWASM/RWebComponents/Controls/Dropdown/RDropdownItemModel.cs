using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RWebComponents.Controls.Dropdown
{
    internal class RDropdownItemModel(object value, string displayValue)
    {
        public object Value { get; set; } = value;
        
        public string DisplayValue { get; set; } = displayValue;

        public bool IsSelected { get; set; }
    }
}
