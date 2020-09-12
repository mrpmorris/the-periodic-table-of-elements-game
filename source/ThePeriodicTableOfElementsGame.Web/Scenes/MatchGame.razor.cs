using Fluxor;
using Microsoft.AspNetCore.Components;
using ThePeriodicTableOfElementsGame.GamePlay.ElementsMatchGame;
using ThePeriodicTableOfElementsGame.GamePlay.Navigation;
using ThePeriodicTableOfElementsGame.GamePlay.Navigation.Actions;
using ThePeriodicTableOfElementsGame.GamePlay.PeriodicTableData;
using ThePeriodicTableOfElementsGame.Web.Extensions;

namespace ThePeriodicTableOfElementsGame.Web.Scenes
{
	public partial class MatchGame
	{
		[Inject]
		private IState<ElementMatchGameState> GameState { get; set; }

		[Inject]
		private IDispatcher Dispatcher { get; set; }

		protected override void OnAfterRender(bool firstRender)
		{
			base.OnAfterRender(firstRender);
			if (firstRender)
				Dispatcher.Dispatch(new StartGameAction());
		}

		private string GetUIStatusCss()
		{
			if (GameState.Value.IsGameOver)
				return "--game-over";
			if (GameState.Value.IsGameOverSequence)
				return "--game-over-sequence";
			return null;
		}

		private string GetElementGroupAsCssClass() =>
			GameState.Value.ExpectedElement is null || !GameState.Value.ShowElementGroup
			? ""
			: ElementGroupExtensions.GetAsCssClass(
					TableOfElementsData.ElementByNumber[GameState.Value.ExpectedElement.Value].Group);

		private void GoToMainMenu()
		{
			Dispatcher.Dispatch(new NavigateAction(SceneType.MainMenu));
		}
	}
}
