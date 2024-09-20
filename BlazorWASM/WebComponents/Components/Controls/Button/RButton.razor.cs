using System;
using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Components.Forms;

namespace WebComponents.Components.Controls.Button
{
    public partial class RButton
    {
        private string styles = "";

        [Parameter(CaptureUnmatchedValues = true)]
        public Dictionary<string, object> Attributes { get; set; }

        [CascadingParameter]
        public EditContext? EditContext { get; set; }

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
        public string ButtonWidth { get; set; } = "100px";

        [Parameter]
        public string ButtonHeight { get; set; } = "32px";

        [Parameter]
        public string ButtonType { get; set; } = "button";

        [Parameter]
        public string ForeColor { get; set; } = "whitesmoke";

        [Parameter]
        public string BackgroundColor { get; set; } = "blue";

        [Parameter]
        public EventCallback<RButtonEventArgs> ButtonClick { get; set; }

        [Parameter]
        public EventCallback<RButtonEventArgs> OnValidSubmit { get; set; }

        [Parameter]
        public EventCallback<RButtonEventArgs> OnInValidSubmit { get; set; }

        [Parameter]
        public RenderFragment Content { get; set; }

        private async Task OnClick(EventArgs e)
        {
            var args = new RButtonEventArgs() { Args = e, Context = EditContext };

            if (this.ButtonClick.HasDelegate)
            {
                await this.ButtonClick.InvokeAsync(args);
            }

            if (EditContext != null)
            {
                var isValid = EditContext.Validate();

                if (isValid)
                {
                    if (this.OnValidSubmit.HasDelegate)
                    {
                        await this.OnValidSubmit.InvokeAsync(args);
                    }
                }
                else
                {
                    if (this.OnInValidSubmit.HasDelegate)
                        await this.OnInValidSubmit.InvokeAsync(args);
                }
            }
        }
    }
}
