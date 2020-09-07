using Fluxor;
using Microsoft.AspNetCore.Components;
using ThePeriodicTableOfElementsGame.GamePlay.ElementsMatchGame;

namespace ThePeriodicTableOfElementsGame.Web.Scenes
{
	public partial class MainMenu
	{
		[Inject]
		private IDispatcher Dispatcher { get; set; }

		[Inject]
		private NavigationManager NavigationManager { get; set; }

		private void PlayMatchGame(MatchType matchType)
		{
			Dispatcher.Dispatch(new StartGameAction(matchType));
			NavigationManager.NavigateTo("/match-game");
		}
	}
}
