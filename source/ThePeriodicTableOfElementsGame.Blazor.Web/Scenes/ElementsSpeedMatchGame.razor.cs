using Fluxor;
using Microsoft.AspNetCore.Components;
using ThePeriodicTableOfElementsGame.GamePlay.ElementsSpeedMatchGameFeature;
using ThePeriodicTableOfElementsGame.GamePlay.ElementsSpeedMatchGameFeature.Actions;
using ThePeriodicTableOfElementsGame.GamePlay.Services;
using ThePeriodicTableOfElementsGame.GamePlay.SharedFeature;
using ThePeriodicTableOfElementsGame.GamePlay.SharedFeature.Actions;

namespace ThePeriodicTableOfElementsGame.Blazor.Web.Scenes
{
	public partial class ElementsSpeedMatchGame
	{
		[Inject]
		private IState<ElementsSpeedMatchGameState> GameState { get; set; }

		[Inject]
		private IDispatcher Dispatcher { get; set; }

		[Inject]
		private IAudioPlayer AudioPlayer { get; set; }

		private void GoToMainMenu()
		{
			Dispatcher.Dispatch(new NavigateAction(SceneType.MainMenu));
		}
	}
}
