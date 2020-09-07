using Fluxor;
using System.Threading;
using System.Threading.Tasks;

namespace ThePeriodicTableOfElementsGame.Store.GameState
{
	public class RevealElementGroupEffect : Effect<SetExpectedElementAction>
	{
		const int DelayBeforeShowingElementGroupMS = 30_000;
		private Timer Timer;
		private readonly IState<GameState> GameState;

		public RevealElementGroupEffect(IState<GameState> gameState)
		{
			GameState = gameState;
		}

		protected override Task HandleAsync(SetExpectedElementAction action, IDispatcher dispatcher)
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


	}
}
