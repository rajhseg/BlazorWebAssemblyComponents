using System;

namespace RWebComponents.Controls.PieChart;

public class RPieChartItem
{

    public double Value { get; set; }

    public string Title { get; set; }

    public string BackgroundColor { get; set; }

    public string ForeColor { get; set; }

    public RPieChartItem(double value, string title, string backcolor, string forecolor)
    {
        this.Value = value;
        this.Title = title;
        this.BackgroundColor = backcolor;
        this.ForeColor = forecolor;
    }

    public override bool Equals(object obj)
    {
        if(obj==null)
        return false;

        RPieChartItem item = obj as RPieChartItem;

        if(item==null)
            return false;

        return Title.ToLowerInvariant() == item.Title.ToLowerInvariant()
            && BackgroundColor.ToLowerInvariant() == item.BackgroundColor.ToLowerInvariant()
            && ForeColor.ToLowerInvariant() == item.ForeColor.ToLowerInvariant()
            && Value == item.Value;
    }

    public override int GetHashCode()
    {
        return this.Title.GetHashCode() ^ this.BackgroundColor.GetHashCode()
                ^ this.ForeColor.GetHashCode() ^ this.Value.GetHashCode();
    }
}
