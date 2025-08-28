using ThePeriodicTableOfElementsGame.GamePlay.Features.ElementsMatchGame;
using ThePeriodicTableOfElementsGame.GamePlay.Features.ElementsMatchGame.Actions;

namespace ThePeriodicTableOfElementsGame.Blazor.Web.Scenes.TitleScreen;

public partial class TitleScreen
{
	private void StartPlaceTheNameGame()
	{
		var action = new StartElementsMatchGameAction(MatchType.PlaceTheName);
		Dispatcher.Dispatch(action);
	}

	private void StartPlaceTheSymbolGame()
	{
		var action = new StartElementsMatchGameAction(MatchType.PlaceTheSymbol);
		Dispatcher.Dispatch(action);
	}

	private void StartSpeedMatchGame()
	{
	}
}