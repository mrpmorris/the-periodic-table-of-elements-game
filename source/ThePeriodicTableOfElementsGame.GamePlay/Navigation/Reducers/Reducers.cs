using Fluxor;
using ThePeriodicTableOfElementsGame.GamePlay.Navigation.Actions;

namespace ThePeriodicTableOfElementsGame.GamePlay.Navigation.Reducers
{
	public static class Reducers
	{
		[ReducerMethod]
		public static NavigationState Reduce(NavigationState state, NavigateAction action) =>
			state with { Scene = action.Scene };
	}
}
