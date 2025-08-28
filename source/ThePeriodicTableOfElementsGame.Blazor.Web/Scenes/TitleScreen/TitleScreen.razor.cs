
using ThePeriodicTableOfElementsGame.GamePlay.ElementsMatchGame;

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