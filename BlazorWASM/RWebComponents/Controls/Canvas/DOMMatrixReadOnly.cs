




using System.Runtime.CompilerServices;
using Microsoft.JSInterop;
using System;
using System.Text.Json.Serialization;

namespace RWebComponents.Controls.Canvas;


public class DOMMatrixReadOnly {

     [JsonPropertyName("rsubId")]
    public string RsubId 
    {
        get; set;
    }

    public IJSObjectReference Runtime
    {
        get; set;
    }
    
    public double a { get; set; }
    public double b { get; set; }
    public double c { get; set; }
    public double d { get; set; }
    public double e { get; set; }
    public double f { get; set; }
    public bool is2D { get; set; }
    public bool isIdentity { get; set; }
    public double m11 { get; set; }
    public double m12 { get; set; }
    public double  m13 { get; set; }
    public double m14 { get; set; }
    public double m21 { get; set; }
    public double m22 { get; set; }
    public double m23 { get; set; }
    public double m24 { get; set; }
    public double m31 { get; set; }
    public double m32 { get; set; }
    public double m33 { get; set; }
    public double m34 { get; set; }
    public double m41 { get; set; }
    public double m42 { get; set; }
    public double m43 { get; set; }
    public double m44 { get; set; }

    public async Task<DOMMatrix> FlipXAsync() {
        string functionName  = GetJsFunctionName();
        var value = await this.Runtime.InvokeAsync<DOMMatrix>("DispatchOperationReturn", 
                new {prop = new dynamic[] { RsubId, functionName}});
        value.Runtime = this.Runtime;
        return value;
    }

    public async Task<DOMMatrix> FlipYAsync() {
        string functionName  = GetJsFunctionName();
        var value = await this.Runtime.InvokeAsync<DOMMatrix>("DispatchOperationReturn", 
                new {prop = new dynamic[] { RsubId, functionName}});
        value.Runtime = this.Runtime;
        return value;
    }

    public async Task<DOMMatrix> InverseAsync() {
        string functionName  = GetJsFunctionName();
        var value = await this.Runtime.InvokeAsync<DOMMatrix>("DispatchOperationReturn", 
                new {prop = new dynamic[] { RsubId, functionName}});
        value.Runtime = this.Runtime;
        return value;
    }

    public async Task<DOMMatrix> MultiplyAsync(DOMMatrixInit other = null) {
        string functionName  = GetJsFunctionName();
        var value = await this.Runtime.InvokeAsync<DOMMatrix>("DispatchOperationReturn", 
                new {prop = new dynamic[] { RsubId, functionName, other}});
        value.Runtime = this.Runtime;
        return value;
    }

    public async Task<DOMMatrix> RotateAsync(double? rotX = null, double? rotY = null, double? rotZ = null) {
        string functionName  = GetJsFunctionName();
        var value = await this.Runtime.InvokeAsync<DOMMatrix>("DispatchOperationReturn", 
                new {prop = new dynamic[] { RsubId, functionName, rotX, rotY, rotZ }});
        value.Runtime = this.Runtime;
        return value;
    }

    public async Task<DOMMatrix> RotateAxisAngleAsync(double? x = null, double? y = null, double? z = null, double? angle = null) {
        string functionName  = GetJsFunctionName();
        var value = await this.Runtime.InvokeAsync<DOMMatrix>("DispatchOperationReturn", 
                new {prop = new dynamic[] { RsubId, functionName, x, y, z, angle }});
        value.Runtime = this.Runtime;
        return value;
    }

    public async Task<DOMMatrix> RotateFromVectorAsync(double? x = null, double? y = null) {
        string functionName  = GetJsFunctionName();
        var value = await this.Runtime.InvokeAsync<DOMMatrix>("DispatchOperationReturn", 
                new {prop = new dynamic[] { RsubId, functionName, x, y }});
        value.Runtime = this.Runtime;
        return value;
    }

    
    public async Task<DOMMatrix> ScaleAsync(double? scaleX = null, double? scaleY = null, double? scaleZ = null, 
        double? originX = null, double? originY = null, double? originZ = null) {
        
        string functionName  = GetJsFunctionName();
        var value = await this.Runtime.InvokeAsync<DOMMatrix>("DispatchOperationReturn", 
                new {prop = new dynamic[] { RsubId, functionName, scaleX, scaleY, scaleZ, originX, originY, originZ }});
        value.Runtime = this.Runtime;
        return value;
    }

    public async Task<DOMMatrix> Scale3dAsync(double? scale = null, double? originX = null, 
                    double? originY = null, double? originZ = null) {
        string functionName  = GetJsFunctionName();
        var value = await this.Runtime.InvokeAsync<DOMMatrix>("DispatchOperationReturn", 
                new {prop = new dynamic[] { RsubId, functionName, scale, originX, originY, originZ }});
        value.Runtime = this.Runtime;
        return value;
    }
    
    public async Task<DOMMatrix> ScaleNonUniformAsync(double? scaleX = null, double? scaleY = null) {
        string functionName  = GetJsFunctionName();
        var value = await this.Runtime.InvokeAsync<DOMMatrix>("DispatchOperationReturn", 
                new {prop = new dynamic[] { RsubId, functionName, scaleX, scaleY }});
        value.Runtime = this.Runtime;
        return value;
    }

    public async Task<DOMMatrix> SkewXAsync(double? sx = null) {
        string functionName  = GetJsFunctionName();
        var value = await this.Runtime.InvokeAsync<DOMMatrix>("DispatchOperationReturn", 
                new {prop = new dynamic[] { RsubId, functionName, sx }});
        value.Runtime = this.Runtime;
        return value;
    }

    public async Task<DOMMatrix> SkewYAsync(double? sy = null) {
        string functionName  = GetJsFunctionName();
        var value = await this.Runtime.InvokeAsync<DOMMatrix>("DispatchOperationReturn", 
                new {prop = new dynamic[] { RsubId, functionName, sy }});
        value.Runtime = this.Runtime;
        return value;
    }

    public async Task<float[]> ToFloat32ArrayAsync() {
        string functionName  = GetJsFunctionName();
        var value = await this.Runtime.InvokeAsync<float[]>("DispatchOperationReturn", 
                new {prop = new dynamic[] { RsubId, functionName}});        
        return value;
    }

    public async Task<float[]> ToFloat64ArrayAsync() {
        string functionName  = GetJsFunctionName();
        var value = await this.Runtime.InvokeAsync<float[]>("DispatchOperationReturn", 
                new {prop = new dynamic[] { RsubId, functionName}});        
        return value;
    }

    public async Task<object> ToJSONAsync() {
        string functionName  = GetJsFunctionName();
        var value = await this.Runtime.InvokeAsync<object>("DispatchOperationReturn", 
                new {prop = new dynamic[] { RsubId, functionName}});        
        return value;
    }

    public async Task<DOMPoint> TransformPointAsync(DOMPointInit point = null) {
        string functionName  = GetJsFunctionName();
        var value = await this.Runtime.InvokeAsync<DOMPoint>("DispatchOperationReturn", 
                new {prop = new dynamic[] { RsubId, functionName, point }});
        value.Runtime = this.Runtime;
        return value;
    }

    
    public async Task<DOMMatrix> TranslateAsync(double? tx = null, double? ty = null, double? tz = null) {
        string functionName  = GetJsFunctionName();
        var value = await this.Runtime.InvokeAsync<DOMMatrix>("DispatchOperationReturn", 
                new {prop = new dynamic[] { RsubId, functionName, tx, ty, tz }});
        value.Runtime = this.Runtime;
        return value;
    }

    public async Task<string> ToStringAsync() {
        string functionName  = GetJsFunctionName();
        var value = await this.Runtime.InvokeAsync<string>("DispatchOperationReturn", 
                new {prop = new dynamic[] { RsubId, functionName}});        
        return value;
    }
    
    protected string GetJsFunctionName([CallerMemberName] string method = ""){
        return char.ToLowerInvariant(method[0]).ToString() + method.Substring(1, method.Length - 6);
    }
}