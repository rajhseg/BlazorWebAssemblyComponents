using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Components.Forms;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RWebComponents.Controls.Dropdown
{
    public partial class RDropdown : IEntity
    {
        private List<RDropdownItemModel> rDropdownItemModels = new List<RDropdownItemModel>();

        private IEnumerable<RDropdownModel> rDropDownModels;

        string SelectedDisplay = string.Empty;

        string TextBoxWidth = string.Empty;

        ElementReference openbtn;

        ElementReference myDropdown;

        public bool IsDropDownOpen
        {
            get; set; 
        }

        [Parameter]
        public override IEnumerable<RDropdownModel> value
        {
            get { return rDropDownModels; }
            set
            {
                rDropDownModels = value;

                if (value != null)
                {

                    rDropdownItemModels.Clear();

                    foreach (var item in value)
                    {
                        rDropdownItemModels.Add(new RDropdownItemModel(item.Value, item.DisplayValue));
                    }
                }

                if (fieldIdentifier.FieldName != null)
                {
                    EditContext?.NotifyFieldChanged(fieldIdentifier);
                }
            }
        }

        public string? _id { get; set; } = string.Empty;

        public RDropdown()
        {
            
        }

        protected override Task OnInitializedAsync()
        {
            if(ValueExpression != null)
            {
                fieldIdentifier = FieldIdentifier.Create(ValueExpression);

                if (fieldIdentifier.FieldName != null)
                {
                    EditContext?.NotifyFieldChanged(fieldIdentifier);
                }
            }

            return base.OnInitializedAsync();
        }

        protected override Task OnAfterRenderAsync(bool firstRender)
        {
            if (firstRender)
            {
                if(string.IsNullOrEmpty(_id))
                    _id = "rdropdown_" + Guid.NewGuid().ToString().ToLower();
            }

            return base.OnAfterRenderAsync(firstRender);
        }

        void openDropdown(EventArgs e)
        {

        }

    }
}
