﻿using Fluxor;
using ThePeriodicTableOfElementsGame.GamePlay.ElementsMatchGame.Actions;
using ThePeriodicTableOfElementsGame.GamePlay.Shared.Actions;

namespace ThePeriodicTableOfElementsGame.GamePlay.Shared.Reducers
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