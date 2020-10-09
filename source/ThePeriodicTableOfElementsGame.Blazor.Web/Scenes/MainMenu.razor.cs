using Fluxor;
using Microsoft.AspNetCore.Components;
using ThePeriodicTableOfElementsGame.GamePlay.ElementsMatchGameFeature;

namespace ThePeriodicTableOfElementsGame.Blazor.Web.Scenes
{
	public partial class MainMenu
	{
		[Inject]
		private IDispatcher Dispatcher { get; set; }

		private void PlayMatchGame(MatchType matchType)
		{
			Dispatcher.Dispatch(new GamePlay.ElementsMatchGameFeature.Actions.StartGameAction(matchType));
		}

		private void PlaySpeedMatchGame()
		{
			Dispatcher.Dispatch(new GamePlay.ElementsSpeedMatchGameFeature.Actions.StartGameAction());
		}
	}
}
