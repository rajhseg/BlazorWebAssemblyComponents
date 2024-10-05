using System;
using System.Text.Json.Serialization;

namespace RWebComponents.Controls.Canvas;


public class TextMetrics : ITextMetrics
{
    [JsonPropertyName("actualBoundingBoxAscent")]
    public double ActualBoundingBoxAscent { get; set; }


    [JsonPropertyName("actualBoundingBoxDescent")]
    public double ActualBoundingBoxDescent { get; set; }


    [JsonPropertyName("actualBoundingBoxLeft")]
    public double ActualBoundingBoxLeft { get; set; }


    [JsonPropertyName("actualBoundingBoxRight")]
    public double ActualBoundingBoxRight { get; set; }


    [JsonPropertyName("alphabeticBaseline")]
    public double AlphabeticBaseline { get; set; }


    [JsonPropertyName("emHeightAscent")]
    public double EmHeightAscent { get; set; }


    [JsonPropertyName("emHeightDescent")]
    public double EmHeightDescent { get; set; }


    [JsonPropertyName("fontBoundingBoxAscent")]
    public double FontBoundingBoxAscent { get; set; }


    [JsonPropertyName("fontBoundingBoxDescent")]
    public double FontBoundingBoxDescent { get; set; }


    [JsonPropertyName("hangingBaseline")]
    public double HangingBaseline { get; set; }


    [JsonPropertyName("ideographicBaseline")]
    public double IdeographicBaseline { get; set; }


    [JsonPropertyName("width")]
    public double Width { get; set; }
}

public interface ITextMetrics
{
    double ActualBoundingBoxAscent { get; set; }
    double ActualBoundingBoxDescent { get;  set; }
    double ActualBoundingBoxLeft { get;  set; }
    double ActualBoundingBoxRight { get;  set; }
    double AlphabeticBaseline { get;  set; }
    double EmHeightAscent { get;  set; }
    double EmHeightDescent { get;  set; }
    double FontBoundingBoxAscent { get;  set; }
    double FontBoundingBoxDescent { get;  set; }
    double HangingBaseline { get;  set; }
    double IdeographicBaseline { get;  set; }
    double Width { get;  set; }
}

