using Fluxor;
using System;
using System.Threading;
using System.Threading.Tasks;
using ThePeriodicTableOfElementsGame.GamePlay.ElementsMatchGame.Actions;
using ThePeriodicTableOfElementsGame.GamePlay.Navigation.Actions;

namespace ThePeriodicTableOfElementsGame.GamePlay.ElementsMatchGame.Effects
{
	public class RevealElementGroupEffect
	{
		const int DelayBeforeShowingElementGroupMS = 30_000;
		private CancellationTokenSource Cts;
		private readonly IState<ElementsMatchGameState> GameState;

		public RevealElementGroupEffect(IState<ElementsMatchGameState> gameState)
		{
			GameState = gameState;
		}

		[EffectMethod]
		public async Task HandleAsync(SetExpectedElementAction action, IDispatcher dispatcher)
		{
			Cts?.Cancel();
			Cts?.Dispose();
			Cts = new CancellationTokenSource();

			try
			{
				await Task.Delay(DelayBeforeShowingElementGroupMS, Cts.Token);
				if (GameState.Value.ExpectedElement == action.AtomicNumber)
					dispatcher.Dispatch(new RevealElementGroupAction(action.AtomicNumber));
			}
			catch (TaskCanceledException)
			{
			}
		}

		[EffectMethod]
		public Task StartGameOverSequenceAction(StartGameOverSequenceAction action, IDispatcher dispatcher)
		{
			Cts?.Cancel();
			return Task.CompletedTask;
		}

		[EffectMethod]
		public Task NavigateAction(NavigateAction action, IDispatcher dispatcher)
		{
			Cts?.Cancel();
			return Task.CompletedTask;
		}
	}
}
