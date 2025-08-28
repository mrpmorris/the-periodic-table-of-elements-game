using Fluxor;
using Microsoft.AspNetCore.Components;
using ThePeriodicTableOfElementsGame.GamePlay.PeriodicTableData;
using ThePeriodicTableOfElementsGame.GamePlay.Services;
using ThePeriodicTableOfElementsGame.Blazor.Web.Extensions;
using ThePeriodicTableOfElementsGame.GamePlay.ElementsSpeedMatchGame;
using ThePeriodicTableOfElementsGame.GamePlay.Navigation;
using ThePeriodicTableOfElementsGame.GamePlay.Navigation.Actions;

namespace ThePeriodicTableOfElementsGame.Blazor.Web.Scenes.ElementsMatchSpeedGame;

public partial class ElementsSpeedMatchGame
{
	[Inject]
	private IState<ElementsSpeedMatchGameState> GameState { get; set; }

	[Inject]
	private IDispatcher Dispatcher { get; set; }

	[Inject]
	private IAudioPlayer AudioPlayer { get; set; }

	private void GoToMainMenu()
	{
		Dispatcher.Dispatch(new NavigateAction(SceneType.MainMenu));
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
