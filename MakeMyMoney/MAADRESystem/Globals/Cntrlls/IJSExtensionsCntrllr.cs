﻿using Microsoft.JSInterop;

namespace MakeMyMoney.MAADRESystem.Globals.Cntrlls
{
    public static class IJSExtensionsCntrllr
    {
        public static ValueTask<object> SetInLocalStorage(this IJSRuntime js, string key, string content)
            => js.InvokeAsync<object>("localStorage.setItem", key, content);

        public static ValueTask<string> GetFromLocalStorage(this IJSRuntime js, string key)
            => js.InvokeAsync<string>("localStorage.getItem", key);

        public static ValueTask<object> RemoveItem(this IJSRuntime js, string key)
            => js.InvokeAsync<object>("localStorage.removeItem", key);
    }
}
