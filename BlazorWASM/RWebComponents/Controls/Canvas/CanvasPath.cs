using System;
using System.Text.Json.Serialization;
using Microsoft.JSInterop;

namespace RWebComponents.Controls.Canvas;


public interface ICanvasPath : IRsubContext
{
    Task ArcAsync(double x, double y, double radius, double startAngle, double endAngle, bool counterclockwise = false);

    Task ArcToAsync(double x1, double y1, double x2, double y2, double radius);
    
    Task BezierCurveToAsync(double cp1x, double cp1y, double cp2x, double cp2y, double x, double y);
    
    Task ClosePathAsync();
    
    Task EllipseAsync(double x, double y, double radiusX, double radiusY, double rotation, double startAngle, double endAngle, bool counterclockwise = false);
    
    Task LineToAsync(double x, double y);
    
    Task MoveToAsync(double x, double y);
    
    Task QuadraticCurveToAsync(double cpx, double cpy, double x, double y);
    
    Task RectAsync(double x, double y, double w, double h);
    
    Task RoundRectAsync(double x, double y, double w, double h, double? radii = null);

    Task RoundRectAsync(double x, double y, double w, double h, double[]? radii = null);

    Task RoundRectAsync(double x, double y, double w, double h, DOMPointInit? radii = null);

    Task RoundRectAsync(double x, double y, double w, double h, DOMPointInit[]? radii = null);
}


public class CanvasPath : ICanvasPath
{
    protected CanvasContext context = new CanvasContext();

    private string _rsubid;    

    [JsonPropertyName("rsubId")]
    public string RsubId 
    {
        get
        {
            return this._rsubid;
        }
        set
        {
            this._rsubid = value;
            context.SetProps(value, Runtime);
        }
    }

    private IJSObjectReference runtime;
    public IJSObjectReference Runtime
    {
        get 
        {
            return this.runtime;
        }
        set
        {
            this.runtime = value;
            context.SetProps(_rsubid, value);
        }
    }

    public async Task ArcAsync(double x, double y, double radius, double startAngle, double endAngle,
        bool counterclockwise = false)
    {        
        await context.ArcAsync(x, y, radius, startAngle, endAngle, counterclockwise);
    }

    public async Task ArcToAsync(double x1, double y1, double x2, double y2, double radius)
    {        
        await context.ArcToAsync(x1, y1, x2, y2, radius);   
    }


    
    public async Task BezierCurveToAsync(double cp1x, double cp1y, double cp2x, double cp2y, double x, double y)
    {
        await context.BezierCurveToAsync(cp1x, cp1y, cp2x, cp2y, x, y);
    }

    public async Task ClosePathAsync()
    {
        await context.ClosePathAsync();
    }

    public async Task EllipseAsync(double x, double y, double radiusX, double radiusY, double rotation, double startAngle, double endAngle, bool counterclockwise = false)
    {
        await EllipseAsync(x, y, radiusX, radiusY, rotation, startAngle, endAngle, counterclockwise);
    }

    public async Task LineToAsync(double x, double y)
    {
        await context.LineToAsync(x,y);
    }

    public async Task MoveToAsync(double x, double y)
    {
        await context.MoveToAsync(x, y);
    }

    public async Task QuadraticCurveToAsync(double cpx, double cpy, double x, double y)
    {
        await context.QuadraticCurveToAsync(cpx, cpy, x, y);
    }

    public async Task RectAsync(double x, double y, double w, double h)
    {
        await context.RectAsync(x, y, w, h);
    }

    public async Task RoundRectAsync(double x, double y, double w, double h, double? radii = null)
    {
        await context.RoundRectAsync(x, y, w, h, radii);
    }

    public async Task RoundRectAsync(double x, double y, double w, double h, double[]? radii = null)
    {
        await context.RoundRectAsync(x, y, w, h, radii);
    }

    public async Task RoundRectAsync(double x, double y, double w, double h, DOMPointInit? radii = null)
    {
        await context.RoundRectAsync(x, y, w, h, radii);
    }

    public async Task RoundRectAsync(double x, double y, double w, double h, DOMPointInit[]? radii = null)
    {
        await context.RoundRectAsync(x, y, w, h, radii);
    }
}

