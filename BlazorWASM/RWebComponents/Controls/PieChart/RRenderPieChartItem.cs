using System;
using System.Diagnostics.CodeAnalysis;

namespace RWebComponents.Controls.PieChart;

public class RRenderPieChartItem: RPieChartItem
{
 public double Percentage {get; set; } = 0;

    public RRenderPieChartItem(double value, string title, string backcolor, string forecolor) : 
        base(value, title, backcolor, forecolor)
    {
        
    }

    public RRenderPieChartItem(double value, string title, string backcolor, string forecolor, double percentage) : 
        base(value, title, backcolor, forecolor)
    {
        this.Percentage = percentage;
    }

    public void ConvertToRenderItem(RPieChartItem item) 
    {
        this.Value = item.Value;
        this.Title = item.Title;
        this.BackgroundColor = item.BackgroundColor;
        this.ForeColor = item.ForeColor;
    }

    public RPieChartItem ConverToItem()
    {
        return new RPieChartItem(this.Value, this.Title, this.BackgroundColor, this.ForeColor);
    }

}


public class RPieChartComparer : IEqualityComparer<RRenderPieChartItem>
{
    public bool Equals(RRenderPieChartItem? x, RRenderPieChartItem? y)
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

    public int GetHashCode([DisallowNull] RRenderPieChartItem obj)
    {
        return obj.BackgroundColor.GetHashCode() ^ obj.ForeColor.GetHashCode() ^ obj.Title.GetHashCode() 
        ^ obj.Value.GetHashCode();
    }
}

