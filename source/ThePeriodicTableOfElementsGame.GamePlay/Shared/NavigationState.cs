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

		public bool ShowGameOver =>
			Scene == SceneType.TransitionFromElementsMatchGameToGameOver
			|| Scene == SceneType.ElementsMatchGameOver;

		public SharedState(SceneType scene)
		{
			Scene = scene;
		}
	}
}
