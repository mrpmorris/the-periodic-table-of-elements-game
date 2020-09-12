using Fluxor;

namespace ThePeriodicTableOfElementsGame.GamePlay.Navigation
{
	public class Feature : Feature<NavigationState>
	{
		public override string GetName() => "Navigation";
		protected override NavigationState GetInitialState()
			=> new NavigationState(SceneType.MainMenu);
	}
}
