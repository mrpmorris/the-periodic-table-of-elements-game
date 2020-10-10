using System;
using System.Buffers;
using System.Collections.ObjectModel;
using System.Linq;
using ThePeriodicTableOfElementsGame.GamePlay.ElementsMatchGameFeature;
using ThePeriodicTableOfElementsGame.GamePlay.Extensions;
using ThePeriodicTableOfElementsGame.GamePlay.PeriodicTableFeature;

namespace ThePeriodicTableOfElementsGame.GamePlay.ElementsMatchGameFeature
{
	public class ElementsMatchGameState
	{
		public readonly MatchType MatchType;
		public readonly byte? ExpectedElement;
		public readonly string ExpectedElementDisplayText;
		public readonly bool ShowElementGroup;
		public readonly bool HighlighElementsInExpectedGroup;
		public readonly int TotalMatched;
		public readonly int TotalMismatched;
		public readonly byte[] AvailableElements;
		public readonly ReadOnlyDictionary<byte, ElementState> ElementStates;

		public ElementsMatchGameState(
			MatchType matchType,
			byte? expectedElement,
			string expectedElementDisplayText,
			bool showElementGroup,
			bool highlighElementsInExpectedGroup,
			int totalMatched,
			int totalMismatched,
			byte[] availableElements,
			ReadOnlyDictionary<byte, ElementState> elementStates)
		{
			MatchType = matchType;
			ExpectedElement = expectedElement;
			ExpectedElementDisplayText = expectedElementDisplayText;
			ShowElementGroup = showElementGroup;
			HighlighElementsInExpectedGroup = highlighElementsInExpectedGroup;
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
			PropertyUpdate<bool> highlighElementsInExpectedGroup = null,
			PropertyUpdate<int> totalMatched = null,
			PropertyUpdate<int> totalMismatched = null,
			PropertyUpdate<byte[]> availableElements = null,
			PropertyUpdate<ReadOnlyDictionary<byte, ElementState>> elementStates = null)
			=>
				new ElementsMatchGameState(
					matchType: matchType.GetUpdatedValue(MatchType),
					expectedElement: expectedElement.GetUpdatedValue(ExpectedElement),
					expectedElementDisplayText: expectedElementDisplayText.GetUpdatedValue(ExpectedElementDisplayText),
					showElementGroup: showElementGroup.GetUpdatedValue(ShowElementGroup),
					highlighElementsInExpectedGroup: highlighElementsInExpectedGroup.GetUpdatedValue(HighlighElementsInExpectedGroup),
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
			highlighElementsInExpectedGroup: false,
			totalMatched: 0,
			totalMismatched: 0,
			availableElements: Enumerable.Range(1, 118).Select(x => (byte)x).ToArray(),
			elementStates: Enumerable.Range(1, 118)
				.Select(x => new ElementState(
					atomicNumber: (byte)x,
					front: new CardState(),
					back: new CardState(showName: false),
					concealed: true))
				.ToDictionary(x => x.AtomicNumber).AsReadOnly()
			);
	}
}
