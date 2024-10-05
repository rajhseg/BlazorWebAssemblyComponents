using System;
using System.Runtime.CompilerServices;
using Microsoft.JSInterop;

namespace RWebComponents.Controls.Canvas;


public class CanvasContextFunctions : CanvasContextProperties, ICanvasContextFunctions
{
    private string Id;
    private IJSObjectReference Runtime;

    public CanvasContextFunctions()
    {
        
    }

    public void SetProps(string id, IJSObjectReference js){
        this.Id = id;
        this.Runtime = js;
    }

    public string GetCanvasContextId()
    {
        return this.Id;
    }

    public IJSObjectReference GetJsModuleRuntime()
    {
        return this.Runtime;
    }

    public async Task ArcAsync(double x, double y, double radius, double startAngle, double endAngle,
        bool counterclockwise = false)
    {
        string? methodName = System.Reflection.MethodBase.GetCurrentMethod()?.Name;
        
        if(methodName!=null){
            string functionName  = GetJsFunctionName();
             await this.Runtime.InvokeVoidAsync("DispatchOperation", 
                new {prop = new dynamic[] { Id, functionName, x, y, radius, startAngle, endAngle, counterclockwise }});
        }
    }

    public async Task ArcToAsync(double x1, double y1, double x2, double y2, double radius)
    {
        string? methodName = System.Reflection.MethodBase.GetCurrentMethod()?.Name;
        
        if(methodName!=null){
            string functionName  = GetJsFunctionName();
             await this.Runtime.InvokeVoidAsync("DispatchOperation", 
                new {prop = new dynamic[] { Id, functionName, x1, y1, x2, y2, radius }});
        }
    }

    public async Task BeginPathAsync()
    {        
        string methodName = nameof(BeginPathAsync);
        
        if(methodName!=null){
            string functionName  = GetJsFunctionName();
             await this.Runtime.InvokeVoidAsync("DispatchOperation", 
                new {prop = new dynamic[] { Id, functionName }});
        }
    }

    public async Task BezierCurveToAsync(double cp1x, double cp1y, double cp2x, double cp2y, double x, double y)
    {
        string? methodName = System.Reflection.MethodBase.GetCurrentMethod()?.Name;
        
        if(methodName!=null){
            string functionName  = GetJsFunctionName();
             await this.Runtime.InvokeVoidAsync("DispatchOperation", 
                new {prop = new dynamic[] { Id, functionName, cp1x, cp1y, cp2x, cp2y, x, y }});
        }
    }

    public async Task ClearRectAsync(double x, double y, double w, double h)
    {
        string? methodName = System.Reflection.MethodBase.GetCurrentMethod()?.Name;
        
        if(methodName!=null){
            string functionName  = GetJsFunctionName();
             await this.Runtime.InvokeVoidAsync("DispatchOperation", 
                new {prop = new dynamic[] { Id, functionName, x, y, w, h }});
        }
    }

    public async Task ClipAsync(string? fillRule = null)
    {
        string? methodName = System.Reflection.MethodBase.GetCurrentMethod()?.Name;
        
        if(methodName!=null){
            string functionName  = GetJsFunctionName();
             await this.Runtime.InvokeVoidAsync("DispatchOperation", 
                new {prop = new dynamic[] { Id, functionName, fillRule }});
        }
    }

    public async Task ClipAsync(Path2D path, string? fillRule = null)
    {
        string? methodName = System.Reflection.MethodBase.GetCurrentMethod()?.Name;
        
        if(methodName!=null){
            string functionName  = GetJsFunctionName();
             await this.Runtime.InvokeVoidAsync("DispatchOperation", 
                new {prop = new dynamic[] { Id, functionName, path, fillRule }});
        }
    }

    public async Task ClosePathAsync()
    {
        string? methodName = System.Reflection.MethodBase.GetCurrentMethod()?.Name;
        
        if(methodName!=null){
            string functionName  = GetJsFunctionName();
             await this.Runtime.InvokeVoidAsync("DispatchOperation", 
                new {prop = new dynamic[] { Id, functionName }});
        }
    }

    public async Task<CanvasGradient> CreateConicGradientAsync(double startAngle, double x, double y)
    {
        string? methodName = System.Reflection.MethodBase.GetCurrentMethod()?.Name;
        CanvasGradient value = null;

        if(methodName!=null){
            string functionName  = GetJsFunctionName();
            
            value = await this.Runtime.InvokeAsync<CanvasGradient>("DispatchOperationReturn", 
                new {prop = new dynamic[] { Id, functionName, startAngle, x, y }});
            
            value.Runtime = this.Runtime;
        }

        return value;
    }

    public async Task<ImageData> CreateImageDataAsync(double sw, double sh, ImageDataSettings settings = null)
    {
        string? methodName = System.Reflection.MethodBase.GetCurrentMethod()?.Name;
        ImageData data = null;

        if(methodName!=null){
            string functionName  = GetJsFunctionName();
             data = await this.Runtime.InvokeAsync<ImageData>("DispatchOperationReturn", 
                new {prop = new dynamic[] { Id, functionName, sw, sh, settings }});            
        }

        return data;
    }

    public async Task<ImageData> CreateImageDataAsync(ImageData imageData)
    {
        string? methodName = System.Reflection.MethodBase.GetCurrentMethod()?.Name;
        ImageData data = null;

        if(methodName!=null){
            string functionName  = GetJsFunctionName();
             data = await this.Runtime.InvokeAsync<ImageData>("DispatchOperationReturn", 
                new {prop = new dynamic[] { Id, functionName, imageData }});
        }

        return data;
    }

    public async Task<CanvasGradient> CreateLinearGradientAsync(double x0, double y0, double x1, double y1)
    {
        string? methodName = System.Reflection.MethodBase.GetCurrentMethod()?.Name;
        CanvasGradient value = null;

        if(methodName!=null){
            string functionName  = GetJsFunctionName();
            value = await this.Runtime.InvokeAsync<CanvasGradient>("DispatchOperationReturn", 
                new {prop = new dynamic[] { Id, functionName, x0, y0, x1, y1}});
            
            value.Runtime = this.Runtime;
        }

        return value;
    }

    public async Task<CanvasPattern> CreatePatternAsync(dynamic image, string repetition)
    {
        string? methodName = System.Reflection.MethodBase.GetCurrentMethod()?.Name;
        CanvasPattern value = null;

        if(methodName!=null){
            string functionName  = GetJsFunctionName();
            value = await this.Runtime.InvokeAsync<CanvasPattern>("DispatchOperationReturn", 
                new {prop = new dynamic[] { Id, functionName, image, repetition }});
            value.Runtime = Runtime;
        }

        return value;
    }

    public async Task<CanvasGradient> CreateRadialGradientAsync(double x0, double y0, double r0, 
        double x1, double y1, double r1)
    {
        string? methodName = System.Reflection.MethodBase.GetCurrentMethod()?.Name;
        CanvasGradient value = null;

        if(methodName!=null){
            string functionName  = GetJsFunctionName();
            value = await this.Runtime.InvokeAsync<CanvasGradient>("DispatchOperationReturn", 
                new {prop = new dynamic[] { Id, functionName, x0, y0, r0, x1, y1, r1 }});

            value.Runtime = this.Runtime;
        }

        return value;
    }

    public async Task DrawFocusIfNeededAsync(dynamic element)
    {
        string? methodName = System.Reflection.MethodBase.GetCurrentMethod()?.Name;
        
        if(methodName!=null){
            string functionName  = GetJsFunctionName();
             await this.Runtime.InvokeVoidAsync("DispatchOperation", 
                new {prop = new dynamic[] { Id, functionName, element }});
        }
    }

    public async Task DrawFocusIfNeededAsync(Path2D path, dynamic element)
    {
        string? methodName = System.Reflection.MethodBase.GetCurrentMethod()?.Name;
        
        if(methodName!=null){
            string functionName  = GetJsFunctionName();
             await this.Runtime.InvokeVoidAsync("DispatchOperation", 
                new {prop = new dynamic[] { Id, functionName, path, element }});
        }
    }

    public async Task DrawImageAsync(dynamic image, double destinationX, double destinationY)
    {
        string? methodName = System.Reflection.MethodBase.GetCurrentMethod()?.Name;
        
        if(methodName!=null){
            string functionName  = GetJsFunctionName();
             await this.Runtime.InvokeVoidAsync("DispatchOperation", 
                new {prop = new dynamic[] { Id, functionName, image, destinationX, destinationY }});
        }
    }

    public async Task DrawImageAsync(dynamic image, double destinationX, double destinationY, 
        double destinationWidth, double destinationHeight)
    {
        string? methodName = System.Reflection.MethodBase.GetCurrentMethod()?.Name;
        
        if(methodName!=null){
            string functionName  = GetJsFunctionName();
             await this.Runtime.InvokeVoidAsync("DispatchOperation", 
                new {prop = new dynamic[] { Id, functionName, image, destinationX, destinationY, destinationWidth, destinationHeight }});
        }
    }

    public async Task DrawImageAsync(dynamic image, double sourceX, double sourceY, double sourceWidth, 
        double sourceHeight, double destinationX, double destinationY, double destinationWidth, 
        double destinationHeight)
    {
        string? methodName = System.Reflection.MethodBase.GetCurrentMethod()?.Name;
        
        if(methodName!=null){
            string functionName  = GetJsFunctionName();
             await this.Runtime.InvokeVoidAsync("DispatchOperation", 
                new {prop = new dynamic[] { Id, functionName, image, sourceX, sourceY, sourceWidth,
                    sourceHeight, destinationX, destinationY, destinationWidth, destinationHeight }});
        }
    }

    public async Task EllipseAsync(double x, double y, double radiusX, double radiusY, double rotation, double startAngle, double endAngle, bool counterclockwise = false)
    {
        string? methodName = System.Reflection.MethodBase.GetCurrentMethod()?.Name;
        
        if(methodName!=null){
            string functionName  = GetJsFunctionName();
             await this.Runtime.InvokeVoidAsync("DispatchOperation", 
                new {prop = new dynamic[] { Id, functionName, x, y, radiusX, radiusY, rotation, startAngle, endAngle, counterclockwise }});
        }
    }

    public async Task FillAsync(string? fillRule = null)
    {
        string? methodName = System.Reflection.MethodBase.GetCurrentMethod()?.Name;
        
        if(methodName!=null){
            string functionName  = GetJsFunctionName();
             await this.Runtime.InvokeVoidAsync("DispatchOperation", 
                new {prop = new dynamic[] { Id, functionName, fillRule }});
        }
    }

    public async Task FillAsync(Path2D path, string? fillRule = null)
    {
        string? methodName = System.Reflection.MethodBase.GetCurrentMethod()?.Name;
        
        if(methodName!=null){
            string functionName  = GetJsFunctionName();
             await this.Runtime.InvokeVoidAsync("DispatchOperation", 
                new {prop = new dynamic[] { Id, functionName, path, fillRule }});
        }
    }

    public async Task FillRectAsync(double x, double y, double w, double h)
    {
        string? methodName = System.Reflection.MethodBase.GetCurrentMethod()?.Name;
        
        if(methodName!=null){
            string functionName  = GetJsFunctionName();
             await this.Runtime.InvokeVoidAsync("DispatchOperation", 
                new {prop = new dynamic[] { Id, functionName, x, y, w ,h }});
        }
    }

    public async Task FillTextAsync(string text, double x, double y, double? maxWidth = null)
    {
        string? methodName = System.Reflection.MethodBase.GetCurrentMethod()?.Name;
        
        if(methodName!=null){
            string functionName  = GetJsFunctionName();
             await this.Runtime.InvokeVoidAsync("DispatchOperation", 
                new {prop = new dynamic[] { Id, functionName, text, x, y , maxWidth}});
        }
    }

    public async Task<ImageData> GetImageDataAsync(double sx, double sy, double sw, double sh, ImageDataSettings settings = null)
    {
        string? methodName = System.Reflection.MethodBase.GetCurrentMethod()?.Name;
        ImageData data = null;

        if(methodName!=null){
            string functionName  = GetJsFunctionName();
             data = await this.Runtime.InvokeAsync<ImageData>("DispatchOperationReturn", 
                new {prop = new dynamic[] { Id, functionName, sx, sy, sw, sh, settings }});
        }

        return data;
    }

    public async Task<double[]> GetLineDashAsync()
    {
        string? methodName = System.Reflection.MethodBase.GetCurrentMethod()?.Name;
        double[] a = [];

        if(methodName!=null){
            string functionName  = GetJsFunctionName();
             a = await this.Runtime.InvokeAsync<double[]>("DispatchOperationReturn", 
                new {prop = new dynamic[] { Id, functionName }});
        }

        return a;
    }

    public async Task<bool> IsPointInPathAsync(double x, double y, string? fillRule = null)
    {
        string? methodName = System.Reflection.MethodBase.GetCurrentMethod()?.Name;
        bool value = false;

        if(methodName!=null){
            string functionName  = GetJsFunctionName();
             value = await this.Runtime.InvokeAsync<bool>("DispatchOperationReturn", 
                new {prop = new dynamic[] { Id, functionName, x, y, fillRule }});
        }

        return value;
    }

    public async Task<bool> IsPointInPathAsync(Path2D path, double x, double y, string? fillRule = null)
    {
        string? methodName = System.Reflection.MethodBase.GetCurrentMethod()?.Name;
        bool value = false;

        if(methodName!=null){
            string functionName  = GetJsFunctionName();
             value = await this.Runtime.InvokeAsync<bool>("DispatchOperationReturn", 
                new {prop = new dynamic[] { Id, functionName, path, x, y, fillRule }});
        }

        return value;
    }

    public async Task<bool> IsPointInStrokeAsync(double x, double y)
    {
        string? methodName = System.Reflection.MethodBase.GetCurrentMethod()?.Name;
        bool value = false;

        if(methodName!=null){
            string functionName  = GetJsFunctionName();
             value = await this.Runtime.InvokeAsync<bool>("DispatchOperationReturn", 
                new {prop = new dynamic[] { Id, functionName, x, y }});
        }

        return value;
    }

    public async Task<bool> IsPointInStrokeAsync(Path2D path, double x, double y)
    {
        string? methodName = System.Reflection.MethodBase.GetCurrentMethod()?.Name;
        bool value = false;

        if(methodName!=null){
            string functionName  = GetJsFunctionName();
             value = await this.Runtime.InvokeAsync<bool>("DispatchOperationReturn", 
                new {prop = new dynamic[] { Id, functionName, path, x, y }});
        }
        return value;
    }

    public async Task LineToAsync(double x, double y)
    {
        string? methodName = System.Reflection.MethodBase.GetCurrentMethod()?.Name;
        
        if(methodName!=null){
            string functionName  = GetJsFunctionName();
             await this.Runtime.InvokeVoidAsync("DispatchOperation", 
                new {prop = new dynamic[] { Id, functionName, x, y }});
        }
    }

    public async Task<TextMetrics> MeasureTextAsync(string text)
    {
        string? methodName = System.Reflection.MethodBase.GetCurrentMethod()?.Name;
        TextMetrics value = null;

        if(methodName!=null){
            string functionName  = GetJsFunctionName();
            value = await this.Runtime.InvokeAsync<TextMetrics>("DispatchOperationReturn", 
                new {prop = new dynamic[] { Id, functionName, text }});
        }

        return value;
    }

    public async Task MoveToAsync(double x, double y)
    {
        string? methodName = System.Reflection.MethodBase.GetCurrentMethod()?.Name;
        
        if(methodName!=null){
            string functionName  = GetJsFunctionName();
             await this.Runtime.InvokeVoidAsync("DispatchOperation", 
                new {prop = new dynamic[] { Id, functionName, x, y }});
        }
    }

    public async Task PutImageDataAsync(ImageData imagedata, double dx, double dy, double dirtyX, double dirtyY, double dirtyWidth, double dirtyHeight)
    {
        string? methodName = System.Reflection.MethodBase.GetCurrentMethod()?.Name;
        
        if(methodName!=null){
            string functionName  = GetJsFunctionName();
             await this.Runtime.InvokeVoidAsync("DispatchOperation", 
                new {prop = new dynamic[] { Id, functionName, imagedata, dx, dy, dirtyX, dirtyY, dirtyWidth, dirtyHeight }});
        }
    }

    public async Task PutImageDataAsync(ImageData imagedata, double dx, double dy)
    {
        string? methodName = System.Reflection.MethodBase.GetCurrentMethod()?.Name;
        
        if(methodName!=null){
            string functionName  = GetJsFunctionName();
             await this.Runtime.InvokeVoidAsync("DispatchOperation", 
                new {prop = new dynamic[] { Id, functionName, imagedata, dx, dy }});
        }
    }

    public async Task QuadraticCurveToAsync(double cpx, double cpy, double x, double y)
    {
        string? methodName = System.Reflection.MethodBase.GetCurrentMethod()?.Name;
        
        if(methodName!=null){
            string functionName  = GetJsFunctionName();
             await this.Runtime.InvokeVoidAsync("DispatchOperation", 
                new {prop = new dynamic[] { Id, functionName, cpx, cpy, x, y }});
        }
    }

    public async Task RectAsync(double x, double y, double w, double h)
    {
        string? methodName = System.Reflection.MethodBase.GetCurrentMethod()?.Name;
        
        if(methodName!=null){
            string functionName  = GetJsFunctionName();
             await this.Runtime.InvokeVoidAsync("DispatchOperation", 
                new {prop = new dynamic[] { Id, functionName, x, y, w, h }});
        }
    }

    public async Task ResetAsync()
    {
        string? methodName = System.Reflection.MethodBase.GetCurrentMethod()?.Name;
        
        if(methodName!=null){
            string functionName  = GetJsFunctionName();
             await this.Runtime.InvokeVoidAsync("DispatchOperation", 
                new {prop = new dynamic[] { Id, functionName }});
        }
    }

    public async Task ResetTransformAsync()
    {
        string? methodName = System.Reflection.MethodBase.GetCurrentMethod()?.Name;
        
        if(methodName!=null){
            string functionName  = GetJsFunctionName();
             await this.Runtime.InvokeVoidAsync("DispatchOperation", 
                new {prop = new dynamic[] { Id, functionName }});
        }
    }

    public async Task RestoreAsync()
    {
        string? methodName = System.Reflection.MethodBase.GetCurrentMethod()?.Name;
        
        if(methodName!=null){
            string functionName  = GetJsFunctionName();
             await this.Runtime.InvokeVoidAsync("DispatchOperation", 
                new {prop = new dynamic[] { Id, functionName }});
        }
    }

    public async Task RotateAsync(double angle)
    {
        string? methodName = System.Reflection.MethodBase.GetCurrentMethod()?.Name;
        
        if(methodName!=null){
            string functionName  = GetJsFunctionName();
             await this.Runtime.InvokeVoidAsync("DispatchOperation", 
                new {prop = new dynamic[] { Id, functionName, angle }});
        }
    }

    public async Task RoundRectAsync(double x, double y, double w, double h, double? radii = null)
    {
        string? methodName = System.Reflection.MethodBase.GetCurrentMethod()?.Name;
        
        if(methodName!=null){
            string functionName  = GetJsFunctionName();
             await this.Runtime.InvokeVoidAsync("DispatchOperation", 
                new {prop = new dynamic[] { Id, functionName, x, y, w, h, radii }});
        }
    }

    public async Task RoundRectAsync(double x, double y, double w, double h, double[]? radii = null)
    {
        string? methodName = System.Reflection.MethodBase.GetCurrentMethod()?.Name;
        
        if(methodName!=null){
            string functionName  = GetJsFunctionName();
             await this.Runtime.InvokeVoidAsync("DispatchOperation", 
                new {prop = new dynamic[] { Id, functionName, x, y, w, h, radii }});
        }
    }

    public async Task RoundRectAsync(double x, double y, double w, double h, DOMPointInit? radii = null)
    {
        string? methodName = System.Reflection.MethodBase.GetCurrentMethod()?.Name;
        
        if(methodName!=null){
            string functionName  = GetJsFunctionName();
             await this.Runtime.InvokeVoidAsync("DispatchOperation", 
                new {prop = new dynamic[] { Id, functionName, x, y, w, h, radii }});
        }
    }

    public async Task RoundRectAsync(double x, double y, double w, double h, DOMPointInit[]? radii = null)
    {
        string? methodName = System.Reflection.MethodBase.GetCurrentMethod()?.Name;
        
        if(methodName!=null){
            string functionName  = GetJsFunctionName();
             await this.Runtime.InvokeVoidAsync("DispatchOperation", 
                new {prop = new dynamic[] { Id, functionName, x, y , w, h, radii }});
        }
    }

    public async Task SaveAsync()
    {
        string? methodName = System.Reflection.MethodBase.GetCurrentMethod()?.Name;
        
        if(methodName!=null){
            string functionName  = GetJsFunctionName();
             await this.Runtime.InvokeVoidAsync("DispatchOperation", 
                new {prop = new dynamic[] { Id, functionName }});
        }
    }

    public async Task ScaleAsync(double x, double y)
    {
        string? methodName = System.Reflection.MethodBase.GetCurrentMethod()?.Name;
        
        if(methodName!=null){
            string functionName  = GetJsFunctionName();
             await this.Runtime.InvokeVoidAsync("DispatchOperation", 
                new {prop = new dynamic[] { Id, functionName, x, y }});
        }
    }

    public async Task SetLineDashAsync(double[] segments)
    {
        string? methodName = System.Reflection.MethodBase.GetCurrentMethod()?.Name;
        
        if(methodName!=null){
            string functionName  = GetJsFunctionName();
             await this.Runtime.InvokeVoidAsync("DispatchOperation", 
                new {prop = new dynamic[] { Id, functionName, segments }});
        }
    }

    public async Task SetTransformAsync(DOMMatrix2DInit? transform = null)
    {
        string? methodName = System.Reflection.MethodBase.GetCurrentMethod()?.Name;
        
        if(methodName!=null){
            string functionName  = GetJsFunctionName();
             await this.Runtime.InvokeVoidAsync("DispatchOperation", 
                new {prop = new dynamic[] { Id, functionName, transform }});
        }
    }

    public async Task SetTransformAsync(double a, double b, double c, double d, double e, double f)
    {
        string? methodName = System.Reflection.MethodBase.GetCurrentMethod()?.Name;
        
        if(methodName!=null){
            string functionName  = GetJsFunctionName();
             await this.Runtime.InvokeVoidAsync("DispatchOperation", 
                new {prop = new dynamic[] { Id, functionName, a, b, c, d, e, f }});
        }
    }

    public async Task StrokeAsync()
    {
        string? methodName = System.Reflection.MethodBase.GetCurrentMethod()?.Name;
        
        if(methodName!=null){
            string functionName  = GetJsFunctionName();
             await this.Runtime.InvokeVoidAsync("DispatchOperation", 
                new {prop = new dynamic[] { Id, functionName }});
        }
    }

    public async Task StrokeAsync(Path2D path)
    {
        string? methodName = System.Reflection.MethodBase.GetCurrentMethod()?.Name;
        
        if(methodName!=null){
            string functionName  = GetJsFunctionName();
             await this.Runtime.InvokeVoidAsync("DispatchOperation", 
                new {prop = new dynamic[] { Id, functionName, path }});
        }
    }

    public async Task StrokeRectAsync(double x, double y, double w, double h)
    {
        string? methodName = System.Reflection.MethodBase.GetCurrentMethod()?.Name;
        
        if(methodName!=null){
            string functionName  = GetJsFunctionName();
             await this.Runtime.InvokeVoidAsync("DispatchOperation", 
                new {prop = new dynamic[] { Id, functionName, x, y, w, h }});
        }
    }

    public async Task StrokeTextAsync(string text, double x, double y, double? maxWidth = null)
    {        
        string? methodName = System.Reflection.MethodBase.GetCurrentMethod()?.Name;
        
        if(methodName!=null){
            string functionName  = GetJsFunctionName();
             await this.Runtime.InvokeVoidAsync("DispatchOperation", 
                new {prop = new dynamic[] { Id, functionName, text, x, y, maxWidth }});
        }
    }

    public  async Task TransformAsync(double a, double b, double c, double d, double e, double f)
    {
        string? methodName = System.Reflection.MethodBase.GetCurrentMethod()?.Name;
        
        if(methodName!=null){
            string functionName  = GetJsFunctionName();
             await this.Runtime.InvokeVoidAsync("DispatchOperation", 
                new {prop = new dynamic[] { Id, functionName, a, b, c, d, e, f }});
        }
    }

    public async Task TranslateAsync(double x, double y)
    {
        string? methodName = System.Reflection.MethodBase.GetCurrentMethod()?.Name;
        
        if(methodName!=null){
            string functionName  = GetJsFunctionName();
             await this.Runtime.InvokeVoidAsync("DispatchOperation", 
                new {prop = new dynamic[] { Id, functionName, x, y }});
        }
    }

    public async Task<CanvasRenderingContext2DSettings> GetContextAttributesAsync()
    {
        string functionName  = GetJsFunctionName();
        var value = await this.Runtime.InvokeAsync<CanvasRenderingContext2DSettings>("DispatchOperationReturn", 
                new {prop = new dynamic[] { Id, functionName}});
        return value;
    }
    
    public override async Task SetValue(string propname, dynamic value){  
        if(this.Runtime!=null)         
        {                     
            await this.Runtime.InvokeVoidAsync("DispatchProps", 
                new {prop = new dynamic[] { Id, propname, value }});        
        }
    }

    private string GetJsFunctionName([CallerMemberName] string method = ""){
        return char.ToLowerInvariant(method[0]).ToString() + method.Substring(1, method.Length - 6);
    }
}




public interface ICanvasContextFunctions {
       
    void SetProps(string id, IJSObjectReference js);

    string GetCanvasContextId();

    IJSObjectReference GetJsModuleRuntime();

    Task ArcAsync(double x, double y, double radius, double startAngle, double endAngle, bool counterclockwise = false);
    
    Task ArcToAsync(double x1, double y1, double x2, double y2, double radius);
    
    Task BeginPathAsync();

    Task BezierCurveToAsync(double cp1x, double cp1y, double cp2x, double cp2y, double x, double y);

    Task ClearRectAsync(double x, double y, double w, double h);

     Task ClipAsync(string? fillRule = null);

    Task ClipAsync(Path2D path, string? fillRule = null);

    Task ClosePathAsync();

    Task<CanvasGradient> CreateConicGradientAsync(double startAngle, double x, double y);

    Task<ImageData> CreateImageDataAsync(double sw, double sh, ImageDataSettings settings = null);

    Task<ImageData> CreateImageDataAsync(ImageData imageData);

    Task<CanvasGradient> CreateLinearGradientAsync(double x0, double y0, double x1, double y1);

    Task<CanvasPattern> CreatePatternAsync(dynamic image, string repetition);

    Task<CanvasGradient> CreateRadialGradientAsync(double x0, double y0, double r0, double x1, double y1, double r1);

    Task DrawFocusIfNeededAsync(dynamic element);

    Task DrawFocusIfNeededAsync(Path2D path, dynamic element);

    Task DrawImageAsync(dynamic image, double destinationX, double destinationY);

    Task DrawImageAsync(dynamic image, double destinationX, double destinationY, double destinationWidth, double destinationHeight);

    Task DrawImageAsync(dynamic image, double sourceX, double sourceY, double sourceWidth, double sourceHeight, double destinationX, double destinationY, double destinationWidth, double destinationHeight);

    Task EllipseAsync(double x, double y, double radiusX, double radiusY, double rotation, double startAngle, double endAngle, bool counterclockwise = false);

    Task FillAsync(string? fillRule = null);

    Task FillAsync(Path2D path, string? fillRule = null);

    Task FillRectAsync(double x, double y, double w, double h);

    Task FillTextAsync(string text, double x, double y, double? maxWidth = null);

    Task<ImageData> GetImageDataAsync(double sx, double sy, double sw, double sh, ImageDataSettings settings = null);

    Task<double[]> GetLineDashAsync();

    Task<bool> IsPointInPathAsync(double x, double y, string? fillRule = null);

    Task<bool> IsPointInPathAsync(Path2D path, double x, double y, string? fillRule = null);

    Task<bool> IsPointInStrokeAsync(double x, double y);

    Task<bool> IsPointInStrokeAsync(Path2D path, double x, double y);

    Task LineToAsync(double x, double y);

    Task<TextMetrics> MeasureTextAsync(string text);

    Task MoveToAsync(double x, double y);

    Task PutImageDataAsync(ImageData imagedata, double dx, double dy, double dirtyX, double dirtyY, double dirtyWidth, double dirtyHeight);

    Task PutImageDataAsync(ImageData imagedata, double dx, double dy);

    Task QuadraticCurveToAsync(double cpx, double cpy, double x, double y);

    Task RectAsync(double x, double y, double w, double h);

    Task ResetAsync();

    Task ResetTransformAsync();

    Task RestoreAsync();

    Task RotateAsync(double angle);

    Task RoundRectAsync(double x, double y, double w, double h, double? radii = null);

    Task RoundRectAsync(double x, double y, double w, double h, double[]? radii = null);

    Task RoundRectAsync(double x, double y, double w, double h, DOMPointInit? radii = null);

    Task RoundRectAsync(double x, double y, double w, double h, DOMPointInit[]? radii = null);

    Task SaveAsync();

    Task ScaleAsync(double x, double y);

    Task SetLineDashAsync(double[] segments);

    Task SetTransformAsync(DOMMatrix2DInit? transform = null);

    Task SetTransformAsync(double a, double b, double c, double d, double e, double f);

    Task StrokeAsync();

    Task StrokeAsync(Path2D path);

    Task StrokeRectAsync(double x, double y, double w, double h);

    Task StrokeTextAsync(string text, double x, double y, double? maxWidth = null);

    Task TransformAsync(double a, double b, double c, double d, double e, double f);

    Task TranslateAsync(double x, double y);      

    Task<CanvasRenderingContext2DSettings> GetContextAttributesAsync();  
}

