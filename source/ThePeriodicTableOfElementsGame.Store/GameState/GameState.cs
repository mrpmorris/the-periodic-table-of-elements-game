using System.Collections.Generic;
using System.Collections.Immutable;
using System.Linq;

namespace ThePeriodicTableOfElementsGame.Store.GameState
{
	public record GameState(
		byte? ExpectedElement,
		ImmutableArray<byte> AvailableElements,
		IEnumerable<ElementState> ElementStates);

	public static class GameStateExtensions
	{
		public static readonly GameState DefaultState = new GameState(
			ExpectedElement: null,
			AvailableElements: Enumerable.Range(1, 118).Select(x => (byte)x).ToImmutableArray(),
			ElementStates: Enumerable.Range(1, 118)
				.Select(x => new ElementState(
					AtomicNumber: (byte)x,
					Front: new CardState(),
					Back: new CardState(ShowName: false),
					Concealed: true))
			);
	}
}
