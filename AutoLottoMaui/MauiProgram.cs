using Microsoft.Extensions.Logging;
using AutoLottoMaui.ViewModels;
using AutoLottoMaui.Services;

namespace AutoLottoMaui;

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
			});

        builder.Services.AddTransient<BaseViewModel>();
		builder.Services.AddSingleton<HttpService>();


#if DEBUG
        builder.Logging.AddDebug();
#endif

		return builder.Build();
	}
}
