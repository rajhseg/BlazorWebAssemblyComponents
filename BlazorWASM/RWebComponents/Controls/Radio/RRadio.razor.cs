using System;
using System.Linq.Expressions;
using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Components.Forms;

namespace RWebComponents.Controls.Radio;

public partial class RRadio : IEntity
{
    public string? _id { get; private set; }
    private bool? _isChecked;
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

    [Parameter]
    public override bool? value
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
    public string Color {get; set; } = "#00c7ba";

    [Parameter]
    public EventCallback<bool?> RadioValueChanged { get; set; }

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
    public EventCallback<RRadioEventArgs> OnClick { get; set; }

    public RRadio()
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
            var objs = objService.GetAllObjectsOfType(typeof(RRadio)).Cast<RRadio>();
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
        await InvokeAsync(async () => await this.RadioValueChanged.InvokeAsync(this.value));
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

        if (this.RadioValueChanged.HasDelegate)
        {
            await RadioValueChanged.InvokeAsync(this._isChecked.Value);
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
            var args = new RRadioEventArgs() { Args = e, IsChecked = checkValue };
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
                this._id = "rradio_" + Guid.NewGuid().ToString().ToLower();

            if (objService != null)
                objService.AddInstance(typeof(RRadio), this);

            StateHasChanged();
        }

        return base.OnAfterRenderAsync(firstRender);
    }

    protected override async Task OnParametersSetAsync()
    {        
        await base.OnParametersSetAsync();
    }

}
