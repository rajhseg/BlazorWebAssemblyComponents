




using System.Runtime.CompilerServices;
using Microsoft.JSInterop;
using System;
using System.Text.Json.Serialization;

namespace RWebComponents.Controls.Canvas;


public class DOMMatrix: DOMMatrixReadOnly {   

    public int a { set; get; }
    public int b { set; get; }
    public int c { set; get; }
    public int d { set; get; }
    public int e { set; get; }
    public int f { set; get; }
    public int m11 { set; get; }
    public int m12 { set; get; }
    public int m13 { set; get; }
    public int m14 { set; get; }
    public int m21 { set; get; }
    public int m22 { set; get; }
    public int m23 { set; get; }
    public int m24 { set; get; }
    public int m31 { set; get; }
    public int m32 { set; get; }
    public int m33 { set; get; }
    public int m34 { set; get; }
    public int m41 { set; get; }
    public int m42 { set; get; }
    public int m43 { set; get; }
    public int m44 { set; get; }
    
    public async Task<DOMMatrix> InvertSelfAsync() {
        string functionName  = GetJsFunctionName();
        var value = await this.Runtime.InvokeAsync<DOMMatrix>("DispatchOperationReturn", 
                new {prop = new dynamic[] { RsubId, functionName}});
        value.Runtime = this.Runtime;
        return value;
    }

    public async Task<DOMMatrix> MultiplySelfAsync(DOMMatrixInit other = null) {
        string functionName  = GetJsFunctionName();
        var value = await this.Runtime.InvokeAsync<DOMMatrix>("DispatchOperationReturn", 
                new {prop = new dynamic[] { RsubId, functionName, other }});
        value.Runtime = this.Runtime;
        return value;
    }

    public async Task<DOMMatrix> PreMultiplySelfAsync(DOMMatrixInit other = null) {
        string functionName  = GetJsFunctionName();
        var value = await this.Runtime.InvokeAsync<DOMMatrix>("DispatchOperationReturn", 
                new {prop = new dynamic[] { RsubId, functionName, other}});
        value.Runtime = this.Runtime;
        return value;
    }

    public async Task<DOMMatrix> RotateAxisAngleSelfAsync(int? x = null, int? y = null, int? z = null, int? angle = null) {
        string functionName  = GetJsFunctionName();
        var value = await this.Runtime.InvokeAsync<DOMMatrix>("DispatchOperationReturn", 
                new {prop = new dynamic[] { RsubId, functionName, x, y, z, angle }});
        value.Runtime = this.Runtime;
        return value;
    }

    public async Task<DOMMatrix> RotateFromVectorSelfAsync(int? x = null, int? y = null) {
        string functionName  = GetJsFunctionName();
        var value = await this.Runtime.InvokeAsync<DOMMatrix>("DispatchOperationReturn", 
                new {prop = new dynamic[] { RsubId, functionName, x, y }});
        value.Runtime = this.Runtime;
        return value;
    }

    public async Task<DOMMatrix> RotateSelfAsync(int? rotX = null, int? rotY = null, int? rotZ = null) {
        string functionName  = GetJsFunctionName();
        var value = await this.Runtime.InvokeAsync<DOMMatrix>("DispatchOperationReturn", 
                new {prop = new dynamic[] { RsubId, functionName, rotX, rotY, rotZ }});
        value.Runtime = this.Runtime;
        return value;
    }

    public async Task<DOMMatrix> Scale3dSelfAsync(int? scale = null, int? originX = null, int? originY = null, 
        int? originZ = null) {
        string functionName  = GetJsFunctionName();
        var value = await this.Runtime.InvokeAsync<DOMMatrix>("DispatchOperationReturn", 
                new {prop = new dynamic[] { RsubId, functionName, scale, originX, originY, originZ }});
        value.Runtime = this.Runtime;
        return value;
    }

    public async Task<DOMMatrix> ScaleSelfAsync(int? scaleX = null, int? scaleY = null, int? scaleZ = null, 
        int? originX = null, int? originY = null, int? originZ = null) {
        string functionName  = GetJsFunctionName();
        var value = await this.Runtime.InvokeAsync<DOMMatrix>("DispatchOperationReturn", 
                new {prop = new dynamic[] { RsubId, functionName, scaleX, scaleY, scaleZ, originX, originY, originZ }});
        value.Runtime = this.Runtime;
        return value;
    }

    public async Task<DOMMatrix> SetMatrixValueAsync(string transformList) {
        string functionName  = GetJsFunctionName();
        var value = await this.Runtime.InvokeAsync<DOMMatrix>("DispatchOperationReturn", 
                new {prop = new dynamic[] { RsubId, functionName, transformList}});
        value.Runtime = this.Runtime;
        return value;
    }

    public async Task<DOMMatrix> SkewXSelfAsync(int? sx = null) {
        string functionName  = GetJsFunctionName();
        var value = await this.Runtime.InvokeAsync<DOMMatrix>("DispatchOperationReturn", 
                new {prop = new dynamic[] { RsubId, functionName, sx }});
        value.Runtime = this.Runtime;
        return value;
    }

    public async Task<DOMMatrix> SkewYSelfAsync(int? sy = null) {
        string functionName  = GetJsFunctionName();
        var value = await this.Runtime.InvokeAsync<DOMMatrix>("DispatchOperationReturn", 
                new {prop = new dynamic[] { RsubId, functionName, sy }});
        value.Runtime = this.Runtime;
        return value;
    }

    public async Task<DOMMatrix> TranslateSelfAsync(int? tx = null, int? ty = null, int? tz = null) {
        string functionName  = GetJsFunctionName();
        var value = await this.Runtime.InvokeAsync<DOMMatrix>("DispatchOperationReturn", 
                new {prop = new dynamic[] { RsubId, functionName, tx, ty, tz }});
        value.Runtime = this.Runtime;
        return value;
    }

}