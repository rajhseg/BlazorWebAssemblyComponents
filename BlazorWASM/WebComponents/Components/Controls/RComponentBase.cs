using System;
using Microsoft.AspNetCore.Components;

namespace WebComponents.Components.Controls;

public abstract class RComponentBase
{

    [Parameter(CaptureUnmatchedValues = true)]
    public Dictionary<string, object> Attributes {get;set;}

    [Parameter]
    public string StyleString {get;set;}
}
