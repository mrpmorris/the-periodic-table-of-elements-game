using Fluxor;
using ThePeriodicTableOfElementsGame.GamePlay.Features.ElementsSpeedMatchGame.Actions;

namespace ThePeriodicTableOfElementsGame.GamePlay.Features.ElementsSpeedMatchGame;

public static class Reducers
{
	[ReducerMethod]
	public static ElementsSpeedMatchGameState HighlightElement(ElementsSpeedMatchGameState state, HighlightElementAction action) =>
		state with
		{
			HighlightedAtomicNumber = action.AtomicNumber
		};
}
