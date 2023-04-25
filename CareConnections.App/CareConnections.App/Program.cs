using CareConnections.App;
using CareConnections.App.Services;
using Microsoft.AspNetCore.Components.Web;
using Microsoft.AspNetCore.Components.WebAssembly.Authentication;
using Microsoft.AspNetCore.Components.WebAssembly.Hosting;

var builder = WebAssemblyHostBuilder.CreateDefault(args);
builder.RootComponents.Add<App>("#app");
builder.RootComponents.Add<HeadOutlet>("head::after");

builder.Services.AddHttpClient<IClientDataService, ClientDataService>(client =>
    client.BaseAddress = new Uri(builder.HostEnvironment.BaseAddress))
    .AddHttpMessageHandler<BaseAddressAuthorizationMessageHandler>(); ;
builder.Services.AddHttpClient<IReportDataService, ReportDataService>(client =>
    client.BaseAddress = new Uri(builder.HostEnvironment.BaseAddress))
    .AddHttpMessageHandler<BaseAddressAuthorizationMessageHandler>();

builder.Services.AddOidcAuthentication(options =>
{
    builder.Configuration.Bind("Auth0", options.ProviderOptions);
    options.ProviderOptions.ResponseType = "code";
    options.ProviderOptions.AdditionalProviderParameters
        .Add("audience", builder.Configuration["Auth0:Audience"]);
});

//builder.Services.AddAuthorizationCore(options =>
//{
//    options.AddPolicy(Policies.CanViewClients, Policies.CanViewClientsPolicy());
//    options.AddPolicy(Policies.CanViewReports, Policies.CanViewReportsClient1Policy());
//});

await builder.Build().RunAsync();