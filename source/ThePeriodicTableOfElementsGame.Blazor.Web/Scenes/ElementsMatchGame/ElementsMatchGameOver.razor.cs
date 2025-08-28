using Fluxor;
using Microsoft.AspNetCore.Components;
using ThePeriodicTableOfElementsGame.GamePlay.Features.ElementsMatchGame;

namespace ThePeriodicTableOfElementsGame.Blazor.Web.Scenes.ElementsMatchGame;

public partial class ElementsMatchGameOver
{
	[Inject]
	private IState<ElementsMatchGameState> GameState { get; set; }

	[Inject]
	private IDispatcher Dispatcher { get; set; }

	private string GetUIStatusCss()
	{
		if (GameState.Value.SubSceneType == SubSceneType.TransitionToGameOver)
			return "--game-over-sequence";
		if (GameState.Value.SubSceneType == SubSceneType.GameOver)
			return "--game-over";
		return null;
	}

	private void GoToMainMenu()
	{
		var action = new GamePlay.Features.App.Actions.ChangeSceneAction(GamePlay.Features.App.Scene.TitleScreen);
		Dispatcher.Dispatch(action);
	}
}
