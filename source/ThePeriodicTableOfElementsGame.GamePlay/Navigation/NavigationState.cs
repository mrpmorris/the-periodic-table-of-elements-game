namespace ThePeriodicTableOfElementsGame.GamePlay.Navigation
{
	public class NavigationState
	{
		public readonly SceneType Scene;

		public NavigationState(SceneType scene)
		{
			Scene = scene;
		}

		public bool ShowMainMenu =>
			Scene == SceneType.MainMenu;

		public bool ShowElementsMatchGame =>
			Scene == SceneType.ElementsMatchGame
			|| Scene == SceneType.TransitionFromElementsMatchGameToGameOver;

		public bool ShowGameOver =>
			Scene == SceneType.TransitionFromElementsMatchGameToGameOver
			|| Scene == SceneType.ElementsMatchGameOver;
	}
}
