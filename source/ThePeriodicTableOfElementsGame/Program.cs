using System.Threading.Tasks;
using Microsoft.AspNetCore.Components.WebAssembly.Hosting;
using Fluxor;
using ThePeriodicTableOfElementsGame.Store.GameState;

namespace ThePeriodicTableOfElementsGame
{
	public class Program
	{
		public static async Task Main(string[] args)
		{
			var builder = WebAssemblyHostBuilder.CreateDefault(args);
			builder.RootComponents.Add<App>("app");
			builder.Services.AddFluxor(x => x.ScanAssemblies(typeof(GameState).Assembly).UseReduxDevTools());
			await builder.Build().RunAsync();
		}
	}
}
