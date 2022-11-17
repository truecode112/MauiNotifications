using Microsoft.AspNetCore.Components.WebView.Maui;
using MauiNotifications.Data;
using MudBlazor.Services;
using MudBlazor;

namespace MauiNotifications;

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
		builder.Services.AddMudServices(config =>
		{
            config.SnackbarConfiguration.PositionClass = Defaults.Classes.Position.BottomCenter;

            config.SnackbarConfiguration.PreventDuplicates = true;
            config.SnackbarConfiguration.NewestOnTop = true;
            config.SnackbarConfiguration.ShowCloseIcon = true;
            config.SnackbarConfiguration.VisibleStateDuration = 2000;
            config.SnackbarConfiguration.HideTransitionDuration = 300;
            config.SnackbarConfiguration.ShowTransitionDuration = 300;
            config.SnackbarConfiguration.SnackbarVariant = Variant.Filled;
        });
#if DEBUG
        builder.Services.AddBlazorWebViewDeveloperTools();
#endif
		
		builder.Services.AddSingleton<WeatherForecastService>();

		return builder.Build();
	}
}
