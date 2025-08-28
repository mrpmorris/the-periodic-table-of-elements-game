using Fluxor;
using Microsoft.AspNetCore.Components;
using System;
using ThePeriodicTableOfElementsGame.GamePlay.PeriodicTableData;
using ThePeriodicTableOfElementsGame.Blazor.Web.Extensions;
using ThePeriodicTableOfElementsGame.GamePlay.Features.ElementsMatchGame;

namespace ThePeriodicTableOfElementsGame.Blazor.Web.Scenes.ElementsMatchGame;

public partial class ElementsMatchGame
{
	[Inject]
	private IState<ElementsMatchGameState> GameState { get; set; }

	[Inject]
	private IDispatcher Dispatcher { get; set; }

	private string GetUIStatusCss()
	{
		string matchmodeCSS = GameState.Value.MatchType switch
		{
			MatchType.PlaceTheName => "--place-the-name",
			MatchType.PlaceTheSymbol => "--place-the-symbol",
			_ => throw new NotImplementedException(GameState.Value.MatchType.ToString())
		};

		string sceneTypeCss = GameState.Value.SubSceneType switch
		{
			SubSceneType.Gameplay => "--gameplay",
			SubSceneType.TransitionToGameOver => "--game-over-sequence",
			SubSceneType.GameOver => "--game-over",
			_ => throw new NotImplementedException(GameState.Value.SubSceneType.ToString())
		};

		string highlightedElementGroup = "";
		byte? expectedAtomicNumber = GameState.Value.ExpectedElement;
		if (GameState.Value.HighlighElementsInExpectedGroup && expectedAtomicNumber.HasValue)
		{
			ElementGroup expectedElementGroup =
				TableOfElementsData.ElementByNumber[expectedAtomicNumber.Value].Group;
			highlightedElementGroup = "--highlight-group" + expectedElementGroup.GetAsCssClass(); 
		}

		return $"{matchmodeCSS} {sceneTypeCss} {highlightedElementGroup}";
	}

	private string GetElementGroupAsCssClass() =>
		GameState.Value.ExpectedElement is null || !GameState.Value.ShowElementGroup
		? ""
		: ElementGroupExtensions.GetAsCssClass(
				TableOfElementsData.ElementByNumber[GameState.Value.ExpectedElement.Value].Group);

	private void GoToMainMenu()
	{
		var action = new GamePlay.Features.App.Actions.ChangeSceneAction(GamePlay.Features.App.Scene.TitleScreen);
		Dispatcher.Dispatch(action);
	}
}
