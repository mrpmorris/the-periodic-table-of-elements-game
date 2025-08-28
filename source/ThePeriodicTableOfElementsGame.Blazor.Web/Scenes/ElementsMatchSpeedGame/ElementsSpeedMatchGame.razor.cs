using Fluxor;
using Microsoft.AspNetCore.Components;
using ThePeriodicTableOfElementsGame.GamePlay.PeriodicTableData;
using ThePeriodicTableOfElementsGame.Blazor.Web.Extensions;
using ThePeriodicTableOfElementsGame.GamePlay.Features.ElementsSpeedMatchGame;

namespace ThePeriodicTableOfElementsGame.Blazor.Web.Scenes.ElementsMatchSpeedGame;

public partial class ElementsSpeedMatchGame
{
	[Inject]
	private IState<ElementsSpeedMatchGameState> GameState { get; set; }

	[Inject]
	private IDispatcher Dispatcher { get; set; }

	private void GoToMainMenu()
	{
		var action = new GamePlay.Features.App.Actions.ChangeSceneAction(GamePlay.Features.App.Scene.TitleScreen);
		Dispatcher.Dispatch(action);
	}

	private string GetElementHighlighterStyle()
	{
		byte? highlightedAtomicNumber = GameState.Value.HighlightedAtomicNumber;
		if (highlightedAtomicNumber == null)
			return "";

		ElementData data = TableOfElementsData.ElementByNumber[highlightedAtomicNumber.Value];
		return $"top: {data.GetCssStyleTop()}; left: {data.GetCssStyleLeft()};";
	}
}
