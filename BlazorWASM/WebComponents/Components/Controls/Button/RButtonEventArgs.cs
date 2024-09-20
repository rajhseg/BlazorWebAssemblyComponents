using System;
using Microsoft.AspNetCore.Components.Forms;

namespace WebComponents.Components.Controls.Button;

public class RButtonEventArgs
{
  public EventArgs? Args {get; set;}

  public EditContext? Context {get; set;}
}
