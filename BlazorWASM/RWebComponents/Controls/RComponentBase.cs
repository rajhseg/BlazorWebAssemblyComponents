using System;
using System.Linq.Expressions;
using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Components.Forms;

namespace RWebComponents.Controls;

public abstract class RComponentBase<T> : ComponentBase
{
    [Parameter(CaptureUnmatchedValues = true)]
    public Dictionary<string, object> Attributes { get; set; }

    [CascadingParameter]
    public EditContext? EditContext { get; set; }

    [Parameter]
    public Expression<Func<T>> ValueExpression { get; set; } = default!;


    protected FieldIdentifier fieldIdentifier;

    [Parameter]
    public EventCallback<T> valueChanged { get; set; }

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
    public abstract T value { get; set; }

}
