using System;
using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Components.Forms;

namespace RWebComponents.Controls.Button
{
    public partial class RButton : IEntity
    {
        public string _id { get; private set; }

        private string styles = "";

        [Parameter(CaptureUnmatchedValues = true)]
        public Dictionary<string, object> Attributes { get; set; }

        [CascadingParameter]
        public EditContext? EditContext { get; set; }

        [Parameter]
        public string ButtonStyle
        {
            set
            {
                var val = value.Trim();
                styles = val;
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

        public RButton()
        {

        }

        protected override Task OnInitializedAsync()
        {
            if (EditContext == null)
            {
                if (this.OnValidSubmit.HasDelegate || this.OnInValidSubmit.HasDelegate)
                {
                    throw new Exception("Button should be inside EditForm, when OnValidSubmit or OnInValidSubmit is Assigned or Use only ButtonClick handler if it is outside of EditForm.");
                }
            }
            return base.OnInitializedAsync();
        }

        protected override Task OnAfterRenderAsync(bool firstRender)
        {
            if (firstRender)
            {
                if (string.IsNullOrEmpty(this._id))
                {
                    this._id = "rbutton_" + Guid.NewGuid().ToString().ToLower();
                }

                StateHasChanged();
            }
            return base.OnAfterRenderAsync(firstRender);
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

    public static class RButtonType
    {
        public static string Button = "button";

        public static string Menu = "menu";

        public static string Submit = "submit";

        public static string Reset = "reset";
    }
}
