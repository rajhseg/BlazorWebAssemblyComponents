using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RWebComponents.Controls.Models
{
    public record RPopUpChartItem<T>(
        int x1, int y1, int x2, int y2, T item, int valueindex, int itemindex, string itemcolor = "gray")
    {
        public int X1 { get; set; } = x1;

        public int Y1 { get; set; } = y1;

        public int X2 { get; set; } = x2;

        public int Y2 { get; set; } = y2;

        public T Item { get; set; } = item;

        public int ValueIndex { get; set; } = valueindex;

        public int ItemIndex { get; set; } = itemindex;

        public string Itemcolor { get; set; } = itemcolor;
    }
}
