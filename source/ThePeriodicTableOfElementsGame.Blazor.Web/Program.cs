using Fluxor;
using Microsoft.AspNetCore.Components.WebAssembly.Hosting;
using Microsoft.Extensions.DependencyInjection;
using System.Threading.Tasks;
using ThePeriodicTableOfElementsGame.Blazor.Web.Services;
using ThePeriodicTableOfElementsGame.GamePlay.ElementsMatchGame;
using ThePeriodicTableOfElementsGame.GamePlay.Services;

namespace ThePeriodicTableOfElementsGame.Blazor.Web
{
	public class Program
	{
		public static async Task Main(string[] args)
		{
			var builder = WebAssemblyHostBuilder.CreateDefault(args);
			builder.RootComponents.Add<App>("#app");

			builder.Services.AddScoped<IAudioPlayer, AudioPlayer>();
			builder.Services.AddFluxor(x => x
				.ScanAssemblies(typeof(ElementsMatchGameState).Assembly)
#if DEBUG
				.UseReduxDevTools()
#endif
			);


			await builder.Build().RunAsync();
		}
	}
}
