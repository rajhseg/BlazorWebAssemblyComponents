using System;
using System.Text.Json.Serialization;
using Microsoft.JSInterop;

namespace RWebComponents.Controls.Canvas;


public interface ICanvasGradient : IRsubContext
{    
    Task AddColorStopAsync(double offset, string color);
}

public class CanvasGradient : ICanvasGradient
{
    [JsonPropertyName("rsubId")]
    public string RsubId 
    {
        get; set;
    }

    public IJSObjectReference Runtime
    {
        get; set;
    }

    public async Task AddColorStopAsync(double offset, string color)
    {
        string functionName  = CanvasExtensions.GetJsFunctionName();
             await this.Runtime.InvokeVoidAsync("DispatchOperation", 
                new {prop = new dynamic[] { RsubId, functionName, offset, color }});
    }
}
