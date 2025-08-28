using Fluxor;
using System.Buffers;
using System.Collections.ObjectModel;
using System.Linq;
using ThePeriodicTableOfElementsGame.GamePlay.Extensions;

namespace ThePeriodicTableOfElementsGame.GamePlay.ElementsMatchGame;

[FeatureState]
public record ElementsMatchGameState(
	MatchType MatchType,
	byte? ExpectedElement,
	string ExpectedElementDisplayText,
	bool ShowElementGroup,
	bool HighlighElementsInExpectedGroup,
	int TotalMatched,
	int TotalMismatched,
	byte[] AvailableElements,
	ReadOnlyDictionary<byte, ElementState> ElementStates)
{
	public readonly static ElementsMatchGameState Default = new();

	public ElementsMatchGameState()
		: this(
			MatchType: MatchType.PlaceTheSymbol,
			ExpectedElement: null,
			ExpectedElementDisplayText: null,
			ShowElementGroup: false,
			HighlighElementsInExpectedGroup: false,
			TotalMatched: 0,
			TotalMismatched: 0,
			AvailableElements: Enumerable.Range(1, 118).Select(x => (byte)x).ToArray(),
			ElementStates: Enumerable.Range(1, 118)
				.Select(x => new ElementState(
					atomicNumber: (byte)x,
					front: new CardState(),
					back: new CardState(showName: false),
					concealed: true))
				.ToDictionary(x => x.AtomicNumber).AsReadOnly()
			)
	{
	}
}
