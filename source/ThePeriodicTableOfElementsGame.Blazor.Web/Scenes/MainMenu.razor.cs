using Fluxor;
using Microsoft.AspNetCore.Components;
using ThePeriodicTableOfElementsGame.GamePlay.ElementsMatchGameFeature;
using ThePeriodicTableOfElementsGame.GamePlay.ElementsMatchGameFeature.Actions;
using ThePeriodicTableOfElementsGame.GamePlay.Shared;
using ThePeriodicTableOfElementsGame.GamePlay.Shared.Actions;

namespace ThePeriodicTableOfElementsGame.Blazor.Web.Scenes
{
	public partial class MainMenu
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
			Dispatcher.Dispatch(new NavigateAction(SceneType.ElementSpeedMatchGame));
		}
	}
}
