﻿using Fluxor;
using Microsoft.AspNetCore.Components;
using ThePeriodicTableOfElementsGame.GamePlay.Shared;
using ThePeriodicTableOfElementsGame.GamePlay.Shared.Actions;

namespace ThePeriodicTableOfElementsGame.Blazor.Web.Scenes
{
	public partial class ElementsSpeedMatchGame
	{
		[Inject]
		private IDispatcher Dispatcher { get; set; }

		private void GoToMainMenu()
		{
			Dispatcher.Dispatch(new NavigateAction(SceneType.MainMenu));
		}

	}
}
