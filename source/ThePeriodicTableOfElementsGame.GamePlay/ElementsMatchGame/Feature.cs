using Fluxor;

namespace ThePeriodicTableOfElementsGame.GamePlay.ElementsMatchGame
{
	public class Feature : Feature<ElementMatchGameState>
	{
		public override string GetName() => "Game";
		protected override ElementMatchGameState GetInitialState() => ElementMatchGameStateExtensions.DefaultState;
	}
}
