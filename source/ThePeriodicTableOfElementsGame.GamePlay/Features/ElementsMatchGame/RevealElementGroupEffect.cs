using Fluxor;
using System.Threading;
using System.Threading.Tasks;
using ThePeriodicTableOfElementsGame.GamePlay.Features.ElementsMatchGame.Actions;

namespace ThePeriodicTableOfElementsGame.GamePlay.Features.ElementsMatchGame;

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
	public Task SetSubSceneAction(SetSubSceneAction action, IDispatcher dispatcher)
	{
		if (action.NewSubSceneType != SubSceneType.Gameplay)
			Timer?.Dispose();
		return Task.CompletedTask;
	}

	[EffectMethod]
	public Task ChangeSceneAction(Features.App.Actions.ChangeSceneAction action, IDispatcher dispatcher)
	{
		Timer?.Dispose();
		return Task.CompletedTask;
	}
}
