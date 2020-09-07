using System.Threading.Tasks;
using Microsoft.AspNetCore.Components.WebAssembly.Hosting;
using Fluxor;
using ThePeriodicTableOfElementsGame.GamePlay.ElementsMatchGame;
using Microsoft.Extensions.DependencyInjection;
using ThePeriodicTableOfElementsGame.GamePlay.Services;
using ThePeriodicTableOfElementsGame.Web.Services;

namespace ThePeriodicTableOfElementsGame.Web
{
	public class Program
	{
		public static async Task Main(string[] args)
		{
			var builder = WebAssemblyHostBuilder.CreateDefault(args);
			builder.RootComponents.Add<App>("app");
			builder.Services.AddScoped<IAudioPlayer, AudioPlayer>();
			builder.Services.AddFluxor(x => x
				.ScanAssemblies(typeof(ElementMatchGameState).Assembly)
#if DEBUG
				.UseReduxDevTools()
#endif
			);
			await builder.Build().RunAsync();
		}
	}
}
