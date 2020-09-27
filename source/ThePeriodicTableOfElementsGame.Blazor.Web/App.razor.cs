using Fluxor;
using Microsoft.AspNetCore.Components;
using ThePeriodicTableOfElementsGame.GamePlay.SharedFeature;

namespace ThePeriodicTableOfElementsGame.Blazor.Web
{
	public partial class App
	{
		[Inject]
		public IState<SharedState> SharedState { get; set; }
	}
}
