using Fluxor;

namespace ThePeriodicTableOfElementsGame.Store.GameState
{
	public class Feature : Feature<GameState>
	{
		public override string GetName() => "Game";
		protected override GameState GetInitialState() => GameStateExtensions.DefaultState;
	}
}
