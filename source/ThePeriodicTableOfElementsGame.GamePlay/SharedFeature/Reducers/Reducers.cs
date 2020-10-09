using Fluxor;
using ThePeriodicTableOfElementsGame.GamePlay.ElementsMatchGameFeature.Actions;
using ThePeriodicTableOfElementsGame.GamePlay.SharedFeature.Actions;

namespace ThePeriodicTableOfElementsGame.GamePlay.SharedFeature.Reducers
{
	public static class Reducers
	{
		[ReducerMethod]
		public static SharedState Navigate(SharedState state, NavigateAction action) =>
			new SharedState(action.Scene);

		[ReducerMethod]
		public static SharedState StartGameOverSequence(SharedState state, StartGameOverSequenceAction _) =>
			new SharedState(SceneType.TransitionFromElementsMatchGameToGameOver);

		[ReducerMethod]
		public static SharedState CompleteGameOver(SharedState state, CompleteGameOverAction _) =>
			new SharedState(SceneType.ElementsMatchGameOver);
	}
}
