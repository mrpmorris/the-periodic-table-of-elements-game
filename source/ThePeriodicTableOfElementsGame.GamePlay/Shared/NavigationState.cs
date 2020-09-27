namespace ThePeriodicTableOfElementsGame.GamePlay.Shared
{
	public record SharedState
	{
		public SceneType Scene { get; init; }

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

		public SharedState(SceneType scene)
		{
			Scene = scene;
		}
	}
}
