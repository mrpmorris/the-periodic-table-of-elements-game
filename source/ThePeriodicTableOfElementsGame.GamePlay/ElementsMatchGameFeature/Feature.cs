using Fluxor;

namespace ThePeriodicTableOfElementsGame.GamePlay.ElementsMatchGameFeature
{
	public class Feature : Feature<ElementsMatchGameState>
	{
		public override string GetName() => "ElementsMatchGame";
		protected override ElementsMatchGameState GetInitialState() => ElementsMatchGameStateExtensions.DefaultState;
	}
}
