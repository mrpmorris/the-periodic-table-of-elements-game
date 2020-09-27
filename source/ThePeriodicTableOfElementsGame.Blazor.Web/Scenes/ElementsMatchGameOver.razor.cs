using Fluxor;
using Microsoft.AspNetCore.Components;
using ThePeriodicTableOfElementsGame.GamePlay.ElementsMatchGameFeature;
using ThePeriodicTableOfElementsGame.GamePlay.SharedFeature;
using ThePeriodicTableOfElementsGame.GamePlay.SharedFeature.Actions;

namespace ThePeriodicTableOfElementsGame.Blazor.Web.Scenes
{
	public partial class ElementsMatchGameOver
	{
		[Inject]
		private IState<ElementsMatchGameState> GameState { get; set; }

		[Inject]
		private IState<SharedState> SharedState { get; set; }

		[Inject]
		private IDispatcher Dispatcher { get; set; }

		private string GetUIStatusCss()
		{
			if (SharedState.Value.Scene == SceneType.TransitionFromElementsMatchGameToGameOver)
				return "--game-over-sequence";
			if (SharedState.Value.Scene == SceneType.ElementsMatchGameOver)
				return "--game-over";
			return null;
		}

		private void GoToMainMenu()
		{
			Dispatcher.Dispatch(new NavigateAction(SceneType.MainMenu));
		}
	}
}
