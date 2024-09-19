using System;
using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Components.Web;

namespace WebComponents.Components.Controls.TextBox
{
  public partial class RTextboxComponent
  {
    [Parameter(CaptureUnmatchedValues = true)]
    public Dictionary<string, object> Attributes { get; set; }

    private string styles = "";

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
    public string LabelText { get; set; } = "";

    [Parameter]
    public string PlaceholderText { get; set; } = "";

    [Parameter]
    public string LabelForeColor { get; set; } = "blue";

    [Parameter]
    public string BottomLineColor { get; set; } = "blue";

    [Parameter]
    public bool IsReadOnly { get; set; }

    [Parameter]
    public int TextBoxWidth { get; set; } = 200;

    [Parameter]
    public int TextBoxHeight { get; set; } = 30;

    [Parameter]
    public EventCallback<MouseEventArgs> OnClick {get; set; }

    
    [Parameter]
    public EventCallback<FocusEventArgs> OnFocusIn {get; set; }

    
    [Parameter]
    public EventCallback<FocusEventArgs> OnFocusOut {get; set; }

    private bool isPassword = false;

    [Parameter]
    public bool EnableMarginTextBottom { get; set; } = true;

    [Parameter]
    public int MarginTextBottom { get; set; } = 10;

    [Parameter]
    public bool IsPasswordBox
    {
      get
      {
        return this.isPassword;
      }
      set
      {
        this.isPassword = value;
      }
    }

    private string _textboxValue = "";

    [Parameter]
    public EventCallback<string> TextboxValueChanged { get; set; }

    [Parameter]
    public string TextboxValue
    {
      get
      {
        return this._textboxValue;
      }
      set
      {
        this._textboxValue = value;
      }
    }


    public async Task ValueChanged(ChangeEventArgs e)
    {
      var val = "";
      if (e.Value != null)
        val = e.Value as string;

      this._textboxValue = val;

      if (this.TextboxValueChanged.HasDelegate)
      {
        await TextboxValueChanged.InvokeAsync(this._textboxValue);
        StateHasChanged();
      }
    }

    public async Task txtboxClicked(MouseEventArgs e)
    {
      if(this.OnClick.HasDelegate){
        await this.OnClick.InvokeAsync(e);
      }
    }

    public async Task txtboxFocusin(FocusEventArgs e){
      if(this.OnFocusIn.HasDelegate){
        await this.OnFocusIn.InvokeAsync(e);
      }
    }

    public async Task txtboxFocusout(FocusEventArgs e){
      if(this.OnFocusOut.HasDelegate){
        await this.OnFocusOut.InvokeAsync(e);
      }
    }

  }

}