using Fluxor;
using ThePeriodicTableOfElementsGame.GamePlay.ElementsSpeedMatchGameFeature.Actions;

namespace ThePeriodicTableOfElementsGame.GamePlay.ElementsSpeedMatchGameFeature.Reducers
{
	public static class Reducers
	{
		[ReducerMethod]
		public static ElementsSpeedMatchGameState HighlightElement(ElementsSpeedMatchGameState state, HighlightElementAction action) =>
			state.With(highlightedAtomicNumber: action.AtomicNumber);
	}
}
