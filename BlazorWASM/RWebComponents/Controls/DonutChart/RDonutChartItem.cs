using System;

namespace RWebComponents.Controls.DonutChart;

public class RDonutChartItem
{
    public double Value { get; set; }

    public string Title { get; set; }

    public string BackgroundColor { get; set; }

    public string ForeColor { get; set; }

    public RDonutChartItem(double value, string title, string backcolor, string forecolor)
    {
        this.Value = value;
        this.Title = title;
        this.BackgroundColor = backcolor;
        this.ForeColor = forecolor;
    }
}
