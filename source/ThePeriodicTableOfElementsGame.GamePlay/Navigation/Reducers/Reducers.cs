using Fluxor;
using ThePeriodicTableOfElementsGame.GamePlay.ElementsMatchGame.Actions;
using ThePeriodicTableOfElementsGame.GamePlay.Navigation.Actions;

namespace ThePeriodicTableOfElementsGame.GamePlay.Navigation.Reducers
{
	public static class Reducers
	{
		[ReducerMethod]
		public static NavigationState NavigateAction(NavigationState state, NavigateAction action) =>
			new NavigationState(action.Scene);

		[ReducerMethod]
		public static NavigationState StartGameOverSequenceAction(NavigationState state, StartGameOverSequenceAction _) =>
			new NavigationState(SceneType.TransitionFromElementsMatchGameToGameOver);

		[ReducerMethod]
		public static NavigationState CompleteGameOverAction(NavigationState state, CompleteGameOverAction _) =>
			new NavigationState(SceneType.ElementsMatchGameOver);
	}
}
