using Fluxor;
using Microsoft.AspNetCore.Components;
using System;
using ThePeriodicTableOfElementsGame.GamePlay.ElementsMatchGame;
using ThePeriodicTableOfElementsGame.GamePlay.ElementsMatchGame.Actions;
using ThePeriodicTableOfElementsGame.GamePlay.Navigation;
using ThePeriodicTableOfElementsGame.GamePlay.Navigation.Actions;
using ThePeriodicTableOfElementsGame.GamePlay.PeriodicTableData;
using ThePeriodicTableOfElementsGame.Blazor.Web.Extensions;

namespace ThePeriodicTableOfElementsGame.Blazor.Web.Scenes
{
	public partial class ElementsMatchGame
	{
		[Inject]
		private IState<ElementsMatchGameState> GameState { get; set; }

		[Inject]
		private IState<NavigationState> NavigationState { get; set; }

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
			string matchmodeCSS = GameState.Value.MatchType switch
			{
				MatchType.PlaceTheName => "--place-the-name",
				MatchType.PlaceTheSymbol => "--place-the-symbol",
				_ => throw new NotImplementedException(GameState.Value.MatchType.ToString())
			};

			string sceneTypeCss = NavigationState.Value.Scene switch
			{
				SceneType.ElementsMatchGameOver => "--game-over",
				SceneType.TransitionFromElementsMatchGameToGameOver => "--game-over-sequence",
				SceneType.ElementsMatchGame => "--gameplay",
				SceneType.MainMenu => "",
				_ => throw new NotImplementedException(NavigationState.Value.Scene.ToString())
			};

			return $"{matchmodeCSS} {sceneTypeCss}";
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
