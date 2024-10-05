using System;
using System.Text.Json.Serialization;

namespace RWebComponents.Controls.Canvas;


public class ImageDataSettings : IImageDataSettings
{
    [JsonPropertyName("colorSpace")]
    public string ColorSpace { get; set; }
}

public interface IImageDataSettings {
    string ColorSpace {get;set;}
}
