using Fluxor;
using ThePeriodicTableOfElementsGame.GamePlay.Features.ElementsSpeedMatchGame;
using ThePeriodicTableOfElementsGame.GamePlay.Features.ElementsSpeedMatchGame.Actions;

namespace ThePeriodicTableOfElementsGame.GamePlay.Features.ElementsSpeedMatchGame.Reducers
{
	public static class Reducers
	{
		[ReducerMethod]
		public static ElementsSpeedMatchGameState HighlightElement(ElementsSpeedMatchGameState state, HighlightElementAction action) =>
			state with
			{
				HighlightedAtomicNumber = action.AtomicNumber
			};
	}
}
