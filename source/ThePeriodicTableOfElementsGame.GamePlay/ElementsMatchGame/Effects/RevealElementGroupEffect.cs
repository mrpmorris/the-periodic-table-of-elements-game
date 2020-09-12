using Fluxor;
using System.Threading;
using System.Threading.Tasks;
using ThePeriodicTableOfElementsGame.GamePlay.ElementsMatchGame.Actions;

namespace ThePeriodicTableOfElementsGame.GamePlay.ElementsMatchGame.Effects
{
	public class RevealElementGroupEffect : Effect<SetExpectedElementAction>
	{
		const int DelayBeforeShowingElementGroupMS = 30_000;
		private Timer Timer;
		private readonly IState<ElementMatchGameState> GameState;

		public RevealElementGroupEffect(IState<ElementMatchGameState> gameState)
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
