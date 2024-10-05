using System;
using System.Text.Json.Serialization;
using Microsoft.JSInterop;

namespace RWebComponents.Controls.Canvas;

public class CanvasPattern : ICanvasPattern, IRsubContext
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

    public async Task SetTransformAsync(DOMMatrix2DInit? transform = null)
    {
        string functionName  = CanvasExtensions.GetJsFunctionName();
        await this.Runtime.InvokeVoidAsync("DispatchOperation", new {prop = new dynamic[] { RsubId, functionName, transform }});
    }
}



public interface ICanvasPattern {    
    Task SetTransformAsync(DOMMatrix2DInit? transform = null);
}
