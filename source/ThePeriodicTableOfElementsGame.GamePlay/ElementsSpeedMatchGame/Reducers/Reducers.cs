using Fluxor;
using ThePeriodicTableOfElementsGame.GamePlay.ElementsSpeedMatchGame.Actions;

namespace ThePeriodicTableOfElementsGame.GamePlay.ElementsSpeedMatchGame.Reducers
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
