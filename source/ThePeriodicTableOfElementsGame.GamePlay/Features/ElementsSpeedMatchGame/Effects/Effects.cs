using Fluxor;
using System.Threading.Tasks;
using ThePeriodicTableOfElementsGame.GamePlay.Features.ElementsSpeedMatchGame.Actions;

namespace ThePeriodicTableOfElementsGame.GamePlay.Features.ElementsSpeedMatchGame.Effects
{
	public static class Effects
	{
		[EffectMethod]
		public static async Task TimingEvent(TimingEventAction action, IDispatcher dispatcher)
		{
			await Task.Delay(Consts.LeadInTimeMs - 25);
			var actionToDispatch =
				ElementsSpeedMatchGameState.Default.ElementTimings[action.EventTimeMs];
			dispatcher.Dispatch(actionToDispatch);
		}
	}
}
