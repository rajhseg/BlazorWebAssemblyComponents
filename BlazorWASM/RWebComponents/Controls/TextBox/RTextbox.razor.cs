using System;
using System.ComponentModel.DataAnnotations;
using System.Linq.Expressions;
using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Components.Forms;
using Microsoft.AspNetCore.Components.Web;

namespace RWebComponents.Controls.TextBox
{
    public partial class RTextbox : IEntity
    {
        public string? _id { get; private set; }

        private string _textboxValue = "";
        private string textboxStyle = "";
        private string labelStyle = "";
        private bool isPassword = false;

        private string? _inputId { get; set; }


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
        public string TextboxStyle
        {
            set
            {
                var val = value.Trim();
                textboxStyle = val;
            }
            get
            {
                return this.textboxStyle;
            }
        }

        [Parameter]
        public bool EnableBackDrop { get; set; } = false;

        [Parameter]
        public string LabelText { get; set; } = "";

        [Parameter]
        public string PlaceholderText { get; set; } = "";

        [Parameter]
        public string LabelForeColor { get; set; } = "blue";

        [Parameter]
        public string BottomLineColor { get; set; } = "blue";

        [Parameter]
        public bool IsReadOnly { get; set; }

        [Parameter]
        public int TextBoxWidth { get; set; } = 200;

        [Parameter]
        public int TextBoxHeight { get; set; } = 30;

        [Parameter]
        public bool EnableMarginTextBottom { get; set; } = true;

        [Parameter]
        public int MarginTextBottom { get; set; } = 10;

        [Parameter]
        public bool IsPasswordBox
        {
            get
            {
                return this.isPassword;
            }
            set
            {
                this.isPassword = value;
            }
        }

        [Parameter]
        public override string value
        {
            get
            {
                return this._textboxValue;
            }
            set
            {
                this._textboxValue = value;

                if (fieldIdentifier.FieldName != null)
                    EditContext?.NotifyFieldChanged(fieldIdentifier);
            }
        }

        [Parameter]
        public EventCallback<string> TextboxValueChanged { get; set; }

        public RTextbox()
        {
                
        }

        protected override Task OnAfterRenderAsync(bool firstRender)
        {
            if (firstRender)
            {
                if (string.IsNullOrEmpty(this._inputId))
                    this._inputId = "rtextboxinput_" + Guid.NewGuid().ToString().ToLower();

                if (string.IsNullOrEmpty(this._id))
                    this._id = "rtextbox_" + Guid.NewGuid().ToString().ToLower();

                StateHasChanged();
            }
            return base.OnAfterRenderAsync(firstRender);
        }

        protected override void OnInitialized()
        {
            if (ValueExpression != null)
            {
                this.fieldIdentifier = FieldIdentifier.Create(ValueExpression);

                if (fieldIdentifier.FieldName != null)
                    EditContext?.NotifyFieldChanged(fieldIdentifier);
            }

            base.OnInitialized();
        }

        private async Task OnInputChanged(ChangeEventArgs e)
        {
            if (this.OnInput.HasDelegate)
                await OnInput.InvokeAsync(e);

            var val = "";
            if (e.Value != null)
                val = e.Value as string;

            this._textboxValue = val;

            if (this.TextboxValueChanged.HasDelegate)
            {
                await TextboxValueChanged.InvokeAsync(this._textboxValue);
                StateHasChanged();
            }

            if(this.valueChanged.HasDelegate)
            {
                await valueChanged.InvokeAsync(this._textboxValue);
                StateHasChanged();
            }

            if (fieldIdentifier.FieldName != null)
                EditContext?.NotifyFieldChanged(fieldIdentifier);
        }

        private async Task OnChanged(ChangeEventArgs e)
        {

            if (this.OnChange.HasDelegate)
                await OnChange.InvokeAsync(e);

            if(this._textboxValue == e.Value as string)
                return;

            var val = "";
            if (e.Value != null)
                val = e.Value as string;

            this._textboxValue = val;

            if (this.TextboxValueChanged.HasDelegate)
            {
                await TextboxValueChanged.InvokeAsync(this._textboxValue);
                StateHasChanged();
            }

            if (this.valueChanged.HasDelegate)
            {
                await valueChanged.InvokeAsync(this._textboxValue);
                StateHasChanged();
            }

            if (fieldIdentifier.FieldName != null)
                EditContext?.NotifyFieldChanged(fieldIdentifier);
        }

        private async Task txtboxClicked(MouseEventArgs e)
        {
            if (this.OnClick.HasDelegate)
            {
                await this.OnClick.InvokeAsync(e);
            }
        }

    }

}