using Fluxor;
using ThePeriodicTableOfElementsGame.GamePlay.ElementsMatchGame.Actions;
using ThePeriodicTableOfElementsGame.GamePlay.Navigation.Actions;

namespace ThePeriodicTableOfElementsGame.GamePlay.Navigation.Reducers
{
	public static class Reducers
	{
		[ReducerMethod]
		public static NavigationState Reduce(NavigationState state, NavigateAction action) =>
			state with { Scene = action.Scene };

		[ReducerMethod]
		public static NavigationState Reduce(NavigationState state, StartGameOverSequenceAction _) =>
			new NavigationState(SceneType.TransitionFromElementsMatchGameToGameOver);

		[ReducerMethod]
		public static NavigationState Reduce(NavigationState state, CompleteGameOverAction _) =>
			new NavigationState(SceneType.ElementsMatchGameOver);
	}
}
