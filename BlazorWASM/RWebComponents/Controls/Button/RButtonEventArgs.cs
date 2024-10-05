using System;
using Microsoft.AspNetCore.Components.Forms;

namespace RWebComponents.Controls.Button;

public class RButtonEventArgs
{
  public EventArgs? Args {get; set;}

  public EditContext? Context {get; set;}
}
