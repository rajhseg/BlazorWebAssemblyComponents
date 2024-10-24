




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
    
    public int a { get; set; }
    public int b { get; set; }
    public int c { get; set; }
    public int d { get; set; }
    public int e { get; set; }
    public int f { get; set; }
    public bool is2D { get; set; }
    public bool isIdentity { get; set; }
    public int m11 { get; set; }
    public int m12 { get; set; }
    public int  m13 { get; set; }
    public int m14 { get; set; }
    public int m21 { get; set; }
    public int m22 { get; set; }
    public int m23 { get; set; }
    public int m24 { get; set; }
    public int m31 { get; set; }
    public int m32 { get; set; }
    public int m33 { get; set; }
    public int m34 { get; set; }
    public int m41 { get; set; }
    public int m42 { get; set; }
    public int m43 { get; set; }
    public int m44 { get; set; }

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

    public async Task<DOMMatrix> RotateAsync(int? rotX = null, int? rotY = null, int? rotZ = null) {
        string functionName  = GetJsFunctionName();
        var value = await this.Runtime.InvokeAsync<DOMMatrix>("DispatchOperationReturn", 
                new {prop = new dynamic[] { RsubId, functionName, rotX, rotY, rotZ }});
        value.Runtime = this.Runtime;
        return value;
    }

    public async Task<DOMMatrix> RotateAxisAngleAsync(int? x = null, int? y = null, int? z = null, int? angle = null) {
        string functionName  = GetJsFunctionName();
        var value = await this.Runtime.InvokeAsync<DOMMatrix>("DispatchOperationReturn", 
                new {prop = new dynamic[] { RsubId, functionName, x, y, z, angle }});
        value.Runtime = this.Runtime;
        return value;
    }

    public async Task<DOMMatrix> RotateFromVectorAsync(int? x = null, int? y = null) {
        string functionName  = GetJsFunctionName();
        var value = await this.Runtime.InvokeAsync<DOMMatrix>("DispatchOperationReturn", 
                new {prop = new dynamic[] { RsubId, functionName, x, y }});
        value.Runtime = this.Runtime;
        return value;
    }

    
    public async Task<DOMMatrix> ScaleAsync(int? scaleX = null, int? scaleY = null, int? scaleZ = null, 
        int? originX = null, int? originY = null, int? originZ = null) {
        
        string functionName  = GetJsFunctionName();
        var value = await this.Runtime.InvokeAsync<DOMMatrix>("DispatchOperationReturn", 
                new {prop = new dynamic[] { RsubId, functionName, scaleX, scaleY, scaleZ, originX, originY, originZ }});
        value.Runtime = this.Runtime;
        return value;
    }

    public async Task<DOMMatrix> Scale3dAsync(int? scale = null, int? originX = null, 
                    int? originY = null, int? originZ = null) {
        string functionName  = GetJsFunctionName();
        var value = await this.Runtime.InvokeAsync<DOMMatrix>("DispatchOperationReturn", 
                new {prop = new dynamic[] { RsubId, functionName, scale, originX, originY, originZ }});
        value.Runtime = this.Runtime;
        return value;
    }
    
    public async Task<DOMMatrix> ScaleNonUniformAsync(int? scaleX = null, int? scaleY = null) {
        string functionName  = GetJsFunctionName();
        var value = await this.Runtime.InvokeAsync<DOMMatrix>("DispatchOperationReturn", 
                new {prop = new dynamic[] { RsubId, functionName, scaleX, scaleY }});
        value.Runtime = this.Runtime;
        return value;
    }

    public async Task<DOMMatrix> SkewXAsync(int? sx = null) {
        string functionName  = GetJsFunctionName();
        var value = await this.Runtime.InvokeAsync<DOMMatrix>("DispatchOperationReturn", 
                new {prop = new dynamic[] { RsubId, functionName, sx }});
        value.Runtime = this.Runtime;
        return value;
    }

    public async Task<DOMMatrix> SkewYAsync(int? sy = null) {
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

    
    public async Task<DOMMatrix> TranslateAsync(int? tx = null, int? ty = null, int? tz = null) {
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