using Fluxor;
using System.Collections.Immutable;
using System.Linq;

namespace ThePeriodicTableOfElementsGame.GamePlay.Features.ElementsMatchGame;

[FeatureState]
public record ElementsMatchGameState(
	MatchType MatchType,
	SubSceneType SubSceneType,
	byte? ExpectedElement,
	string ExpectedElementDisplayText,
	bool ShowElementGroup,
	bool HighlighElementsInExpectedGroup,
	int TotalMatched,
	int TotalMismatched,
	ImmutableList<byte> AvailableElements,
	ImmutableDictionary<byte, ElementState> ElementStates)
{
	public static readonly ElementsMatchGameState Default = new();

	public ElementsMatchGameState() : this(
		MatchType: MatchType.PlaceTheSymbol,
		SubSceneType: SubSceneType.Gameplay,
		ExpectedElement: null,
		ExpectedElementDisplayText: null,
		ShowElementGroup: false,
		HighlighElementsInExpectedGroup: false,
		TotalMatched: 0,
		TotalMismatched: 0,
		AvailableElements: Enumerable.Range(1, 118).Select(x => (byte)x).ToImmutableList(),
		ElementStates: Enumerable.Range(1, 118)
			.Select(x => new ElementState(
				AtomicNumber: (byte)x,
				Front: CardState.Default,
				Back: CardState.Default with { ShowName = false },
				Concealed: true))
			.ToImmutableDictionary(x => x.AtomicNumber)
		)
	{
	}
}
