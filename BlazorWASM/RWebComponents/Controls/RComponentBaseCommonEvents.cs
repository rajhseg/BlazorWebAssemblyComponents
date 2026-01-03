using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Components.Web;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RWebComponents.Controls
{
    public abstract class RComponentBaseCommonEvents<T> : RComponentBase<T>
    {
        protected RComponentBaseCommonEvents() { }

        [Parameter]
        public EventCallback<MouseEventArgs> OnClick { get; set; }

        [Parameter]
        public EventCallback<MouseEventArgs> OnDblClick { get; set; }

        [Parameter]
        public EventCallback<MouseEventArgs> OnMouseDown { get; set; }

        [Parameter]
        public EventCallback<MouseEventArgs> OnMouseUp { get; set; }

        [Parameter]
        public EventCallback<MouseEventArgs> OnMouseMove { get; set; }

        [Parameter]
        public EventCallback<MouseEventArgs> OnMouseLeave { get; set; }

        [Parameter]
        public EventCallback<MouseEventArgs> OnMouseOut { get; set;  }

        [Parameter]
        public EventCallback<MouseEventArgs> OnMouseOver { get; set; }

        [Parameter]
        public EventCallback<MouseEventArgs> OnMouseEnter { get; set;  }

        [Parameter]
        public EventCallback<WheelEventArgs> OnMouseWheel { get; set; }

        [Parameter]
        public EventCallback<KeyboardEventArgs> OnKeyUp { get; set; }

        [Parameter]
        public EventCallback<KeyboardEventArgs> OnKeyDown { get; set; }

        [Parameter]
        public EventCallback<KeyboardEventArgs> OnKeyPress { get; set; }

        [Parameter]
        public EventCallback<FocusEventArgs> OnFocus { get; set; }

        [Parameter]
        public EventCallback<FocusEventArgs> OnFocusIn { get; set; }

        [Parameter]
        public EventCallback<FocusEventArgs> OnFocusOut { get; set; }

        [Parameter]
        public EventCallback<FocusEventArgs> OnBlur { get; set; }

        [Parameter]
        public EventCallback<ClipboardEventArgs> OnCut { get; set; }

        [Parameter]
        public EventCallback<ClipboardEventArgs> OnCopy { get; set; }

        [Parameter]
        public EventCallback<ClipboardEventArgs> OnPaste { get; set; }

        [Parameter]
        public EventCallback<ChangeEventArgs> OnChange { get; set; }


        [Parameter]
        public EventCallback<ChangeEventArgs> OnInput { get; set; }

        [Parameter]
        public EventCallback<DragEventArgs> OnDrag { get; set; }

        [Parameter]
        public EventCallback<DragEventArgs> OnDragEnter { get; set; }

        [Parameter]
        public EventCallback<DragEventArgs> OnDragLeave { get; set; }

        [Parameter]
        public EventCallback<DragEventArgs> OnDragEnd { get; set; }

        [Parameter]
        public EventCallback<DragEventArgs> OnDragOver { get; set; }

        [Parameter]
        public EventCallback<DragEventArgs> OnDragStart { get; set; }

        [Parameter]
        public EventCallback<DragEventArgs> OnDrop { get; set; }
    }
}
