using System;
using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Components.Forms;

namespace RWebComponents.Controls.GroupPanel;

public partial class RGroupPanel
{

    [Parameter]
    public bool EnableShadowEffect {get; set;} = true;

    [Parameter]
    public string GroupName {get; set;}= "";

    [Parameter]
    public bool IsItemsArrangeHorizontal {get; set; } = false;

    [Parameter]
    public string TitleForeColor {get; set;} = "gray";

    [Parameter(CaptureUnmatchedValues = true)]
    public Dictionary<string, object> Attributes { get; set; }

    [CascadingParameter]
    public EditContext? EditContext { get; set; }

    private string labelStyle = "";    

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


    private string contentStyle = "";    

    [Parameter]
    public string ContentStyle
    {
        set
        {
            var val = value.Trim();
            contentStyle = val;
        }
        get
        {
            return this.contentStyle;
        }
    }

    [Parameter]
    public RenderFragment Content {get; set;}
}
