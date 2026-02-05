using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RWebComponents.Controls.Models
{
    public record RGraph(int xPoint, int yPoint)
    {
        public int XPoint { get; set; } = xPoint;

        public int YPoint { get; set; } = yPoint;
    }
}
