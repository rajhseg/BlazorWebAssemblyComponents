using System;
using System.Runtime.CompilerServices;
using System.Text.Json.Serialization;
using Microsoft.JSInterop;

namespace RWebComponents.Controls.Canvas;

public interface ICanvasEntity : IEntity
{
    string _containerId { get; }

    int Width { get; set; }

    int Height { get; set; }
}


public interface IRsubContext {
    string RsubId {get; set;}

    IJSObjectReference Runtime
    {
        get; set;
    }
}

public class CanvasCreateContext
{
    [JsonPropertyName("Id")]
    public string Id { get; set; }
}


