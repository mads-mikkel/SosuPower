using Microsoft.Extensions.Logging;

using SosuPower.CareApp.ViewModels;
using SosuPower.CareApp.Views;
using SosuPower.Services;

namespace SosuPower.CareApp
{
    public static class MauiProgram
    {
        private const string url = "https://localhost:7006/api/";

        public static MauiApp CreateMauiApp()
        {
            var builder = MauiApp.CreateBuilder();
            builder
                .UseMauiApp<App>()
                .ConfigureFonts(fonts =>
                {
                    fonts.AddFont("OpenSans-Regular.ttf", "OpenSansRegular");
                    fonts.AddFont("OpenSans-Semibold.ttf", "OpenSansSemibold");
                });

            Uri baseUri = new Uri(url);
            builder.Services.AddScoped<ISosuService>(x => new SosuService(baseUri));
            builder.Services.AddSingleton<MainPageViewModel>();
            builder.Services.AddSingleton<MainPage>();

#if DEBUG
            builder.Logging.AddDebug();
#endif

            return builder.Build();
        }
    }
}
