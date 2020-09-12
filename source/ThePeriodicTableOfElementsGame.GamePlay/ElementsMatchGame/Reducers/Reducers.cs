using Fluxor;
using System;
using System.Collections.Immutable;
using System.Linq;
using ThePeriodicTableOfElementsGame.GamePlay.ElementsMatchGame.Actions;
using ThePeriodicTableOfElementsGame.GamePlay.PeriodicTableData;

namespace ThePeriodicTableOfElementsGame.GamePlay.ElementsMatchGame.Reducers
{
	public static class Reducers
	{
		[ReducerMethod]
		public static ElementsMatchGameState Reduce(ElementsMatchGameState state, SelectGameAction action) =>
			ElementsMatchGameStateExtensions.DefaultState with { MatchType = action.MatchType };

		[ReducerMethod]
		public static ElementsMatchGameState Reduce(ElementsMatchGameState state, StartGameAction _) =>
		ElementsMatchGameStateExtensions.DefaultState with
		{
			MatchType = state.MatchType,
			ElementStates = ElementsMatchGameStateExtensions.DefaultState.ElementStates.Values
				.Select(x => x with
				{
					Back = x.Back with
					{
						ShowName = state.MatchType != MatchType.PlaceTheName,
						ShowSymbol = state.MatchType != MatchType.PlaceTheSymbol
					}
				})
				.ToImmutableDictionary(x => x.AtomicNumber)
		};

		[ReducerMethod]
		public static ElementsMatchGameState Reduce(ElementsMatchGameState state, RevealElementAction action) =>
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
		public static ElementsMatchGameState Reduce(ElementsMatchGameState state, ConcealAllElementsAction _) =>
			state with
		{
			ElementStates = state.ElementStates.Values
				.Select(x => x with { Concealed = true })
				.ToImmutableDictionary(x => x.AtomicNumber)
		};

		[ReducerMethod]
		public static ElementsMatchGameState Reduce(ElementsMatchGameState state, SetExpectedElementAction action) =>
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
			AvailableElements = state.AvailableElements.Remove(action.AtomicNumber)
		};

		[ReducerMethod]
		public static ElementsMatchGameState Reduce(ElementsMatchGameState state, RevealElementGroupAction action) =>
			(state.ExpectedElement != action.AtomicNumber)
			? state
			: state with { ShowElementGroup = true };

		[ReducerMethod]
		public static ElementsMatchGameState Reduce(ElementsMatchGameState state, ElementMatchedAction _) =>
			state with
		{
			TotalMatched = state.TotalMatched + 1
		};

		[ReducerMethod]
		public static ElementsMatchGameState Reduce(ElementsMatchGameState state, ElementMismatchedAction _) =>
			state with
		{
			TotalMismatched = state.TotalMismatched + 1
		};
	}
}
