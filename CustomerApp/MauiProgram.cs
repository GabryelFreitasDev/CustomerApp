using CommunityToolkit.Maui;
using CustomerApp.Data;
using CustomerApp.Services;
using CustomerApp.ViewModels;
using CustomerApp.Views;
using Microsoft.Extensions.Logging;

namespace CustomerApp
{
    public static class MauiProgram
    {
        public static MauiApp CreateMauiApp()
        {
            var builder = MauiApp.CreateBuilder();
            builder.UseMauiApp<App>()
                .UseMauiCommunityToolkit()
                .ConfigureFonts(fonts =>
                {
                    fonts.AddFont("OpenSans-Regular.ttf", "OpenSansRegular");
                    fonts.AddFont("OpenSans-Semibold.ttf", "OpenSansSemibold");
                });


            builder.Services.AddSingleton<DatabaseContext>();

            builder.Services.AddSingleton<ClienteService>();

            builder.Services.AddTransient<MainViewModel>();
            builder.Services.AddTransient<ClienteRegistrationViewModel>();

            builder.Services.AddSingleton<MainPage>();
            builder.Services.AddTransient<ClienteRegistrationPage>();

#if DEBUG
            builder.Logging.AddDebug();
#endif

            return builder.Build();
        }
    }
}
