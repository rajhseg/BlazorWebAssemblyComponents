using System;
using System.Linq.Expressions;
using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Components.Forms;

namespace WebComponents.Components.Controls.Switch;

public partial class RSwitch
{
    private FieldIdentifier fieldIdentifier;
    private string styles = "";
    private string _backColor = "rgba(27, 81, 199, 0.692)";
    private bool? isChecked = false;

    [Parameter(CaptureUnmatchedValues = true)]
    public Dictionary<string, object> Attributes { get; set; }  

    [CascadingParameter]
    public EditContext? EditContext { get; set; }

    [Parameter]
    public Expression<Func<bool?>> ValueExpression { get; set; } = default!;

    [Parameter]
    public string style
    {
      set
      {
        var val = value.Trim();
        if (val != "")
        {
          styles = val.Substring(1, val.Length - 2);
        }
        else
        {
          styles = "";
        }
      }
      get
      {
        return this.styles;
      }
    }

  [Parameter]
  public string DisplayLabel {get; set; } = string.Empty;

  [Parameter]
  public string DisplayLabelColor {get; set; } = "blue";

  [Parameter]
  public string SwitchBackColor {
    set {
        this._backColor = value;
    }
    get {
        return this._backColor;
    }
  }

  [Parameter]
  public bool? value {
    get {
        return this.isChecked;
    }
    set {
        this.isChecked = value;
        
         if (fieldIdentifier.FieldName != null)
          EditContext?.NotifyFieldChanged(fieldIdentifier);
    }
  }

  [Parameter]
  public EventCallback<bool?> valueChanged {get; set;}

  [Parameter]
  public EventCallback<bool> OnChecked { get; set; } 

  [Parameter]
  public EventCallback<bool> OnUnChecked { get; set; }

  protected override Task OnInitializedAsync()    
  {
    if(ValueExpression!=null){
        this.fieldIdentifier = FieldIdentifier.Create(ValueExpression);

        if(fieldIdentifier.FieldName!=null)
            EditContext?.NotifyFieldChanged(fieldIdentifier);
    }

    return base.OnInitializedAsync();
  }

   private async Task toggle(EventArgs e) {
    
    if(isChecked==null)
      isChecked = false;

    isChecked = !isChecked; 

    if(valueChanged.HasDelegate){
        await valueChanged.InvokeAsync(this.isChecked);
        StateHasChanged();
    }           

    if(fieldIdentifier.FieldName!=null)
        EditContext?.NotifyFieldChanged(fieldIdentifier);

    if(isChecked.Value && OnChecked.HasDelegate)
        await OnChecked.InvokeAsync(isChecked.Value);
    
    if(!isChecked.Value && OnUnChecked.HasDelegate)
        await OnUnChecked.InvokeAsync(isChecked.Value);

  }

}
