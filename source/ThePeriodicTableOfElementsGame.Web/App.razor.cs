using Fluxor;
using Microsoft.AspNetCore.Components;
using ThePeriodicTableOfElementsGame.GamePlay.Navigation;

namespace ThePeriodicTableOfElementsGame.Web
{
	public partial class App
	{
		[Inject]
		public IState<NavigationState> NavigationState { get; set; }
	}
}
