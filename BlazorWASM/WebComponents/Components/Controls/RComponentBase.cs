using System;
using System.Linq.Expressions;
using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Components.Forms;

namespace WebComponents.Components.Controls;

public abstract class RComponentBase
{
    [Parameter(CaptureUnmatchedValues = true)]
    public Dictionary<string, object> Attributes { get; set; }

    [CascadingParameter]
    public EditContext? EditContext { get; set; }

    [Parameter]
    public Expression<Func<string>> ValueExpression { get; set; } = default!;

    private FieldIdentifier fieldIdentifier;

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

}
