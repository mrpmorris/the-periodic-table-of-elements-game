using System.Collections.Generic;
using System.Collections.Immutable;
using System.Linq;
using ThePeriodicTableOfElementsGame.GamePlay.PeriodicTableFeature;

namespace ThePeriodicTableOfElementsGame.GamePlay.ElementsSpeedMatchGame
{
	public record ElementsSpeedMatchGameState(
		IEnumerable<ElementState> ElementStates
		);

	public static class ElementsSpeedMatchGameStateExtensions
	{
		public static readonly ElementsSpeedMatchGameState DefaultState =
			new ElementsSpeedMatchGameState(
				ElementStates: Enumerable.Range(1, 118)
				.Select(x => new ElementState(
					AtomicNumber: (byte)x,
					Front: new CardState(),
					Back: new CardState(),
					Concealed: false))
				.ToImmutableList()
			);
	}
}
