using Fluxor;
using System.Linq;

namespace ThePeriodicTableOfElementsGame.Store.GameState
{
	public static class Reducers
	{
		[ReducerMethod]
		public static GameState Reduce(GameState state, ClickElementAction action) =>
			state with
		{
			ElementStates = state.ElementStates
						.Select(x =>
							x.AtomicNumber != action.AtomicNumber
							? x
							: x with { Concealed = !x.Concealed })
		};

		[ReducerMethod]
		public static GameState Reduce(GameState state, SetCorrectElementAction action) =>
			state with
		{
			CorrectElement = action.AtomicNumber,
			AvailableElements = state.AvailableElements.Remove(action.AtomicNumber)
		};
	}
}
