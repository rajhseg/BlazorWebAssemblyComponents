using System;

namespace RWebComponents.Controls.DonutChart;

public class RRenderDonutChartItem : RDonutChartItem
{
    public double Percentage {get; set; } = 0;

    public RRenderDonutChartItem(double value, string title, string backcolor, string forecolor) : 
        base(value, title, backcolor, forecolor)
    {
        
    }

    public RRenderDonutChartItem(double value, string title, string backcolor, string forecolor, double percentage) : 
        base(value, title, backcolor, forecolor)
    {
        this.Percentage = percentage;
    }

    public void ConvertToRenderItem(RDonutChartItem item) 
    {
        this.Value = item.Value;
        this.Title = item.Title;
        this.BackgroundColor = item.BackgroundColor;
        this.ForeColor = item.ForeColor;
    }

    public RDonutChartItem ConverToItem()
    {
        return new RDonutChartItem(this.Value, this.Title, this.BackgroundColor, this.ForeColor);
    }
}
