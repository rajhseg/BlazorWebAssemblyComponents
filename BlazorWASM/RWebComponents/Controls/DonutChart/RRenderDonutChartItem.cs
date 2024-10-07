using System;
using System.Diagnostics.CodeAnalysis;

namespace RWebComponents.Controls.DonutChart;

public class RDonutChartComparer : IEqualityComparer<RRenderDonutChartItem>
{
    public bool Equals(RRenderDonutChartItem? x, RRenderDonutChartItem? y)
    {
        if(x==null && y==null)
        return true;

        if(x==null || y==null)
        return false;

        return x.BackgroundColor.ToLowerInvariant() == y.BackgroundColor.ToLowerInvariant() 
            && x.ForeColor.ToLowerInvariant() == y.ForeColor.ToLowerInvariant()
            && x.Title.ToLowerInvariant() == y.Title.ToLowerInvariant() 
            && x.Value == y.Value;
    }

    public int GetHashCode([DisallowNull] RRenderDonutChartItem obj)
    {
        return obj.BackgroundColor.GetHashCode() ^ obj.ForeColor.GetHashCode() ^ obj.Title.GetHashCode() 
        ^ obj.Value.GetHashCode();
    }
}

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
