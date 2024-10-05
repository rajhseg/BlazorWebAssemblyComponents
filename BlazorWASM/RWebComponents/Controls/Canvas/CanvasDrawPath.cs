using System;
using System.Text.Json.Serialization;
using Microsoft.JSInterop;

namespace RWebComponents.Controls.Canvas;

public class CanvasDrawPath : ICanvasDrawPath
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

    public async Task BeginPathAsync()
    {
        await context.BeginPathAsync();
    }

    public async Task ClipAsync(string? fillRule = null)
    {
        await context.ClipAsync(fillRule);
    }

    public async Task ClipAsync(Path2D path, string? fillRule = null)
    {
        await context.ClipAsync(path, fillRule);
    }

    public async Task FillAsync(string? fillRule = null)
    {
        await context.FillAsync(fillRule);
    }

    public async Task FillAsync(Path2D path, string? fillRule = null)
    {
        await context.FillAsync(path, fillRule);
    }

    public async Task<bool> IsPointInPathAsync(double x, double y, string? fillRule = null)
    {
        return await context.IsPointInPathAsync(x,y,fillRule);
    }

    public async Task<bool> IsPointInPathAsync(Path2D path, double x, double y, string? fillRule = null)
    {
        return await context.IsPointInPathAsync(path, x, y, fillRule);
    }

    public async Task<bool> IsPointInStrokeAsync(double x, double y)
    {
        return await context.IsPointInStrokeAsync(x, y);
    }

    public async Task<bool> IsPointInStrokeAsync(Path2D path, double x, double y)
    {
        return await context.IsPointInStrokeAsync(path, x, y);
    }

    public async Task StrokeAsync()
    {
        await context.StrokeAsync();
    }

    public async Task StrokeAsync(Path2D path)
    {
        await context.StrokeAsync(path);
    }
}


public interface ICanvasDrawPath : IRsubContext
{    
    Task BeginPathAsync();
    
    Task ClipAsync(string? fillRule = null);

    Task ClipAsync(Path2D path, string? fillRule = null);
    
    Task FillAsync(string? fillRule = null);

    Task FillAsync(Path2D path, string? fillRule = null);
    
    Task<bool> IsPointInPathAsync(double x, double y, string? fillRule = null);

    Task<bool> IsPointInPathAsync(Path2D path, double x, double y, string? fillRule = null);
    
    Task<bool> IsPointInStrokeAsync(double x, double y);

    Task<bool> IsPointInStrokeAsync(Path2D path, double x, double y);
    
    Task StrokeAsync();

    Task StrokeAsync(Path2D path);
}

