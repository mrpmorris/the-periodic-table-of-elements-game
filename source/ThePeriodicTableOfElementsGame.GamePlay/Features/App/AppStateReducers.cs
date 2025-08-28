using Fluxor;

namespace ThePeriodicTableOfElementsGame.GamePlay.Features.App;

public static class AppStateReducers
{
	[ReducerMethod]
	public static AppState ReduceChangeSceneAction(AppState state, ChangeSceneAction action) =>
		state with { ActiveScene = action.NewScene };
}
