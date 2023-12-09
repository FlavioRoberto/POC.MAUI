using Microsoft.Extensions.Logging;
using ControleFinanceiro.Infra;

namespace ControleFinanceiro.MAUI;

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

		builder.Services.AddInfra();
		builder.Services.AddViews();
#if DEBUG
        builder.Logging.AddDebug();
#endif

		return builder.Build();
	}
}

