using System.Collections.Immutable;
using System.Linq;

namespace ThePeriodicTableOfElementsGame.GamePlay.ElementsMatchGame
{
	public record ElementMatchGameState(
		MatchType MatchType,
		byte? ExpectedElement,
		string ExpectedElementDisplayText,
		bool ShowElementGroup,
		int TotalMatched,
		int TotalMismatched,
		bool IsGameOverSequence,
		bool IsGameOver,
		ImmutableArray<byte> AvailableElements,
		IImmutableDictionary<byte, ElementState> ElementStates);

	public static class ElementMatchGameStateExtensions
	{
		public static readonly ElementMatchGameState DefaultState = new ElementMatchGameState(
			MatchType: MatchType.PlaceTheSymbol,
			ExpectedElement: null,
			ExpectedElementDisplayText: null,
			ShowElementGroup: false,
			TotalMatched: 0,
			TotalMismatched: 0,
			IsGameOverSequence: false,
			IsGameOver: false,
			AvailableElements: Enumerable.Range(1, 118).Select(x => (byte)x).ToImmutableArray(),
			ElementStates: Enumerable.Range(1, 118)
				.Select(x => new ElementState(
					AtomicNumber: (byte)x,
					Front: new CardState(),
					Back: new CardState(ShowName: false),
					Concealed: true))
				.ToImmutableDictionary(x => x.AtomicNumber)
			);
	}
}
