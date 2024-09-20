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

        protected override Task OnInitializedAsync()
        {
            if(EditContext==null){
                if(this.OnValidSubmit.HasDelegate || this.OnInValidSubmit.HasDelegate){
                    throw new Exception("Button should be inside EditForm, when OnValidSubmit or OnInValidSubmit is Assigned or Use only ButtonClick handler if it is outside of EditForm.");
                }
            }
            return base.OnInitializedAsync();
        }

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

    public static class RButtonType {
        public static string Button = "button";

        public static string Menu = "menu";

        public static string Submit = "submit";

        public static string Reset = "reset";
    }
}
