using AppKids.Data;
using Microsoft.Extensions.Logging;

namespace AppKids;

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

        // --- Configuración de SQLite ---

        builder.Services.AddSingleton<DatabaseRepository>();

        // --- Configuración de Páginas (Para I/D) ---

		builder.Services.AddTransient<MainPage>();
		builder.Services.AddTransient<Register>();

#if DEBUG
        builder.Logging.AddDebug();
#endif

        return builder.Build();
	}
}
