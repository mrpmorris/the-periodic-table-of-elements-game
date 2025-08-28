using Fluxor;
using Microsoft.AspNetCore.Components.WebAssembly.Hosting;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.JSInterop;
using ThePeriodicTableOfElementsGame.Blazor.Web;
using ThePeriodicTableOfElementsGame.Blazor.Web.Services.Audio;
using ThePeriodicTableOfElementsGame.GamePlay.ElementsMatchGame;
using ThePeriodicTableOfElementsGame.GamePlay.Services;
#if DEBUG
using Fluxor.Blazor.Web.ReduxDevTools;
#endif

var builder = WebAssemblyHostBuilder.CreateDefault(args);
builder.RootComponents.Add<App>("#app");

builder.Services.AddScoped<IAudioPlayer, AudioPlayer>();
builder.Services.AddScoped(
	sp => (IJSInProcessRuntime)sp.GetRequiredService<IJSRuntime>());

builder.Services.AddFluxor(x => x
	.ScanAssemblies(typeof(ElementsMatchGameState).Assembly)
#if DEBUG
	.UseReduxDevTools()
#endif
);


await builder.Build().RunAsync();
