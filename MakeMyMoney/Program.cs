

using MakeMyMoney;
using MakeMyMoney.MAADRESystem.Globals.Cntrlls;
using MakeMyMoney.MAADRESystem.Globals.Data;
using MakeMyMoney.MAADRESystem.Globals.Data.WebServices;
using MakeMyMoney.MAADRESystem.Globals.Interfaces;
using Microsoft.AspNetCore.Components.Authorization;
using Microsoft.AspNetCore.Components.Web;
using Microsoft.AspNetCore.Components.WebAssembly.Hosting;

var builder = WebAssemblyHostBuilder.CreateDefault(args);
builder.RootComponents.Add<App>("#app");
builder.RootComponents.Add<HeadOutlet>("head::after");

builder.Services.AddAuthorizationCore();
builder.Services.AddScoped<AuthCntrllr>();
builder.Services.AddScoped<AuthenticationStateProvider, AuthCntrllr>(p => p.GetRequiredService<AuthCntrllr>());
builder.Services.AddScoped<ILogInSrvc, AuthCntrllr>(p => p.GetRequiredService<AuthCntrllr>());
builder.Services.AddScoped<ISignUpSrvc, AuthCntrllr>(p => p.GetRequiredService<AuthCntrllr>());
builder.Services.AddScoped<IWebTokenRepository, WebTokenRepository>();

//UserFireBaseWSSrvc : ISignUpSrvc
builder.Services.AddScoped<IUserFireBaseWSSrvc, UserFireBaseWSSrvc>();
builder.Services.AddHttpClient();
builder.Services.AddScoped(sp => new HttpClient { BaseAddress = new Uri(builder.HostEnvironment.BaseAddress) });
//builder.Services.AddHttpClient();
await builder.Build().RunAsync();
