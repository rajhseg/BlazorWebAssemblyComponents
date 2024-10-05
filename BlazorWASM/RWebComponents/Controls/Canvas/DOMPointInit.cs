using System;
using System.Text.Json.Serialization;

namespace RWebComponents.Controls.Canvas;

public class DOMPointInit : IDOMPointInit
{
    [JsonPropertyName("w")]
    public double? W { get; set; }
    
    
    [JsonPropertyName("x")]
    public double? X { get; set; }
    
    
    [JsonPropertyName("y")]
    public double? Y { get; set; }
    
    
    [JsonPropertyName("z")]
    public double? Z { get; set; }
}

public interface IDOMPointInit
{
    double? W { get; set; }

    double? X { get; set; }
    
    double? Y { get; set; }
    
    double? Z { get; set; }
}
