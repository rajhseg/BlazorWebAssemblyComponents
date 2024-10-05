using System;
using System.Text.Json.Serialization;

namespace RWebComponents.Controls.Canvas;

public abstract class CanvasContextProperties : ICanvasContextProperties
{
    public abstract Task  SetValue(string propname, dynamic value);

    private double _globalAlpha;

    [JsonPropertyName("globalAlpha")]
    public double GlobalAlpha 
    { 
        get 
        { 
            return _globalAlpha; 
        }
        set
        {
            this._globalAlpha = value;
            this.SetValue("globalAlpha", value).GetAwaiter();
        }
    }

    private string _globalCompositeOperation;

    [JsonPropertyName("globalCompositeOperation")]
    public string GlobalCompositeOperation 
    {
        get 
        {
            return this._globalCompositeOperation;
        }
        set 
        {
            this._globalCompositeOperation = value;
            this.SetValue("globalCompositeOperation", value).GetAwaiter();
        }
    }

    private string _filter;

    [JsonPropertyName("filter")]
    public string Filter 
    {
        get 
        {
            return this._filter;
        }
        set 
        {
            this._filter =value;
            this.SetValue("filter", value).GetAwaiter();
        }
    }

    private bool _imageSmoothingEnabled;

    [JsonPropertyName("imageSmoothingEnabled")]
    public bool ImageSmoothingEnabled 
    {
        get
        {
            return this._imageSmoothingEnabled;
        }
        set 
        {
            this._imageSmoothingEnabled = value;
            this.SetValue("imageSmoothingEnabled", value).GetAwaiter();
        }
    }

    private string _imageSmoothingQuality;

    [JsonPropertyName("imageSmoothingQuality")]
    public string ImageSmoothingQuality
    {
        get 
        {
            return this._imageSmoothingQuality;
        }
        set
        {
            this._imageSmoothingQuality = value;
            this.SetValue("imageSmoothingQuality", value).GetAwaiter();
        }
    }

    private string _strokeStyle;

    [JsonPropertyName("strokeStyle")]
    public string StrokeStyle
    {
        get
        {
            return this._strokeStyle;
        }
        set
        {
            this._strokeStyle =value;
            this.SetValue("strokeStyle", value).GetAwaiter();
        }
    }

    private string _fillStyle;

    [JsonPropertyName("fillStyle")]
    public string FillStyle
    {
        get
        {
            return this._fillStyle;
        }
        set
        {
            this._fillStyle =value;
            this.SetValue("fillStyle", value).GetAwaiter();
        }
    }

    private double _shadowOffsetX;

    [JsonPropertyName("shadowOffsetX")]
    public double ShadowOffsetX
    {
        get
        {
            return this._shadowOffsetX;
        }
        set 
        {
            this._shadowOffsetX = value;
            this.SetValue("shadowOffsetX", value).GetAwaiter();
        }
    }
    
    private double _shadowOffsetY;

    [JsonPropertyName("shadowOffsetY")]
    public double ShadowOffsetY
    {
        get
        {
            return this._shadowOffsetY;
        }
        set
        {
            this._shadowOffsetY = value;
            this.SetValue("shadowOffsetY", value).GetAwaiter();
        }
    }
    
    private double _shadowBlur;

    [JsonPropertyName("shadowBlur")]
    public double ShadowBlur
    {
        get
        {
            return this._shadowBlur;
        }
        set
        {
            this._shadowBlur = value;
            this.SetValue("shadowBlur", value).GetAwaiter();
        }
    }

    private string _shadowColor;

    [JsonPropertyName("shadowColor")]    
    public string ShadowColor
    {
        get
        {
            return this._shadowColor;
        }
        set
        {
            this._shadowColor = value;
            this.SetValue("shadowColor", value).GetAwaiter();
        }
    }
    
    private double _lineWidth;

    [JsonPropertyName("lineWidth")]
    public double LineWidth
    {
        get
        {
            return this._lineWidth;
        }
        set
        {
            this._lineWidth = value;
            this.SetValue("lineWidth", value).GetAwaiter();
        }
    }
    
    private string _lineCap;

    [JsonPropertyName("lineCap")]
    public string LineCap
    {
        get
        {
            return this._lineCap;
        }
        set
        {
            this._lineCap = value;
            this.SetValue("lineCap", value).GetAwaiter();
        }
    }
    
    private string _lineJoin;

    [JsonPropertyName("lineJoin")]
    public string LineJoin 
    {
        get 
        {
            return this._lineJoin;
        }
        set
        {
            this._lineJoin = value;
            this.SetValue("lineJoin", value).GetAwaiter();
        }
    }
    
    private double _miterLimit;

    [JsonPropertyName("miterLimit")]
    public double MiterLimit
    {
        get
        {
            return this._miterLimit;
        }
        set
        {
            this._miterLimit = value;
            this.SetValue("miterLimit", value).GetAwaiter();
        }
    }
    
    private double _lineDashOffset;

    [JsonPropertyName("lineDashOffset")]
    public double LineDashOffset
    {
        get
        {
            return this._lineDashOffset;
        }
        set
        {
            this._lineDashOffset = value;
            this.SetValue("lineDashOffset", value).GetAwaiter();
        }
    }
    
    private string _font;

    [JsonPropertyName("font")]
    public string Font 
    {
        get
        {
            return this._font;
        }
        set
        {
            this._font = value;
            this.SetValue("font", value).GetAwaiter();
        }
    }
    
    private string _textAlign;

    [JsonPropertyName("textAlign")]
    public string TextAlign 
    {
        get
        {
            return this._textAlign;
        }
        set
        {
            this._textAlign = value;
            this.SetValue("textAlign", value).GetAwaiter();
        }
    }
    
    private string _textBaseline;

    [JsonPropertyName("textBaseline")]
    public string TextBaseline
    {
        get
        {
            return this._textBaseline;
        }
        set
        {
            this._textBaseline = value;
            this.SetValue("textBaseline", value).GetAwaiter();
        }
    }
    
    private string _direction;

    [JsonPropertyName("direction")]
    public string Direction
    {
        get
        {
            return this._direction;
        }
        set 
        {
            this._direction = value;
            this.SetValue("direction", value).GetAwaiter();
        }
    }
    
    private string _fontKerning;

    [JsonPropertyName("fontKerning")]
    public string FontKerning 
    {
        get
        {
            return this._fontKerning;
        }
        set
        {
            this._fontKerning = value;
            this.SetValue("fontKerning", value).GetAwaiter();
        }
    }
    
    private string _fontStretch;

    [JsonPropertyName("fontStretch")]
    public string FontStretch
    {
        get
        {
            return this._fontStretch;
        }
        set
        {
            this._fontStretch = value;
            this.SetValue("fontStretch", value).GetAwaiter();
        }
    }
    
    private string _fontVariantCaps;

    [JsonPropertyName("fontVariantCaps")]
    public string FontVariantCaps
    {
        get 
        {
            return this._fontVariantCaps;
        }
        set
        {
            this._fontVariantCaps = value;
            this.SetValue("fontVariantCaps", value).GetAwaiter();
        }
    }
    
    private string _letterSpacing;
    public string LetterSpacing
    {
        get 
        {
            return this._letterSpacing;
        }
        set
        {
            this._letterSpacing = value;
            this.SetValue("letterSpacing", value).GetAwaiter();
        }
    }
    
    private string _textRendering;

    [JsonPropertyName("textRendering")]
    public string TextRendering 
    {
        get 
        {
            return this._textRendering;
        }
        set
        {
            this._textRendering = value;
            this.SetValue("textRendering", value).GetAwaiter();
        }
    }
    
    private string _wordSpacing;

    [JsonPropertyName("wordSpacing")]
    public string WordSpacing
    {
        get
        {
            return this._wordSpacing;
        }
        set
        {
            this._wordSpacing = value;
            this.SetValue("wordSpacing", value).GetAwaiter();
        }
    }
   
}


public interface ICanvasContextProperties {    

    public double GlobalAlpha { get; set; }

    public string GlobalCompositeOperation { get; set; }

    public string Filter { get; set; }

    public bool ImageSmoothingEnabled { get; set; }

    public string ImageSmoothingQuality { get; set; }

    public string StrokeStyle { get; set; }

    public string FillStyle { get; set; }

    public double ShadowOffsetX { get; set; }
    
    public double ShadowOffsetY { get; set; }
    
    public double ShadowBlur { get; set; }
    
    public string ShadowColor { get; set; }
    
    public double LineWidth { get; set; }
    
    public string LineCap { get; set; }
    
    public string LineJoin { get; set; }
    
    public double MiterLimit { get; set; }
    
    public double LineDashOffset { get; set; }
    
    public string Font { get; set; }
    
    public string TextAlign { get; set; }
    
    public string TextBaseline { get; set; }
    
    public string Direction { get; set; }
    
    public string FontKerning { get; set; }
    
    public string FontStretch { get; set; }
    
    public string FontVariantCaps { get; set; }
    
    public string LetterSpacing { get; set; }
    
    public string TextRendering { get; set; }
    
    public string WordSpacing { get; set; }
    
}
