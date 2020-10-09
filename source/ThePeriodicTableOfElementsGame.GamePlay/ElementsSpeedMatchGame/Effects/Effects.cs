using Fluxor;
using System.Threading.Tasks;
using ThePeriodicTableOfElementsGame.GamePlay.ElementsSpeedMatchGameFeature.Actions;
using ThePeriodicTableOfElementsGame.GamePlay.SharedFeature;
using ThePeriodicTableOfElementsGame.GamePlay.SharedFeature.Actions;

namespace ThePeriodicTableOfElementsGame.GamePlay.ElementsSpeedMatchGameFeature.Effects
{
	public static class Effects
	{
		[EffectMethod]
		public static Task StartGame(StartGameAction action, IDispatcher dispatcher)
		{
			dispatcher.Dispatch(new NavigateAction(SceneType.ElementSpeedMatchGame));
			return Task.CompletedTask;
		}
	}
}
