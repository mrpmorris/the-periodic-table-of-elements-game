using Fluxor;
using System.Threading.Tasks;
using ThePeriodicTableOfElementsGame.GamePlay.ElementsSpeedMatchGame.Actions;
using ThePeriodicTableOfElementsGame.GamePlay.SharedFeature;
using ThePeriodicTableOfElementsGame.GamePlay.SharedFeature.Actions;

namespace ThePeriodicTableOfElementsGame.GamePlay.ElementsSpeedMatchGame.Effects
{
	public static class Effects
	{
		public static Task StartGame(StartGameAction action, IDispatcher dispatcher)
		{
			dispatcher.Dispatch(new NavigateAction(SceneType.ElementSpeedMatchGame));
			return Task.CompletedTask;
		}
	}
}
