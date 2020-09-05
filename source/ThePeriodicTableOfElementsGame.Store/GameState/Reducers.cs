using Fluxor;
using System.Linq;

namespace ThePeriodicTableOfElementsGame.Store.GameState
{
	public static class Reducers
	{
		[ReducerMethod]
		public static GameState Reduce(GameState state, RevealElementAction action) => state with
		{
			ElementStates = state.ElementStates
						.Select(x =>
							x.AtomicNumber != action.AtomicNumber
							? x
							: x with { Concealed = false })
		};

		[ReducerMethod]
		public static GameState Reduce(GameState state, ConcealAllElementsAction _) => state with
		{
			ElementStates = state.ElementStates
				.Select(x => x with { Concealed = true })
		};

		[ReducerMethod]
		public static GameState Reduce(GameState state, SetExpectedElementAction action) => state with
		{
			ExpectedElement = action.AtomicNumber,
			AvailableElements = state.AvailableElements.Remove(action.AtomicNumber)
		};
	}
}
