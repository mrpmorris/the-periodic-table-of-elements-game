using Fluxor;
using ThePeriodicTableOfElementsGame.GamePlay.ElementsMatchGameFeature.Actions;
using ThePeriodicTableOfElementsGame.GamePlay.SharedFeature.Actions;

namespace ThePeriodicTableOfElementsGame.GamePlay.SharedFeature.Reducers
{
	public static class Reducers
	{
		[ReducerMethod]
		public static SharedState Reduce(SharedState state, NavigateAction action) =>
			state with { Scene = action.Scene };

		[ReducerMethod]
		public static SharedState Reduce(SharedState state, StartGameOverSequenceAction _) =>
			new SharedState(SceneType.TransitionFromElementsMatchGameToGameOver);

		[ReducerMethod]
		public static SharedState Reduce(SharedState state, CompleteGameOverAction _) =>
			new SharedState(SceneType.ElementsMatchGameOver);
	}
}
