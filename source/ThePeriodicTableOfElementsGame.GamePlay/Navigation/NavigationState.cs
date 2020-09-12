namespace ThePeriodicTableOfElementsGame.GamePlay.Navigation
{
	public record NavigationState
	{
		public SceneType Scene { get; init; }

		public bool ShowMainMenu =>
			Scene == SceneType.MainMenu;

		public bool ShowElementsMatchGame =>
			Scene == SceneType.ElementsMatchGame
			|| Scene == SceneType.TransitionFromElementsMatchGameToGameOver;

		public bool ShowGameOver =>
			Scene == SceneType.TransitionFromElementsMatchGameToGameOver
			|| Scene == SceneType.GameOver;

		public NavigationState(SceneType scene)
		{
			Scene = scene;
		}
	}

}
