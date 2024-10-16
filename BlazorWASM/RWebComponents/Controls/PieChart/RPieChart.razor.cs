

using Microsoft.AspNetCore.Components;
using RWebComponents.Controls.Canvas;
using RWebComponents.Controls.PieChart;

namespace RWebComponents.Controls.PieChart;

public partial class RPieChart
{
    private readonly object lockObj = new object();

    [Parameter]
    public string PieContainerStyle { get; set; }

    [Parameter]
    public int FontSize { get; set; } = 10;

    [Parameter]
    public string TextForeColor { get; set; } = "white";

    [Parameter]
    public bool RotateTextToInlineAngle { get; set; } = false;

    [Parameter]
    public bool ShowTextOnTopOfChartItem { get; set; } = true;

    [Parameter]
    public int MoveTextUpwardsFromCenterInPx { get; set; } = 0;

    [Parameter]
    public int ChartWidth { get; set; } = 200;

    public bool IsRendered = false;

    [Parameter]
    public int DataListHeight { get; set; } = 100;

    [Parameter]
    public string ShadowColor { get; set; } = "blue";

    [Parameter]
    public double ShadowBlur { get; set; } = 10;

    private string canvasStyle;

    private RCanvas piecan { get; set; }

    private CanvasContext context = null;

    private List<RRenderPieChartItem> _items = new List<RRenderPieChartItem>();

    [Parameter]
    public string Opacity { get; set; } = "1";

    private int _lineWidth = 0;

    public int LineWidth
    {
        get
        {
            this._lineWidth = (this.ChartWidth / 3) - 12;
            return this._lineWidth;
        }
    }

    [Parameter]
    public List<RPieChartItem> Items
    {
        get
        {
            return this._items.Select(x => x.ConverToItem()).ToList();
        }
        set
        {
            lock (lockObj)
            {
                if (value != null)
                {
                    var inputList = value;
                    var sameList = false;

                    if (this._items.Count > 0)
                    {
                        var existList = this._items.Select(x => x.ConverToItem());

                        var a = existList.Except(inputList).Any();
                        var b = inputList.Except(existList).Any();
                        sameList = !a && !b && inputList.Count == existList.Count();
                    }

                    if (sameList)
                    {
                        return;
                    }
                }

                this._items = new List<RRenderPieChartItem>();
                
                if (value != null)
                {
                    for (var index = 0; index < value.Count(); index++)
                    {
                        var element = value[index];
                        var itm = new RRenderPieChartItem(element.Value, element.Title, element.BackgroundColor, element.ForeColor);
                        this._items.Add(itm);
                    }
                }
            }

            this.RenderChart().GetAwaiter();
        }
    }

    protected override Task OnAfterRenderAsync(bool firstRender)
    {
        if (this.piecan != null)
        {
            this.piecan.ScriptLoaded = async () =>
            {
                await this.RenderChart();
            };
        }

        return base.OnAfterRenderAsync(firstRender);
    }

    public Tuple<double, double> GetXYForText(double x, double y, double length, double angle)
    {
        var x2 = x + length * Math.Cos(angle);
        var y2 = y + length * Math.Sin(angle);
        return Tuple.Create(x2, y2);
    }

    public async Task RenderChart()
    {
        this.IsRendered = false;
        if (this.piecan != null && this._items.Count > 0 && this.piecan.IsScriptLoaded)
        {
            if (this.context != null)
            {
                await this.context.ResetAsync();
                await this.context.ResetTransformAsync();
            }

            this.context = await this.piecan.CreateContext2DAsync();

            await this.context.ClearRectAsync(0, 0, this.piecan.Width, this.piecan.Height);
            await this.context.RestoreAsync();
            var x = this.ChartWidth / 2;
            var y = this.ChartWidth / 2;
            var radius = this.ChartWidth / 2;

            var totalValues = this._items.Select(x => x.Value).ToArray();
            double TotalCount = 0;

            for (var index = 0; index < totalValues.Count(); index++)
            {
                var element = totalValues[index];
                TotalCount = TotalCount + element;
            }

            var start = 0 * Math.PI / 180;
            var previousAngle = start;

            for (var index = 0; index < this._items.Count; index++)
            {
                var element = this._items[index];
                var percentage = (element.Value * 100) / TotalCount;
                var end1 = (percentage / 100) * 359.85 * (Math.PI / 180);

                element.Percentage = percentage;
                this.context.FillStyle = element.BackgroundColor;
                await this.context.BeginPathAsync();
                this.context.LineWidth = 0.4;

                await this.context.MoveToAsync(x, y);
                await this.context.ArcAsync(x, y, radius - 10, previousAngle, previousAngle + end1, false);
                this.context.FillStyle = element.BackgroundColor;
                this.context.StrokeStyle = "white";

                this.context.ShadowBlur = this.ShadowBlur;
                this.context.ShadowColor = this.ShadowColor;

                await this.context.FillAsync();
                await this.context.StrokeAsync();
                await this.context.ClosePathAsync();

                if (this.ShowTextOnTopOfChartItem)
                {
                    var endAngle = previousAngle + end1;
                    var avgAngle = (previousAngle + (endAngle > previousAngle ? endAngle : endAngle + ((Math.PI * 359.58) / 180))) / 2;

                    var metrics = await this.context.MeasureTextAsync(element.Title);
                    var textRadiusLength = radius - metrics.Width - 5 + this.MoveTextUpwardsFromCenterInPx;

                    var pos = this.GetXYForText(x, y, textRadiusLength, avgAngle);

                    await this.context.BeginPathAsync();

                    await this.context.SaveAsync();
                    this.context.TextAlign = "center";
                    this.context.TextBaseline = "middle";

                    await this.context.TranslateAsync(pos.Item1, pos.Item2);

                    if (this.RotateTextToInlineAngle)
                    {
                        await this.context.RotateAsync(avgAngle);
                    }
                    else
                    {
                        await this.context.RotateAsync(Math.PI / 2);
                    }

                    this.context.Font = this.FontSize + "px verdana";
                    this.context.FillStyle = this.TextForeColor;
                    await this.context.FillTextAsync(element.Title, 0, 0);

                    await this.context.StrokeAsync();
                    await this.context.RestoreAsync();
                    await this.context.ClosePathAsync();
                }

                previousAngle = previousAngle + end1;
            }

            await this.context.BeginPathAsync();
            await this.context.MoveToAsync(x, y);
            await this.context.LineToAsync(x + x - 10, y);
            this.context.LineWidth = 0.4;
            this.context.ShadowBlur = 10;
            this.context.ShadowColor = this.ShadowColor;
            await this.context.StrokeAsync();
            await this.context.FillAsync();
            await this.context.ClosePathAsync();

            this.canvasStyle = "position: absolute; transform : rotate(-90deg); opacity:" + this.Opacity + ";";

            this.IsRendered = true;

            await InvokeAsync(() => StateHasChanged());
        }
    }
}