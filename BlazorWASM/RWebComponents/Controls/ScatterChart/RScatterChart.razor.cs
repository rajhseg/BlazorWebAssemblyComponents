using Microsoft.AspNetCore.Components;
using RWebComponents.Controls.Canvas;
using RWebComponents.Controls.Models;

namespace RWebComponents.Controls.ScatterChart
{
    public partial class RScatterChart : IEntity
    {

        private readonly object lockObj = new object();
        
        private List<RScatterChartItem> _items = new List<RScatterChartItem>();

        [Parameter]
        public int PlotItemSize { get; set; } = 3;

        [Parameter]
        public string ScatterContainerStyle { get; set; } = string.Empty;

        [Parameter]
        public int FontSize { get; set; } = 10;

        [Parameter]
        public string TextColor { get; set; } = "gray";

        [Parameter]
        public string XAxisTitle { get; set; } = string.Empty;

        [Parameter]
        public string YAxisTitle { get; set; } = string.Empty;

        [Parameter]
        public int NoOfSplitInXAxis { get; set; } = 4;

        [Parameter]
        public int NoOfSplitInYAxis { get; set; } = 4;

        [Parameter]
        public int Width { get; set; } = 400;

        [Parameter]
        public int Height { get; set; } = 400;

        [Parameter]
        public int MarginX { get; set; } = 50;

        [Parameter]
        public int MarginY { get; set; } = 50;

        [Parameter]
        public int DataListHeight { get; set; } = 50;

        [Parameter]
        public string PopUpBackColor { get; set; } = "lightgray";

        [Parameter]
        public string? PopUpForeColor { get; set; } = null;

        [Parameter]
        public int PopUpBackgroundOpacity { get; set; } = 1;

        [Parameter]
        public List<RScatterChartItem> Items
        {
            get
            {

                return _items;
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
                            var existList = this._items;

                            var sortedExistColl = existList.OrderBy(x => x.ItemName);
                            var sortedInputColl = inputList.OrderBy(x => x.ItemName);

                            var areEqual = sortedExistColl.SequenceEqual(sortedInputColl);

                            sameList = areEqual && inputList.Count == existList.Count();
                        }

                        if (sameList)
                        {
                            return;
                        }
                        else
                        {
                            if (inputList.Count != this._items.Count)
                            {
                                this._items.Clear();

                                if (value != null)
                                {
                                    for (var index = 0; index < value.Count(); index++)
                                    {
                                        var element = value[index];
                                        this._items.Add(element);
                                    }

                                }
                            }

                            this.RenderChart().GetAwaiter();
                            StateHasChanged();
                        }
                    }
                }
            }
        }

        public string _id { get; private set; } = string.Empty;

        private bool _isRendered = false;

        private List<RPopUpChartItem<RScatterChartItem>> popUpChartItems = [];

        private RCanvas? bar { get; set; }

        private CanvasContext? context = null;


        protected override Task OnAfterRenderAsync(bool firstRender)
        {
            if (firstRender)
            {
                if (string.IsNullOrEmpty(this._id))
                    this._id = "rscatterchart" + Guid.NewGuid().ToString().ToLower();

                if (this.bar != null)
                {
                    this.bar.ScriptLoaded = async () =>
                    {
                        await this.RenderChart();
                    };
                }
            }

            return base.OnAfterRenderAsync(firstRender);
        }

        public async Task RenderChart()
        {
            this._isRendered = false;

            if (this.bar != null && this.Items.Count > 0 && this.bar.IsScriptLoaded)
            {
                if (this.context != null)
                {
                    await this.context.ResetAsync();
                    await this.context.ResetTransformAsync();
                }

                this.context = await this.bar.CreateContext2DAsync();

                int? min = null;
                int? max = null;

                await this.context.ClearRectAsync(0, 0, this.Width, this.Height);

                var spaceFromTopYAxis = 25;
                var spaceFromRightXAxis = 25;

                List<int> xValues = [];
                List<int> yValues = [];

                for (int index = 0; index < this.Items.Count; index++)
                {
                    var element = this.Items[index];
                    var _x = element.Values.Select(x => x.XPoint);
                    var _y = element.Values.Select(y => y.YPoint);

                    xValues.AddRange(_x);
                    yValues.AddRange(_y);
                }

                if (xValues.Count > 0 && yValues.Count > 0)
                {

                    min = yValues.Min();
                    max = yValues.Max();

                    decimal ydistance = 0;

                    if (min != null && max != null)
                    {
                        ydistance = (max.Value) / this.NoOfSplitInYAxis;
                    }

                    ydistance = this.GetRoundToTenDigit(ydistance);

                    var MinLimit = 0;
                    var MaxLimit = ydistance * (this.NoOfSplitInYAxis);

                    var StartX = this.MarginX;
                    var StartY = this.Height - this.MarginY;

                    /* Draw Vertical Line */
                    await this.context.BeginPathAsync();
                    await this.context.MoveToAsync(StartX, StartY);
                    await this.context.LineToAsync(StartX, 0);
                    this.context.StrokeStyle = this.TextColor;
                    await this.context.StrokeAsync();

                    /* Draw Horizontal Line */
                    await this.context.MoveToAsync(StartX, StartY);
                    await this.context.LineToAsync(this.Width, StartY);
                    this.context.StrokeStyle = this.TextColor;
                    await this.context.StrokeAsync();
                    await this.context.ClosePathAsync();


                    /* Draw Title on x-axis */
                    await this.context.BeginPathAsync();

                    var met = await this.context.MeasureTextAsync(this.XAxisTitle);
                    double xTextPoint = (this.Width - this.MarginX) / 2 + this.MarginX;
                    xTextPoint = xTextPoint - (met.Width / 2);
                    double yTextPoint = this.Height - 10;

                    await this.context.SaveAsync();
                    this.context.FillStyle = this.TextColor;
                    await this.context.FillTextAsync(this.XAxisTitle, xTextPoint, yTextPoint);
                    await this.context.RestoreAsync();

                    await this.context.ClosePathAsync();

                    /* Draw Title On Y axis */
                    await this.context.BeginPathAsync();
                    await this.context.SaveAsync();

                    met = await this.context.MeasureTextAsync(this.XAxisTitle);
                    yTextPoint = (this.Height - this.MarginY) / 2;
                    yTextPoint = yTextPoint + (met.Width / 2);
                    xTextPoint = 15;
                    this.context.FillStyle = this.TextColor;
                    await this.context.TranslateAsync(xTextPoint, yTextPoint);
                    await this.context.RotateAsync((Math.PI / 180) * 270);
                    await this.context.FillTextAsync(this.YAxisTitle, 0, 0);

                    await this.context.RestoreAsync();
                    await this.context.ClosePathAsync();


                    /* Draw y axis line */
                    decimal yvDistance = (StartY - spaceFromTopYAxis) / this.NoOfSplitInYAxis;

                    /* Draw Y Axis */
                    for (int index = 0; index <= this.NoOfSplitInYAxis; index++)
                    {
                        decimal yDisplayValue = Math.Round(ydistance * (this.NoOfSplitInYAxis - index));
                        int yPoint = (int)Math.Round((yvDistance * index) + spaceFromTopYAxis);

                        await this.HorizontalLineInYAxis(StartX, yPoint);
                        await this.DrawHorizontalLine(StartX, yPoint);
                        await this.HorizontalLineDisplayValueInYAxis(yDisplayValue.ToString(), StartX, yPoint);
                    }

                    /* Draw X Axis Line */
                    var xmin = xValues?.Min();
                    var xmax = xValues?.Max();

                    decimal xdistance = 0;

                    if (xmin != null && xmax != null)
                    {
                        xdistance = (xmax.Value) / this.NoOfSplitInXAxis;
                    }

                    xdistance = this.GetRoundToTenDigit(xdistance);
                    decimal xvDistance = (this.Width - StartX - spaceFromRightXAxis) / this.NoOfSplitInXAxis;

                    for (int index = 1; index <= this.NoOfSplitInXAxis; index++)
                    {
                        decimal xDisplayValue = xdistance * index;
                        int xPoint = (int)(xvDistance * index) + StartX;
                        int yPoint = this.Height - this.MarginY;

                        await this.DrawVerticalLine(xPoint, yPoint);
                        await this.DrawVerticalLineInXAxis(xPoint, yPoint);
                        await this.DrawVerticalLineDisplayValueInXAxis(xDisplayValue.ToString(), xPoint, yPoint);
                    }

                    this.popUpChartItems.Clear();

                    for (int index = 0; index < this.Items.Count; index++)
                    {
                        var element = this.Items[index];

                        for (int v = 0; v < element.Values.Length; v++)
                        {
                            var item = element.Values[v];

                            var indx = item.XPoint / xdistance;
                            var xPoint = (int)(xvDistance * indx + StartX);

                            var yindx = -(item.YPoint / ydistance) + this.NoOfSplitInYAxis;
                            var yPoint = (int)(Math.Round((yvDistance * yindx) + spaceFromTopYAxis));

                            await this.Plot(xPoint, yPoint, element.Itemcolor);

                            this.popUpChartItems.Add(new RPopUpChartItem<RScatterChartItem>(xPoint, yPoint, xPoint + this.PlotItemSize,
                              yPoint + this.PlotItemSize, element, v, index, element.Itemcolor
                            ));

                        }

                    }

                }

                this._isRendered = true;

                await InvokeAsync(() => StateHasChanged());
            }
        }


        private async Task<RPopUpChartItem<RScatterChartItem>> MouseOnTopOfItem(int x, int y)
        {
            var boundaryRange = 3;

            for (int index = 0; index < this.popUpChartItems.Count; index++)
            {
                var element = this.popUpChartItems[index];
                if (x >= element.X1 - boundaryRange && x <= element.X2 + boundaryRange
                  && y >= element.Y1 - boundaryRange && y <= element.Y2 + boundaryRange)
                {
                    return element;
                }
            }

            return default;
        }

        private async Task<double> GetWidthFromString(string value)
        {
            if (this.context != null)
            {
                var metrics = await this.context.MeasureTextAsync(value);
                return metrics.Width;
            }

            return 50;
        }


        private async Task Plot(int x, int y, string color)
        {
            if (this.context != null)
            {
                await this.context.BeginPathAsync();
                this.context.StrokeStyle = color;
                this.context.FillStyle = color;
                await this.context.EllipseAsync(x, y, this.PlotItemSize, this.PlotItemSize, 0, 0, 2 * Math.PI);
                await this.context.StrokeAsync();
                await this.context.FillAsync();
                await this.context.ClosePathAsync();
            }
        }

        private async Task DrawVerticalLine(int xPoint, int yPoint)
        {
            if (this.context != null)
            {
                await this.context.BeginPathAsync();
                this.context.LineWidth = 0.2;
                this.context.StrokeStyle = this.TextColor;
                await this.context.MoveToAsync(xPoint, yPoint);
                await this.context.LineToAsync(xPoint, 0);
                await this.context.StrokeAsync();
                await this.context.ClosePathAsync();
            }
        }


        private async Task DrawVerticalLineDisplayValueInXAxis(string value, int xPoint, int yPoint)
        {
            if (this.context != null)
            {
                await this.context.BeginPathAsync();

                var met = await this.context.MeasureTextAsync(value);
                var endY = yPoint + 15;

                this.context.FillStyle = this.TextColor;
                await this.context.FillTextAsync(value, (xPoint - (met.Width / 2)), endY);
                await this.context.FillAsync();
                await this.context.StrokeAsync();
                await this.context.ClosePathAsync();
            }
        }

        private async Task DrawVerticalLineInXAxis(int xPoint, int yPoint)
        {
            if (this.context != null)
            {
                await this.context.BeginPathAsync();
                var startY = yPoint - 5;
                var endY = yPoint + 5;
                this.context.LineWidth = 1;
                this.context.StrokeStyle = this.TextColor;
                await this.context.MoveToAsync(xPoint, startY);
                await this.context.LineToAsync(xPoint, endY);
                await this.context.StrokeAsync();
                await this.context.ClosePathAsync();
            }
        }

        private decimal GetRoundToTenDigit(decimal distance)
        {
            decimal j = distance / 10;
            var roundedJ = Math.Ceiling(j);
            distance = roundedJ * 10;

            return distance;
        }

        private async Task<decimal> GetYStartPoint(int displayValue, int distance, int itemcount, int vDistance, int spaceFromTopYAxis)
        {
            decimal index = -(displayValue / distance) + this.NoOfSplitInXAxis;
            var yPoint = Math.Round((vDistance * index) + spaceFromTopYAxis);
            return yPoint;
        }

        private async Task DrawXAxisName(string name, int xPoint, int yPoint)
        {
            if (this.context != null)
            {
                var startY = yPoint;
                await this.context.BeginPathAsync();
                await this.context.MoveToAsync(xPoint, startY);
                this.context.FillStyle = this.TextColor;
                await this.context.FillTextAsync(name, xPoint, startY);
                await this.context.FillAsync();
                this.context.StrokeStyle = this.TextColor;
                await this.context.StrokeAsync();
                await this.context.ClosePathAsync();
            }
        }

        private async Task DrawBar(int startX, int startY, int xdistance, int yDistance, string color)
        {
            if (this.context != null)
            {
                await this.context.BeginPathAsync();
                this.context.FillStyle = color;
                await this.context.FillRectAsync(startX, startY, xdistance, yDistance);
                await this.context.FillAsync();
                await this.context.ClosePathAsync();
            }
        }

        private async Task HorizontalLineDisplayValueInYAxis(string value, int x, int ypoint)
        {
            if (this.context != null)
            {
                await this.context.BeginPathAsync();
                var metrics = await this.context.MeasureTextAsync(value);

                var StartX = x - 7 - metrics.Width;
                var StartY = ypoint + 3;
                var EndX = x - 7;
                var EndY = ypoint;

                this.context.FillStyle = this.TextColor;
                await this.context.MoveToAsync(StartX, StartY);
                await this.context.FillTextAsync(value, StartX, StartY);
                await this.context.FillAsync();
                await this.context.StrokeAsync();
                await this.context.ClosePathAsync();
            }
        }

        private async Task DrawHorizontalLine(int x, int ypoint)
        {
            if (this.context != null)
            {
                await this.context.BeginPathAsync();
                var startX = x;
                var endX = x + this.Width - this.MarginX;
                this.context.LineWidth = 0.2;
                this.context.StrokeStyle = this.TextColor;
                await this.context.MoveToAsync(startX, ypoint);
                await this.context.LineToAsync(endX, ypoint);
                await this.context.StrokeAsync();
                await this.context.ClosePathAsync();
            }
        }

        private async Task HorizontalLineInYAxis(int x, int ypoint)
        {
            if (this.context != null)
            {
                await this.context.BeginPathAsync();
                var StartX = x - 5;
                var StartY = ypoint;
                var EndX = x + 5;
                var EndY = ypoint;

                this.context.StrokeStyle = this.TextColor;
                await this.context.MoveToAsync(StartX, StartY);
                await this.context.LineToAsync(EndX, EndY);

                await this.context.StrokeAsync();
                await this.context.ClosePathAsync();
            }
        }

        private async Task DrawText(string text, int x, int y, string forecolor, int? rotate = null)
        {
            if (this.context != null)
            {
                await this.context.BeginPathAsync();
                this.context.StrokeStyle = forecolor;
                this.context.FillStyle = forecolor;
                await this.context.FillTextAsync(text, x, y);
                await this.context.FillAsync();
                await this.context.StrokeAsync();
                await this.context.ClosePathAsync();
            }
        }

    }
}
