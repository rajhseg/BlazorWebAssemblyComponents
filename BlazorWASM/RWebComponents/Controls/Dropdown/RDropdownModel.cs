using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RWebComponents.Controls.Dropdown
{
    public class RDropdownModel(object value, string displayValue)
    {
        public object Value { get; set; } = value;

        public string DisplayValue { get; set; } = displayValue;
    }
}
