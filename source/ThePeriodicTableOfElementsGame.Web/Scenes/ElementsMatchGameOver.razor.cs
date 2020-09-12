using Fluxor;
using Microsoft.AspNetCore.Components;
using ThePeriodicTableOfElementsGame.GamePlay.ElementsMatchGame;
using ThePeriodicTableOfElementsGame.GamePlay.Navigation;
using ThePeriodicTableOfElementsGame.GamePlay.Navigation.Actions;

namespace ThePeriodicTableOfElementsGame.Web.Scenes
{
	public partial class ElementsMatchGameOver
	{
		[Inject]
		private IState<ElementsMatchGameState> GameState { get; set; }

		[Inject]
		private IState<NavigationState> NavigationState { get; set; }

		[Inject]
		private IDispatcher Dispatcher { get; set; }

		private string GetUIStatusCss()
		{
			if (NavigationState.Value.Scene == SceneType.TransitionFromElementsMatchGameToGameOver)
				return "--game-over-sequence";
			if (NavigationState.Value.Scene == SceneType.ElementsMatchGameOver)
				return "--game-over";
			return null;
		}

		private void GoToMainMenu()
		{
			Dispatcher.Dispatch(new NavigateAction(SceneType.MainMenu));
		}
	}
}
