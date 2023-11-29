using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Logging.Console;
using Silk.NET.Core;
using Silk.NET.Maths;
using Silk.NET.Vulkan;
using Silk.NET.Windowing;

namespace Editor;

public static class MauiProgram
{
	public static MauiApp CreateMauiApp()
	{
        using ILoggerFactory factory = LoggerFactory.Create(builder => builder.AddConsole());
        ILogger logger = factory.CreateLogger("Program");
        logger.LogInformation("THERE IS AN IMPOSTER AMONG US");
		var builder = MauiApp.CreateBuilder();
		builder
			.UseMauiApp<App>()
			.ConfigureFonts(fonts =>
			{
				fonts.AddFont("OpenSans-Regular.ttf", "OpenSansRegular");
				fonts.AddFont("OpenSans-Semibold.ttf", "OpenSansSemibold");
			});

#if DEBUG
		builder.Logging.AddDebug();
#endif
		var options = WindowOptions.DefaultVulkan with {
			Size = new Vector2D<int>(800, 600),
			Title = "Silk.NET Vulkan"
		};
		Silk.NET.Windowing.IWindow window = Silk.NET.Windowing.Window.Create(options);
		window.Initialize();
		if (window.VkSurface is null) {
			throw new Exception("Windowing system does not support Vulkan");
		}
		return builder.Build();
	}
}
