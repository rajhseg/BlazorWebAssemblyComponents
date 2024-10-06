using System;
using System.Text.Json;
using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Components.Forms;
using Microsoft.JSInterop;

namespace RWebComponents.Controls.Canvas;

public partial class RCanvas : ICanvasEntity, IAsyncDisposable
{
    public Func<Task> ScriptLoaded;

    public bool IsScriptLoaded = false;

    public string _containerId { get; private set; }

    public string _id { get; private set; }

    [Parameter]
    public int Width { get ; set; }
  
    [Parameter]
    public int Height { get; set; }
    
    [Parameter(CaptureUnmatchedValues = true)]
    public Dictionary<string, object> Attributes { get; set; }

    [CascadingParameter]
    public EditContext? EditContext { get; set; }

    private string _canvasStyle = string.Empty;

    private IJSObjectReference jsModule;
    
    [Parameter]
    public string style
    {
        set
        {
            if(value!=null)
            {
                var val = value.Trim();
                _canvasStyle = val;
            }
        }
        get
        {
            return this._canvasStyle;
        }
    }

    protected override async Task OnAfterRenderAsync(bool firstRender)
    {
        if(firstRender){
            var idString = Guid.NewGuid().ToString();
            this._id = "rcanvas_" + idString;
            this._containerId = "rcanvas_con_"+idString;

            this.jsModule = await Runtime.InvokeAsync<IJSObjectReference>("import", "./_content/RWebComponents/Controls/Canvas/RCanvas.razor.js");

            await InvokeAsync(()=> StateHasChanged());

            if(ScriptLoaded != null && this.jsModule != null)
            {
                this.IsScriptLoaded = true;
                await this.ScriptLoaded();
            }
        }
        
        await base.OnAfterRenderAsync(firstRender);
    }

    public async Task<CanvasContext> CreateContext2DAsync(){
        CanvasContext result = null;

        if(this.jsModule!=null){
            CanvasCreateContext ctx = new CanvasCreateContext {Id = _id};
            result = await this.jsModule.InvokeAsync<CanvasContext>("CreateContext", ctx); 

            if(result!=null){
                result.SetProps(_id, this.jsModule);
            }       
        }

        return result;
    }

    public async ValueTask DisposeAsync()
    {        
        await Task.CompletedTask;
    }
}
