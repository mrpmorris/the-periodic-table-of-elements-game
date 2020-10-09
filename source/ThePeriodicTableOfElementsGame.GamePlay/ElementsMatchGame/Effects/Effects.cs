using Fluxor;
using System;
using System.Linq;
using System.Threading.Tasks;
using ThePeriodicTableOfElementsGame.GamePlay.ElementsMatchGame.Actions;
using ThePeriodicTableOfElementsGame.GamePlay.Services;

namespace ThePeriodicTableOfElementsGame.GamePlay.ElementsMatchGame.Effects
{
	public class Effects
	{
		private readonly IState<ElementsMatchGameState> GameState;
		private readonly IAudioPlayer AudioPlayer;

		public Effects(IState<ElementsMatchGameState> gameState, IAudioPlayer audioPlayer)
		{
			GameState = gameState ?? throw new ArgumentNullException(nameof(gameState));
			AudioPlayer = audioPlayer ?? throw new ArgumentNullException(nameof(audioPlayer));
		}

		[EffectMethod]
		public async Task StartGameAction(StartGameAction _, IDispatcher dispatcher)
		{
			await Task.Delay(500);
			dispatcher.Dispatch(new SetExpectedElementAction(atomicNumber: GetRandomElementAtomicNumber()));
		}

		[EffectMethod]
		public Task ClickElementAction(ClickElementAction action, IDispatcher dispatcher)
		{
			if (!GameState.Value.ElementStates[action.AtomicNumber].Concealed)
				return Task.CompletedTask;

			byte? expectedElement = GameState.Value.ExpectedElement;

			dispatcher.Dispatch(new RevealElementAction(action.AtomicNumber));

			if (expectedElement.HasValue && expectedElement == action.AtomicNumber)
				dispatcher.Dispatch(new ElementMatchedAction(atomicNumber: action.AtomicNumber));
			else
				dispatcher.Dispatch(new ElementMismatchedAction(
					clickedAtomicNumber: action.AtomicNumber,
					expectedAtomicNumber: GameState.Value.ExpectedElement));

			return Task.CompletedTask;
		}

		[EffectMethod]
		public Task ElementMismatchedAction(ElementMismatchedAction _, IDispatcher dispatcher)
		{
			return AudioPlayer.PlayOneShotAsync(AudioSample.ElementMismatched);
		}

		[EffectMethod]
		public async Task ElementMatchedAction(ElementMatchedAction _, IDispatcher dispatcher)
		{
			await AudioPlayer.PlayOneShotAsync(AudioSample.ElementFastMatched1);
			await Task.Delay(1000);
			dispatcher.Dispatch(new ConcealAllElementsAction());
			await Task.Delay(500);
			if (GameState.Value.AvailableElements.Any())
				dispatcher.Dispatch(new SetExpectedElementAction(atomicNumber: GetRandomElementAtomicNumber()));
			else
				dispatcher.Dispatch(new StartGameOverSequenceAction());
		}

		[EffectMethod]
		public Task SetExpectedElementAction(SetExpectedElementAction _, IDispatcher dispatcher) =>
			AudioPlayer.PlayOneShotAsync(AudioSample.ElementAppeared);

		[EffectMethod]
		public async Task StartGameOverSequenceAction(StartGameOverSequenceAction _, IDispatcher dispatcher)
		{
			await Task.Delay(2050);
			dispatcher.Dispatch(new CompleteGameOverAction());
		}

		private byte GetRandomElementAtomicNumber() =>
			GameState.Value.AvailableElements[new Random().Next(GameState.Value.AvailableElements.Length)];
	}
}
