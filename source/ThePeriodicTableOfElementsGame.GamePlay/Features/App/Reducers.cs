using Fluxor;
using ThePeriodicTableOfElementsGame.GamePlay.Features.App.Actions;

namespace ThePeriodicTableOfElementsGame.GamePlay.Features.App;

public static class Reducers
{
	[ReducerMethod]
	public static AppState ReduceChangeSceneAction(AppState state, ChangeSceneAction action) =>
		state with { ActiveScene = action.NewScene };
}
