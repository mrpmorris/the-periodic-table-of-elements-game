namespace ThePeriodicTableOfElementsGame.GamePlay.SharedFeature
{
	public class SharedState
	{
		public readonly SceneType Scene;

		public SharedState(SceneType scene)
		{
			Scene = scene;
		}

		public bool ShowMainMenu =>
			Scene == SceneType.MainMenu;

		public bool ShowElementsMatchGame =>
			Scene == SceneType.ElementsMatchGame
			|| Scene == SceneType.TransitionFromElementsMatchGameToGameOver;

		public bool ShowElementsMatchGameOver =>
			Scene == SceneType.TransitionFromElementsMatchGameToGameOver
			|| Scene == SceneType.ElementsMatchGameOver;

		public bool ShowElementsSpeedMatchGame =>
			Scene == SceneType.ElementSpeedMatchGame;
	}
}
