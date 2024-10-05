using System;
using Microsoft.AspNetCore.Components;
using Microsoft.JSInterop;

namespace RWebComponents.Controls;


    public interface IJsConsole
    {
        Task Log(string message);

        Task Log(object obj);
    }

    public class JsConsole : IJsConsole
    {        
        private IJSRuntime Runtime {get;set;}

        public JsConsole(IJSRuntime runtime)
        {
         this.Runtime = runtime;
        }

        public async Task Log(string message)
        {
            await this.Runtime.InvokeVoidAsync("console.log", message);
        }

        public async Task Log(object obj)
        {
            var json = obj.ConvertToJson();
            await this.Runtime.InvokeVoidAsync("console.log", json);
        }
    }
