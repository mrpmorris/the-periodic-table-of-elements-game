using System.Collections.Immutable;
using System.Linq;
using ThePeriodicTableOfElementsGame.GamePlay.Extensions;

namespace ThePeriodicTableOfElementsGame.GamePlay.ElementsMatchGame
{
	public class ElementsMatchGameState
	{
		public readonly MatchType MatchType;
		public readonly byte? ExpectedElement;
		public readonly string ExpectedElementDisplayText;
		public readonly bool ShowElementGroup;
		public readonly bool HighlightElementsInExpectedGroup;
		public readonly int TotalMatched;
		public readonly int TotalMismatched;
		public readonly ImmutableHashSet<byte> AvailableElements;
		public readonly ImmutableDictionary<byte, ElementState> ElementStates;

		public ElementsMatchGameState(
			MatchType matchType,
			byte? expectedElement,
			string expectedElementDisplayText,
			bool showElementGroup,
			bool highlightElementsInExpectedGroup,
			int totalMatched,
			int totalMismatched,
			ImmutableHashSet<byte> availableElements,
			ImmutableDictionary<byte, ElementState> elementStates)
		{
			MatchType = matchType;
			ExpectedElement = expectedElement;
			ExpectedElementDisplayText = expectedElementDisplayText;
			ShowElementGroup = showElementGroup;
			HighlightElementsInExpectedGroup = highlightElementsInExpectedGroup;
			TotalMatched = totalMatched;
			TotalMismatched = totalMismatched;
			AvailableElements = availableElements;
			ElementStates = elementStates;
		}

		public ElementsMatchGameState With(
			PropertyUpdate<MatchType> matchType = null,
			PropertyUpdate<byte?> expectedElement = null,
			PropertyUpdate<string> expectedElementDisplayText = null,
			PropertyUpdate<bool> showElementGroup = null,
			PropertyUpdate<bool> highlightElementsInExpectedGroup = null,
			PropertyUpdate<int> totalMatched = null,
			PropertyUpdate<int> totalMismatched = null,
			PropertyUpdate<ImmutableHashSet<byte>> availableElements = null,
			PropertyUpdate<ImmutableDictionary<byte, ElementState>> elementStates = null)
			=>
				new ElementsMatchGameState(
					matchType: matchType.GetUpdatedValue(MatchType),
					expectedElement: expectedElement.GetUpdatedValue(ExpectedElement),
					expectedElementDisplayText: expectedElementDisplayText.GetUpdatedValue(ExpectedElementDisplayText),
					showElementGroup: showElementGroup.GetUpdatedValue(ShowElementGroup),
					highlightElementsInExpectedGroup: highlightElementsInExpectedGroup.GetUpdatedValue(HighlightElementsInExpectedGroup),
					totalMatched: totalMatched.GetUpdatedValue(TotalMatched),
					totalMismatched: totalMismatched.GetUpdatedValue(TotalMismatched),
					availableElements: availableElements.GetUpdatedValue(AvailableElements),
					elementStates: elementStates.GetUpdatedValue(ElementStates));
	}

	public static class ElementsMatchGameStateExtensions
	{
		public static readonly ElementsMatchGameState DefaultState = new ElementsMatchGameState(
			matchType: MatchType.PlaceTheSymbol,
			expectedElement: null,
			expectedElementDisplayText: null,
			showElementGroup: false,
			highlightElementsInExpectedGroup: false,
			totalMatched: 0,
			totalMismatched: 0,
			availableElements: ImmutableHashSet.CreateRange(Enumerable.Range(1, 118).Select(x => (byte)x)),
			elementStates: Enumerable.Range(1, 118)
				.Select(x => new ElementState(
					atomicNumber: (byte)x,
					front: new CardState(),
					back: new CardState(showName: false),
					concealed: true))
				.ToImmutableDictionary(x => x.AtomicNumber)
			);
	}
}
