using System.Threading.Tasks;
using Microsoft.AspNetCore.Components.WebAssembly.Hosting;
using Fluxor;
using ThePeriodicTableOfElementsGame.Store.GameState;
using Microsoft.Extensions.DependencyInjection;
using ThePeriodicTableOfElementsGame.Store.Services;
using ThePeriodicTableOfElementsGame.Services;

namespace ThePeriodicTableOfElementsGame
{
	public class Program
	{
		public static async Task Main(string[] args)
		{
			var builder = WebAssemblyHostBuilder.CreateDefault(args);
			builder.RootComponents.Add<App>("app");
			builder.Services.AddScoped<IAudioPlayer, AudioPlayer>();
			builder.Services.AddFluxor(x => x.ScanAssemblies(typeof(GameState).Assembly).UseReduxDevTools());
			await builder.Build().RunAsync();
		}
	}
}
