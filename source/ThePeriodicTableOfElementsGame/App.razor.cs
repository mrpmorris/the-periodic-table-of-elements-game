using Fluxor;
using Microsoft.AspNetCore.Components;
using System;
using ThePeriodicTableOfElementsGame.Store.GameState;

namespace ThePeriodicTableOfElementsGame
{
	public partial class App
	{
		[Inject]
		private IState<GameState> GameState { get; set; }

		private readonly Scene CurrentScene = Scene.MainMenu;

		private string GetSceneCss() =>
			CurrentScene switch
			{
				Scene.MainMenu => "--main-menu",
				Scene.GamePlay => "--game-play",
				_ => throw new NotImplementedException(CurrentScene.ToString())
			};
	}
}
