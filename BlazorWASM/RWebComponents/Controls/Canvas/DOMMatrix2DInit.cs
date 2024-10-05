using System;
using System.Text.Json.Serialization;

namespace RWebComponents.Controls.Canvas;

public class DOMMatrix2DInit : IDOMMatrix2DInit
{
    [JsonPropertyName("a")]
    public double? A { get; set; }


    [JsonPropertyName("b")]
    public double? B { get; set; }
    

    [JsonPropertyName("c")]    
    public double? C { get; set; }


    [JsonPropertyName("d")]
    public double? D { get; set; }


    [JsonPropertyName("e")]
    public double? E { get; set; }


    [JsonPropertyName("f")]
    public double? F { get; set; }


    [JsonPropertyName("m11")]
    public double? M11 { get; set; }


    [JsonPropertyName("m12")]
    public double? M12 { get; set; }


    [JsonPropertyName("m21")]
    public double? M21 { get; set; }


    [JsonPropertyName("m22")]
    public double? M22 { get; set; }


    [JsonPropertyName("m41")]
    public double? M41 { get; set; }


    [JsonPropertyName("m42")]
    public double? M42 { get; set; }

}

public interface IDOMMatrix2DInit
{
    double? A { get; set; }
    double? B { get; set; }
    double? C { get; set; }
    double? D { get; set; }
    double? E { get; set; }
    double? F { get; set; }
    double? M11 { get; set; }
    double? M12 { get; set; }
    double? M21 { get; set; }
    double? M22 { get; set; }
    double? M41 { get; set; }
    double? M42 { get; set; }
}
