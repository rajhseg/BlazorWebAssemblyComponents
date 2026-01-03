using System;
using System.Linq.Expressions;
using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Components.Forms;

namespace RWebComponents.Controls.Switch;

public partial class RSwitch : IEntity
{
  public string? _id { get; private set; }
  private FieldIdentifier fieldIdentifier;
  private string labelStyle = string.Empty;
  private string styles = "";
  private string _backColor = "rgba(27, 81, 199, 0.692)";
  private bool? isChecked = false;

  [Parameter]
  public string LabelStyle
  {
    set
    {
      var val = value.Trim();
      labelStyle = val;
    }
    get
    {
      return this.labelStyle;
    }
  }

  [Parameter]
  public string DisplayLabel { get; set; } = string.Empty;

  [Parameter]
  public string DisplayLabelColor { get; set; } = "blue";

  [Parameter]
  public string SwitchBackColor
  {
    set
    {
      this._backColor = value;
    }
    get
    {
      return this._backColor;
    }
  }

  [Parameter]
  public override bool? value
  {
    get
    {
      return this.isChecked;
    }
    set
    {
      this.isChecked = value;
      
      if (this.fieldIdentifier.FieldName != null)
        this.EditContext?.NotifyFieldChanged(this.fieldIdentifier);
    }
  }

  [Parameter]
  public EventCallback<bool?> SwitchValueChanged { get; set; }

  [Parameter]
  public EventCallback<bool> OnChecked { get; set; }

  [Parameter]
  public EventCallback<bool> OnUnChecked { get; set; }

  public RSwitch()
  {

  }

  protected override Task OnAfterRenderAsync(bool firstRender)
  {
    if (firstRender)
    {
      if (string.IsNullOrEmpty(this._id))
        this._id = "rswitch_" + Guid.NewGuid().ToString().ToLower();

      StateHasChanged();
    }

    return base.OnAfterRenderAsync(firstRender);
  }

  protected override Task OnInitializedAsync()
  {
    if (ValueExpression != null)
    {
      this.fieldIdentifier = FieldIdentifier.Create(ValueExpression);

      if (fieldIdentifier.FieldName != null)
        EditContext?.NotifyFieldChanged(fieldIdentifier);
    }

    return base.OnInitializedAsync();
  }

    private async Task toggle(EventArgs e)
    {
        if (isChecked == null)
            isChecked = false;

        isChecked = !isChecked;

        if (SwitchValueChanged.HasDelegate)
        {
            await SwitchValueChanged.InvokeAsync(this.isChecked);
            StateHasChanged();
        }

        if (this.valueChanged.HasDelegate)
        {
            await valueChanged.InvokeAsync(this.isChecked.Value);
            StateHasChanged();
        }

        this.NotifyToModel();
    }

  private void NotifyToModel()
  {
    if (fieldIdentifier.FieldName != null)
      EditContext?.NotifyFieldChanged(fieldIdentifier);

    if (isChecked.HasValue)
    {
      if (isChecked.Value && OnChecked.HasDelegate)
        OnChecked.InvokeAsync(true);

      if (!isChecked.Value && OnUnChecked.HasDelegate)
        OnUnChecked.InvokeAsync(false);
    }

    StateHasChanged();
  }

}
