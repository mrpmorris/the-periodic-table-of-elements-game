using System.Collections.Immutable;
using System.Linq;

namespace ThePeriodicTableOfElementsGame.GamePlay.ElementsMatchGame
{
	public record ElementsMatchGameState(
		MatchType MatchType,
		byte? ExpectedElement,
		string ExpectedElementDisplayText,
		bool ShowElementGroup,
		bool HighlighElementsInExpectedGroup,
		int TotalMatched,
		int TotalMismatched,
		ImmutableArray<byte> AvailableElements,
		IImmutableDictionary<byte, ElementState> ElementStates);

	public static class ElementsMatchGameStateExtensions
	{
		public static readonly ElementsMatchGameState DefaultState = new ElementsMatchGameState(
			MatchType: MatchType.PlaceTheSymbol,
			ExpectedElement: null,
			ExpectedElementDisplayText: null,
			ShowElementGroup: false,
			HighlighElementsInExpectedGroup: false,
			TotalMatched: 0,
			TotalMismatched: 0,
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
