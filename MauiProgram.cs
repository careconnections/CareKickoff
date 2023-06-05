using Microsoft.Extensions.Logging;
using CareKickoff.Data;

namespace CareKickoff;

public static class MauiProgram
{
    public static MauiApp CreateMauiApp()
    {
        var builder = MauiApp.CreateBuilder();
        builder
            .UseMauiApp<App>()
            .ConfigureFonts(fonts =>
            {
                fonts.AddFont("OpenSans-Regular.ttf", "OpenSansRegular");
            });

        builder.Services.AddMauiBlazorWebView();

#if DEBUG
        builder.Services.AddBlazorWebViewDeveloperTools();
        builder.Logging.AddDebug();
#endif

        builder.Services.AddSingleton<ClientService>();
        builder.Services.AddSingleton<CareplanService>();
        builder.Services.AddSingleton<EmployeeService>();
        builder.Services.AddSingleton<ReportService>();


        return builder.Build();
    }
}
