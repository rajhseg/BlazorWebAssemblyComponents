using System;
using System.Runtime.CompilerServices;

namespace RWebComponents.Controls.Canvas;


public static class CanvasExtensions{
    public static string GetJsFunctionName([CallerMemberName] string method = ""){
        return char.ToLowerInvariant(method[0]).ToString() + method.Substring(1, method.Length - 6);
    }
}