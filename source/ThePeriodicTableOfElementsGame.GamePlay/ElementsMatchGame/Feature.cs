using Fluxor;

namespace ThePeriodicTableOfElementsGame.GamePlay.ElementsMatchGame
{
	public class Feature : Feature<ElementsMatchGameState>
	{
		public override string GetName() => "Game";
		protected override ElementsMatchGameState GetInitialState() => ElementsMatchGameStateExtensions.DefaultState;
	}
}
