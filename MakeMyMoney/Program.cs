

using MakeMyMoney;
using MakeMyMoney.MAADRESystem.Globals.Cntrlls;
using MakeMyMoney.MAADRESystem.Globals.Data;
using MakeMyMoney.MAADRESystem.Globals.Data.WebServices;
using MakeMyMoney.MAADRESystem.Globals.Interfaces;
using MakeMyMoney.MAADRESystem.Globals.Models;
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
builder.Services.AddSingleton<ConfigurationService>();
//builder.Services.Configure<AppSettings>(config =>
//{
//    //var configuration = new ConfigurationBuilder()
//    //    .AddJsonFile("appsettings.json") // Aseg�rate que este archivo se copie al directorio de salida
//    //    .AddJsonFile($"appsettings.{env.Environment}.json", optional: true, reloadOnChange: true)
//    //    .Build();

//    /*
//     _configuration = new ConfigurationBuilder()
//            .AddJsonFile("appsettings.json", optional: true, reloadOnChange: true)
//            .AddJsonFile($"appsettings.{env.Environment}.json", optional: true, reloadOnChange: true)
//            .Build();
//    */

//    config.FirebaseKey = configuration["FirebaseKey"];
//});

builder.Services.AddHttpClient("HTTPCFirebase", client => {
    client.BaseAddress = new Uri("https://identitytoolkit.googleapis.com/");
});
builder.Services.AddScoped(sp => new HttpClient { BaseAddress = new Uri(builder.HostEnvironment.BaseAddress) });
//builder.Services.AddHttpClient();
await builder.Build().RunAsync();

public class ConfigurationService
{
    private readonly IConfiguration _configuration;

    public ConfigurationService(IWebAssemblyHostEnvironment env)
    {
        _configuration = new ConfigurationBuilder()
            .AddJsonFile("appsettings.json", optional: true, reloadOnChange: true)
            .AddJsonFile($"appsettings.{env.Environment}.json", optional: true, reloadOnChange: true)
            .Build();
    }

    public string GetFirebaseKey()
    {
        return _configuration["FirebaseKey"];
    }
}
