using Fluxor;
using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Components.Rendering;
using System;
using ThePeriodicTableOfElementsGame.Store.GameState;

namespace ThePeriodicTableOfElementsGame
{
	public partial class App
	{
		private readonly Scene CurrentScene = Scene.MainMenu;

		[Inject]
		private IState<GameState> GameState { get; set; }

		private string GetSceneCss() =>
			CurrentScene switch
			{
				Scene.MainMenu => "--main-menu",
				Scene.GamePlay => "--game-play",
				Scene.Score => "--show-score",
				_ => throw new NotImplementedException(CurrentScene.ToString())
			};
	}
}
