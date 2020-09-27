using Fluxor;

namespace ThePeriodicTableOfElementsGame.GamePlay.PeriodicTableFeature
{
	public class Feature : Feature<PeriodicTableState>
	{
		public override string GetName() => "PeriodicTable";
		protected override PeriodicTableState GetInitialState() =>
			PeriodicTableStateExtensions.DefaultState;
	}
}
