using Fluxor;
using System.Buffers;
using System.Collections.ObjectModel;
using System.Linq;
using ThePeriodicTableOfElementsGame.GamePlay.Extensions;

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
	byte[] AvailableElements,
	ReadOnlyDictionary<byte, ElementState> ElementStates)
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
		AvailableElements: Enumerable.Range(1, 118).Select(x => (byte)x).ToArray(),
		ElementStates: Enumerable.Range(1, 118)
			.Select(x => new ElementState(
				AtomicNumber: (byte)x,
				Front: CardState.Default,
				Back: CardState.Default with { ShowName = false },
				Concealed: true))
			.ToDictionary(x => x.AtomicNumber).AsReadOnly()
		)
	{
	}
}
