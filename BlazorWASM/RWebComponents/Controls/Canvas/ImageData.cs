using System;
using System.Text.Json.Serialization;

namespace RWebComponents.Controls.Canvas;

public class ImageData : IImageData
{
    [JsonPropertyName("colorSpace")]
    public string ColorSpace { get; set; }


    [JsonPropertyName("data")]
    public byte[] Data { get; set; }


    [JsonPropertyName("height")]
    public int Height { get; set; }


    [JsonPropertyName("width")]
    public int Width { get; set; }
}

public interface IImageData
{
    string ColorSpace { get; set; }
    
    byte[] Data { get; set; }
        
    int Height { get; set; }
        
    int Width { get; set; }
}

