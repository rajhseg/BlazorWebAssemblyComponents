using RWebComponents.Controls.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RWebComponents.Controls.ScatterChart
{
    public record RScatterChartItem(string itemname, string itemcolor, RGraph[] values = default(RGraph[]))
    {
        public string ItemName { get; set; } = itemname;

        public string Itemcolor { get; set; } = itemcolor;

        public RGraph[] Values { get; set; } = values;
    }
}
