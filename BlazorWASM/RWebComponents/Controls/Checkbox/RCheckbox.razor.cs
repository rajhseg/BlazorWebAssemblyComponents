using System;
using System.Linq.Expressions;
using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Components.Forms;
using Microsoft.AspNetCore.Components.Web;

namespace RWebComponents.Controls.Checkbox;

public partial class RCheckbox : IEntity
{
    public string _id { get; private set; }
    private bool? _isChecked;
    private FieldIdentifier fieldIdentifier;
    private string labelStyle = "";

    [Parameter(CaptureUnmatchedValues = true)]
    public Dictionary<string, object> Attributes { get; set; }

    [CascadingParameter]
    public EditContext? EditContext { get; set; }

    [Parameter]
    public Expression<Func<bool?>> ValueExpression { get; set; } = default!;

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
    public bool? value
    {
        get
        {
            return this._isChecked;
        }
        set
        {
            var checkValue = value;
            this._isChecked = checkValue;            
            
            if (this.fieldIdentifier.FieldName != null)
                this.EditContext?.NotifyFieldChanged(this.fieldIdentifier);

            InvokeAsync(() => StateHasChanged()).GetAwaiter();
        }
    }

    [Parameter]
    public EventCallback<bool?> CheckboxValueChanged { get; set; }

    [Parameter]
    public EventCallback<bool?> valueChanged { get; set; }

    [Parameter]
    public string DisplayText { get; set; } = "";

    [Parameter]
    public bool DisplayTextRightAlign { get; set; } = true;

    [Parameter]
    public string GroupName { get; set; } = string.Empty;

    [Parameter]
    public EventCallback<bool> OnChecked { get; set; }

    [Parameter]
    public EventCallback<bool> OnUnChecked { get; set; }

    [Parameter]
    public EventCallback<RCheckboxEventArgs> OnClick { get; set; }

    public RCheckbox()
    {
    }

    private async Task resetValueForGroupedCheckbox(string groupname, bool triggerValueChange = true)
    {
        await this.ResetCheckboxesForGroup(groupname, triggerValueChange);
    }

    private async Task ResetCheckboxesForGroup(string groupname, bool triggerValueChange = true)
    {
        if (objService != null)
        {
            var objs = objService.GetAllObjectsOfType(typeof(RCheckbox)).Cast<RCheckbox>();
            var filtered = objs.Where(x => x.GroupName.ToLower() == groupname.ToLower() && x._id != this._id);

            foreach (var item in filtered)
            {
                item.value = false;

                if(triggerValueChange) 
                    await item.TriggerValueChanged(); 

                await item.NotifyToModel(item.value);
            }
        }
    }

    public async Task TriggerValueChanged()
    {
        await InvokeAsync(async () => await this.CheckboxValueChanged.InvokeAsync(this.value));
    }
    private async Task check(EventArgs e)
    {
        await this.toggleCheck(e);
        await InvokeAsync(() => StateHasChanged());
    }

    private async Task toggleCheck(EventArgs e)
    {
        if (this.value == null)
            this.value = false;

        var checkValue = !this._isChecked.Value;
        this._isChecked = checkValue;

        if (checkValue && this.GroupName != "" && this.GroupName != null)
        {
            await this.resetValueForGroupedCheckbox(this.GroupName);
        }

        if (this.CheckboxValueChanged.HasDelegate)
        {
            await CheckboxValueChanged.InvokeAsync(this._isChecked.Value);
            StateHasChanged();
        }

        if (this.valueChanged.HasDelegate)
        {
            await valueChanged.InvokeAsync(this._isChecked.Value);
            StateHasChanged();
        }

        await this.NotifyToModel(this.value);

        if (this.OnClick.HasDelegate)
        {
            var args = new RCheckboxEventArgs() { Args = e, IsChecked = checkValue };
            await this.OnClick.InvokeAsync(args);
        }

    }

    public async Task NotifyToModel(bool? checkValue)
    {
        await InvokeAsync(async () =>
        {

            if (checkValue.HasValue)
            {
                if (this.OnChecked.HasDelegate && checkValue.Value)
                    await this.OnChecked.InvokeAsync(true);

                if (this.OnUnChecked.HasDelegate && !checkValue.Value)
                    await this.OnUnChecked.InvokeAsync(false);
            }

            if (this.fieldIdentifier.FieldName != null)
                this.EditContext?.NotifyFieldChanged(this.fieldIdentifier);
        });
    }

    protected override async Task OnInitializedAsync()
    {
        if (ValueExpression != null)
        {
            this.fieldIdentifier = FieldIdentifier.Create(ValueExpression);

            if (this.fieldIdentifier.FieldName != null)
                this.EditContext?.NotifyFieldChanged(this.fieldIdentifier);
        }

        await base.OnInitializedAsync();
    }

    protected override Task OnAfterRenderAsync(bool firstRender)
    {
        if (firstRender)
        {
            if (string.IsNullOrEmpty(this._id))
                this._id = "rcheckbox_" + Guid.NewGuid().ToString().ToLower();

            if (objService != null)
                objService.AddInstance(typeof(RCheckbox), this);

            StateHasChanged();
        }

        return base.OnAfterRenderAsync(firstRender);
    }

    protected override async Task OnParametersSetAsync()
    {        
        await base.OnParametersSetAsync();
    }
}
