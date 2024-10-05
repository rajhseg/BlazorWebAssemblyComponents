using System;
using Microsoft.JSInterop;

namespace RWebComponents.Controls.Canvas;


public interface IPath2D : ICanvasPath
{
    Task AddPathAsync(Path2D path, DOMMatrix2DInit? transform = null);
}

public class Path2D : CanvasPath, IPath2D
{
    public Path2D(string canvasContextIdOrRsubId, IJSObjectReference runtime)
    {
        this.RsubId = canvasContextIdOrRsubId;
        this.Runtime = runtime;   
    }

    public async Task AddPathAsync(Path2D path, DOMMatrix2DInit? transform = null)
    {
         string functionName  = CanvasExtensions.GetJsFunctionName();
             await this.Runtime.InvokeVoidAsync("DispatchOperation", 
                new {prop = new dynamic[] { this.RsubId, functionName, path, transform }});
    }
}