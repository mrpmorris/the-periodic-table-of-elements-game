using Fluxor;

namespace ThePeriodicTableOfElementsGame.GamePlay.Shared
{
	public class Feature : Feature<SharedState>
	{
		public override string GetName() => "Shared";
		protected override SharedState GetInitialState()
			=> new SharedState(SceneType.MainMenu);
	}
}
