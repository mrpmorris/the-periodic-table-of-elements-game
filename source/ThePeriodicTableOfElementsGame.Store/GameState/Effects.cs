using Fluxor;
using System;
using System.Threading.Tasks;

namespace ThePeriodicTableOfElementsGame.Store.GameState
{
	public class Effects
	{
		private IState<GameState> GameState { get; set; }

		public Effects(IState<GameState> gameState)
		{
			GameState = gameState;
		}

		[EffectMethod]
		public async Task Handle(StoreInitializedAction _, IDispatcher dispatcher)
		{
			await Task.Delay(1000);
			var action = new SetCorrectElementAction(AtomicNumber: GetRandomElementAtomicNumber());
			dispatcher.Dispatch(action);
		}

		private byte GetRandomElementAtomicNumber() =>
			GameState.Value.AvailableElements[new Random().Next(GameState.Value.AvailableElements.Length)];
	}
}
