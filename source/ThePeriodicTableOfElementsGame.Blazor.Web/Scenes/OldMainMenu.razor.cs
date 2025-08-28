using Fluxor;
using Microsoft.AspNetCore.Components;
using ThePeriodicTableOfElementsGame.GamePlay.ElementsMatchGame;
using ThePeriodicTableOfElementsGame.GamePlay.ElementsMatchGame.Actions;
using ThePeriodicTableOfElementsGame.GamePlay.Navigation;
using ThePeriodicTableOfElementsGame.GamePlay.Navigation.Actions;

namespace ThePeriodicTableOfElementsGame.Blazor.Web.Scenes
{
	public partial class OldMainMenu
	{
		[Inject]
		private IDispatcher Dispatcher { get; set; }

		private void PlayMatchGame(MatchType matchType)
		{
			Dispatcher.Dispatch(new SelectGameAction(matchType));
			Dispatcher.Dispatch(new NavigateAction(SceneType.ElementsMatchGame));
		}

		private void PlaySpeedMatchGame()
		{
			Dispatcher.Dispatch(new SelectGameAction(MatchType.SpeedMatch));
			Dispatcher.Dispatch(new NavigateAction(SceneType.ElementSpeedMatchGame));
		}
	}
}
