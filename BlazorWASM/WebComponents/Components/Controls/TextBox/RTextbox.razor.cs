using System;
using System.Linq.Expressions;
using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Components.Forms;
using Microsoft.AspNetCore.Components.Web;

namespace WebComponents.Components.Controls.TextBox
{
  public partial class RTextbox
  {
    private string _textboxValue = "";
    private FieldIdentifier fieldIdentifier;
    private string styles = "";
    private bool isPassword = false;
    

    [Parameter(CaptureUnmatchedValues = true)]
    public Dictionary<string, object> Attributes { get; set; }  

    [CascadingParameter]
    public EditContext? EditContext { get; set; }

    [Parameter]
    public Expression<Func<string>> ValueExpression { get; set; } = default!;

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

    [Parameter]
    public string value
    {
      get
      {
        return this._textboxValue;
      }
      set
      {
        this._textboxValue = value;
        
        if (fieldIdentifier.FieldName != null)
          EditContext?.NotifyFieldChanged(fieldIdentifier);
      }
    }

    [Parameter]
    public EventCallback<string> valueChanged { get; set; }

    [Parameter]
    public EventCallback<MouseEventArgs> OnClick { get; set; }


    [Parameter]
    public EventCallback<FocusEventArgs> OnFocusIn { get; set; }


    [Parameter]
    public EventCallback<FocusEventArgs> OnFocusOut { get; set; }

    protected override void OnInitialized()
    {
      if (ValueExpression != null)
      {
        this.fieldIdentifier = FieldIdentifier.Create(ValueExpression);

        if (fieldIdentifier.FieldName != null)
          EditContext?.NotifyFieldChanged(fieldIdentifier);
      }

      base.OnInitialized();
    }

    private async Task OnChanged(ChangeEventArgs e)
    {
      var val = "";
      if (e.Value != null)
        val = e.Value as string;

      this._textboxValue = val;

      if (this.valueChanged.HasDelegate)
      {
        await valueChanged.InvokeAsync(this._textboxValue);
        StateHasChanged();
      }

      if (fieldIdentifier.FieldName != null)
        EditContext?.NotifyFieldChanged(fieldIdentifier);
    }

    private async Task txtboxClicked(MouseEventArgs e)
    {
      if (this.OnClick.HasDelegate)
      {
        await this.OnClick.InvokeAsync(e);
      }
    }

    private async Task txtboxFocusin(FocusEventArgs e)
    {
      if (this.OnFocusIn.HasDelegate)
      {
        await this.OnFocusIn.InvokeAsync(e);
      }
    }

    private async Task txtboxFocusout(FocusEventArgs e)
    {
      if (this.OnFocusOut.HasDelegate)
      {
        await this.OnFocusOut.InvokeAsync(e);
      }
    }

  }

}