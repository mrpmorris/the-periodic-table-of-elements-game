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
			await Task.Delay(100);
			dispatcher.Dispatch(new SetCorrectElementAction(AtomicNumber: GetRandomElementAtomicNumber()));
			await Task.Delay(2000);
			dispatcher.Dispatch(new SetCorrectElementAction(AtomicNumber: GetRandomElementAtomicNumber()));
			await Task.Delay(2000);
			dispatcher.Dispatch(new SetCorrectElementAction(AtomicNumber: GetRandomElementAtomicNumber()));
		}

		[EffectMethod]
		public Task Handle(ClickElementAction _, IDispatcher dispatcher)
		{
			AudioPlayer.PlayOneShot(AudioSample.ElementFastMatched1);
			return Task.CompletedTask;
		}

		[EffectMethod]
		public Task Handle(SetCorrectElementAction _, IDispatcher dispatcher)
		{
			AudioPlayer.PlayOneShot(AudioSample.ElementAppeared);
			return Task.CompletedTask;
		}

		private byte GetRandomElementAtomicNumber() =>
			GameState.Value.AvailableElements[new Random().Next(GameState.Value.AvailableElements.Length)];
	}
}
