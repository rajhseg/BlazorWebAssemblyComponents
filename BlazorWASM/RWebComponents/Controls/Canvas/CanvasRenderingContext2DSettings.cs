using System;
using System.Text.Json.Serialization;

namespace RWebComponents.Controls.Canvas;

public class CanvasRenderingContext2DSettings
{
    [JsonPropertyName("alpha")]
    bool? Alpha {get;set;}

    [JsonPropertyName("colorSpace")]
    string? ColorSpace {get;set;}   

    [JsonPropertyName("desynchronized")]
    bool? Desynchronized {get;set;}
    
    [JsonPropertyName("willReadFrequently")]
    bool? WillReadFrequently {get;set;}
}

public interface  ICanvasRenderingContext2DSettings {
    bool? Alpha {get;set;}

    string? ColorSpace {get;set;}   
    
    bool? Desynchronized {get;set;}
    
    bool? WillReadFrequently {get;set;}
}