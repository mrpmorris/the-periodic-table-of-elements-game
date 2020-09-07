using Fluxor;
using System.Collections.Immutable;
using System.Linq;

namespace ThePeriodicTableOfElementsGame.GamePlay.ElementsMatchGame
{
	public static class Reducers
	{
		[ReducerMethod]
		public static ElementMatchGameState Reduce(ElementMatchGameState state, RevealElementAction action) => state with
		{
			ElementStates = state.ElementStates.Values
				.Select(x =>
					x.AtomicNumber != action.AtomicNumber
					? x
					: x with { Concealed = false })
				.ToImmutableDictionary(x => x.AtomicNumber)
		};

		[ReducerMethod]
		public static ElementMatchGameState Reduce(ElementMatchGameState state, ConcealAllElementsAction _) => state with
		{
			ElementStates = state.ElementStates.Values
				.Select(x => x with { Concealed = true })
				.ToImmutableDictionary(x => x.AtomicNumber)
		};

		[ReducerMethod]
		public static ElementMatchGameState Reduce(ElementMatchGameState state, SetExpectedElementAction action) => state with
		{
			ExpectedElement = action.AtomicNumber,
			ShowElementGroup = false,
			AvailableElements = state.AvailableElements.Remove(action.AtomicNumber)
		};

		[ReducerMethod]
		public static ElementMatchGameState Reduce(ElementMatchGameState state, RevealElementGroupAction action) =>
			(state.ExpectedElement != action.AtomicNumber)
			? state
			: state with { ShowElementGroup = true };

		[ReducerMethod]
		public static ElementMatchGameState Reduce(ElementMatchGameState state, ElementMatchedAction _) => state with
		{
			TotalMatched = state.TotalMatched + 1
		};

		[ReducerMethod]
		public static ElementMatchGameState Reduce(ElementMatchGameState state, ElementMismatchedAction _) => state with
		{
			TotalMismatched = state.TotalMismatched + 1
		};
	}
}
