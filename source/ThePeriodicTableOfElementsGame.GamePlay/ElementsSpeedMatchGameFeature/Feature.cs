using Fluxor;

namespace ThePeriodicTableOfElementsGame.GamePlay.ElementsSpeedMatchGameFeature
{
	public class Feature : Feature<ElementsSpeedMatchGameState>
	{
		public override string GetName() => "ElementsSpeedMatchGame";
		protected override ElementsSpeedMatchGameState GetInitialState() =>
			ElementsSpeedMatchGameStateExtensions.DefaultState;
	}
}
