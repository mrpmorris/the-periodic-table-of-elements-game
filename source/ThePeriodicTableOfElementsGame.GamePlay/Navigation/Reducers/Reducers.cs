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

		[ReducerMethod(typeof(StartGameOverSequenceAction))]
		public static NavigationState StartGameOverSequenceAction(NavigationState state) =>
			new NavigationState(SceneType.TransitionFromElementsMatchGameToGameOver);

		[ReducerMethod(typeof(CompleteGameOverAction))]
		public static NavigationState CompleteGameOverAction(NavigationState state) =>
			new NavigationState(SceneType.ElementsMatchGameOver);
	}
}
