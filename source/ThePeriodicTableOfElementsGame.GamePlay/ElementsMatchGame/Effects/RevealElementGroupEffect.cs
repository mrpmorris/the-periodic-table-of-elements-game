using Fluxor;
using System.Threading;
using System.Threading.Tasks;
using ThePeriodicTableOfElementsGame.GamePlay.ElementsMatchGame.Actions;
using ThePeriodicTableOfElementsGame.GamePlay.Navigation.Actions;

namespace ThePeriodicTableOfElementsGame.GamePlay.ElementsMatchGame.Effects
{
	public class RevealElementGroupEffect
	{
		const int DelayBeforeShowingElementGroupMS = 30_000;
		private Timer Timer;
		private readonly IState<ElementsMatchGameState> GameState;

		public RevealElementGroupEffect(IState<ElementsMatchGameState> gameState)
		{
			GameState = gameState;
		}

		[EffectMethod]
		public Task HandleAsync(SetExpectedElementAction action, IDispatcher dispatcher)
		{
			Timer?.Dispose();
			Timer = new Timer(
				callback: _ =>
				{
					if (GameState.Value.ExpectedElement == action.AtomicNumber)
						dispatcher.Dispatch(new RevealElementGroupAction(action.AtomicNumber));
				},
				state: null,
				dueTime: DelayBeforeShowingElementGroupMS,
				period: 0);
			return Task.CompletedTask;
		}

		[EffectMethod]
		public Task StartGameOverSequenceAction(StartGameOverSequenceAction action, IDispatcher dispatcher)
		{
			Timer?.Dispose();
			return Task.CompletedTask;
		}

		[EffectMethod]
		public Task NavigateAction(NavigateAction action, IDispatcher dispatcher)
		{
			Timer?.Dispose();
			return Task.CompletedTask;
		}
	}
}
