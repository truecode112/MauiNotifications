using Microsoft.AspNetCore.Components.WebView.Maui;
using MauiNotifications.Data;
using System.Reflection;
using Microsoft.Extensions.Configuration;
using Radzen;
using Amazon.SimpleNotificationService;
using MauiNotifications.Services.Subscriptions;
using MauiNotifications.Services.Topics;

namespace MauiNotifications;

public static class MauiProgram
{
    public static IServiceProvider Services { get; private set; }

    public static MauiApp CreateMauiApp()
	{
		var builder = MauiApp.CreateBuilder();
        using var stream = Assembly.GetExecutingAssembly().GetManifestResourceStream("MauiNotifications.Settings.appsettings.json");

		var config = new ConfigurationBuilder()
			.AddJsonStream(stream)
			.Build();
		
		builder.Configuration.AddConfiguration(config);
		builder
			.UseMauiApp<App>()
			.ConfigureFonts(fonts =>
			{
				fonts.AddFont("OpenSans-Regular.ttf", "OpenSansRegular");
			});

		builder.Services.AddMauiBlazorWebView();
        builder.Services.AddScoped<DialogService>();
        builder.Services.AddScoped<NotificationService>();
        builder.Services.AddScoped<TooltipService>();
        builder.Services.AddScoped<ContextMenuService>();
		
#if DEBUG
        builder.Services.AddBlazorWebViewDeveloperTools();
#endif
		
		builder.Services.AddSingleton<WeatherForecastService>();



        builder.Services.AddAWSService<IAmazonSimpleNotificationService>();
        //builder.Services.AddSingleton<ITopicService, SnsTopicService>();
        builder.Services.AddSingleton<SnsTopicService>();

        builder.Services.AddSingleton<SubscriptionService>();

        var app = builder.Build();
        Services = app.Services;
        return app;
	}
}
