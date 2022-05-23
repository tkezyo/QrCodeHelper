using QrCodeHelper.ViewModels;

namespace QrCodeHelper;

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
                fonts.AddFont("OpenSans-Semibold.ttf", "OpenSansSemibold");
            })
               .ConfigureEssentials();

        builder.Services.AddTransient(typeof(MainPage));
        builder.Services.AddTransient(typeof(MainViewModel));



        return builder.Build();
    }
}
