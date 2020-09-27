using Fluxor;
using System;
using System.Collections.Immutable;
using System.Linq;
using ThePeriodicTableOfElementsGame.GamePlay.ElementsMatchGameFeature.Actions;
using ThePeriodicTableOfElementsGame.GamePlay.PeriodicTableData;

namespace ThePeriodicTableOfElementsGame.GamePlay.ElementsMatchGameFeature.Reducers
{
	public static class Reducers
	{
		[ReducerMethod]
		public static ElementsMatchGameState StartGame(ElementsMatchGameState state, StartGameAction action) =>
			ElementsMatchGameStateExtensions.DefaultState with 
		{ 
			MatchType = action.MatchType,
			ElementStates = ElementsMatchGameStateExtensions.DefaultState.ElementStates.Values
				.Select(x => x with
				{
					Back = x.Back with
					{
						ShowSymbol = state.MatchType == MatchType.PlaceTheName,
						ShowName = state.MatchType == MatchType.PlaceTheSymbol
					}
				})
				.ToImmutableDictionary(x => x.AtomicNumber)
		};

		[ReducerMethod]
		public static ElementsMatchGameState RevealElement(ElementsMatchGameState state, RevealElementAction action) =>
			state with
		{
			ElementStates = state.ElementStates.Values
				.Select(x =>
					x.AtomicNumber != action.AtomicNumber
					? x
					: x with { Concealed = false })
				.ToImmutableDictionary(x => x.AtomicNumber)
		};

		[ReducerMethod]
		public static ElementsMatchGameState ConcealAllElements(ElementsMatchGameState state, ConcealAllElementsAction _) =>
			state with
		{
			ElementStates = state.ElementStates.Values
				.Select(x => x with { Concealed = true })
				.ToImmutableDictionary(x => x.AtomicNumber)
		};

		[ReducerMethod]
		public static ElementsMatchGameState SetExpectedElement(ElementsMatchGameState state, SetExpectedElementAction action) =>
			state with
		{
			ExpectedElement = action.AtomicNumber,
			ExpectedElementDisplayText = state.MatchType switch
			{
				MatchType.PlaceTheName => TableOfElementsData.ElementByNumber[action.AtomicNumber].Name,
				MatchType.PlaceTheSymbol => TableOfElementsData.ElementByNumber[action.AtomicNumber].Symbol,
				_ => throw new NotImplementedException(state.MatchType.ToString())
			},
			ShowElementGroup = false,
			HighlighElementsInExpectedGroup = false,
			AvailableElements = state.AvailableElements.Remove(action.AtomicNumber)
		};

		[ReducerMethod]
		public static ElementsMatchGameState RevealElementGroup(ElementsMatchGameState state, RevealElementGroupAction action) =>
			(state.ExpectedElement != action.AtomicNumber)
			? state
			: state with { ShowElementGroup = true, HighlighElementsInExpectedGroup = true };

		[ReducerMethod]
		public static ElementsMatchGameState ElementMatched(ElementsMatchGameState state, ElementMatchedAction _) =>
			state with
		{
			TotalMatched = state.TotalMatched + 1,
			HighlighElementsInExpectedGroup = false
		};

		[ReducerMethod]
		public static ElementsMatchGameState ElementMismatched(ElementsMatchGameState state, ElementMismatchedAction _) =>
			state with
		{
			TotalMismatched = state.TotalMismatched + 1
		};
	}
}
