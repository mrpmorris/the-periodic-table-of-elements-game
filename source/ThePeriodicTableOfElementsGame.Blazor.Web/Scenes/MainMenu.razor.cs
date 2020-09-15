using Fluxor;
using Microsoft.AspNetCore.Components;
using ThePeriodicTableOfElementsGame.GamePlay.ElementsMatchGame;
using ThePeriodicTableOfElementsGame.GamePlay.ElementsMatchGame.Actions;
using ThePeriodicTableOfElementsGame.GamePlay.Navigation;
using ThePeriodicTableOfElementsGame.GamePlay.Navigation.Actions;

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
	}
}
