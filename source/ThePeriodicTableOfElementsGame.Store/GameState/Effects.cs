using Fluxor;
using System;
using System.Threading.Tasks;
using ThePeriodicTableOfElementsGame.Store.Services;

namespace ThePeriodicTableOfElementsGame.Store.GameState
{
	public class Effects
	{
		private IState<GameState> GameState;
		private IAudioPlayer AudioPlayer;

		public Effects(IState<GameState> gameState, IAudioPlayer audioPlayer)
		{
			GameState = gameState ?? throw new ArgumentNullException(nameof(gameState));
			AudioPlayer = audioPlayer ?? throw new ArgumentNullException(nameof(audioPlayer));
		}

		[EffectMethod]
		public async Task Handle(StoreInitializedAction _, IDispatcher dispatcher)
		{
			await Task.Delay(1000);
			dispatcher.Dispatch(new SetCorrectElementAction(AtomicNumber: GetRandomElementAtomicNumber()));
		}

		[EffectMethod]
		public Task Handle(ClickElementAction action, IDispatcher dispatcher)
		{
			byte? correctElement = GameState.Value.CorrectElement;

			if (correctElement.HasValue && correctElement == action.AtomicNumber)
				dispatcher.Dispatch(new ElementMatchedAction(AtomicNumber: action.AtomicNumber));
			else
				dispatcher.Dispatch(new ElementMismatchedAction(
					ClickedAtomicNumber: action.AtomicNumber,
					CorrectAtomicNumber: GameState.Value.CorrectElement));

			return Task.CompletedTask;
		}

		[EffectMethod]
		public Task Handle(ElementMismatchedAction _, IDispatcher dispatcher)
		{
			AudioPlayer.PlayOneShotAsync(AudioSample.ElementMismatched);
			return Task.CompletedTask;
		}

		[EffectMethod]
		public Task Handle(ElementMatchedAction _, IDispatcher dispatcher)
		{
			AudioPlayer.PlayOneShotAsync(AudioSample.ElementFastMatched1);
			return Task.CompletedTask;
		}

		[EffectMethod]
		public Task Handle(SetCorrectElementAction _, IDispatcher dispatcher) =>
			AudioPlayer.PlayOneShotAsync(AudioSample.ElementAppeared);

		private byte GetRandomElementAtomicNumber() =>
			GameState.Value.AvailableElements[new Random().Next(GameState.Value.AvailableElements.Length)];
	}
}
