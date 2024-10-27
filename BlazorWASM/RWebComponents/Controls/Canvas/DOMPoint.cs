


using System.Runtime.CompilerServices;
using Microsoft.JSInterop;
using System;
using System.Text.Json.Serialization;

namespace RWebComponents.Controls.Canvas;


public class DOMPoint : DOMPointReadOnly {
    
}

public class DOMPointReadOnly {

     [JsonPropertyName("rsubId")]
    public string RsubId 
    {
        get; set;
    }

    public IJSObjectReference Runtime
    {
        get; set;
    }
    
    public double? w { get; set; }
    
    public double?  x{ get; set; }
    
    public double?  y{ get; set; }
    
    public double?  z{ get; set; }
    
    public async Task<DOMPoint> MatrixTransformAsync(DOMMatrixInit matrix) {
        string functionName  = GetJsFunctionName();
        var value = await this.Runtime.InvokeAsync<DOMPoint>("DispatchOperationReturn", 
                new {prop = new dynamic[] { RsubId, functionName, matrix }});
        value.Runtime = this.Runtime;
        return value;
    }
    
    public async Task<object> ToJSONAsync() {
        string functionName  = GetJsFunctionName();
        var value = await this.Runtime.InvokeAsync<object>("DispatchOperationReturn", 
                new {prop = new dynamic[] { RsubId, functionName}});        
        return value;
    }
    
    protected string GetJsFunctionName([CallerMemberName] string method = ""){
        return char.ToLowerInvariant(method[0]).ToString() + method.Substring(1, method.Length - 6);
    }
}