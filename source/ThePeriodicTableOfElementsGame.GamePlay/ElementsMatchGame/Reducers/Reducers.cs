using Fluxor;
using System;
using System.Collections.Immutable;
using System.Linq;
using ThePeriodicTableOfElementsGame.GamePlay.ElementsMatchGame.Actions;
using ThePeriodicTableOfElementsGame.GamePlay.Extensions;
using ThePeriodicTableOfElementsGame.GamePlay.PeriodicTableData;

namespace ThePeriodicTableOfElementsGame.GamePlay.ElementsMatchGame.Reducers
{
	public static class Reducers
	{
		[ReducerMethod]
		public static ElementsMatchGameState SelectGameAction(ElementsMatchGameState state, SelectGameAction action) =>
			ElementsMatchGameStateExtensions.DefaultState.With(matchType: action.MatchType);

		[ReducerMethod(typeof(StartGameAction))]
		public static ElementsMatchGameState StartGameAction(ElementsMatchGameState state) =>
			ElementsMatchGameStateExtensions.DefaultState.With
			(
				matchType: state.MatchType,
				elementStates: ElementsMatchGameStateExtensions.DefaultState.ElementStates.Values
					.Select(x => x.With
					(
						back: x.Back.With
						(
							showName: state.MatchType != MatchType.PlaceTheName,
							showSymbol: state.MatchType != MatchType.PlaceTheSymbol
						)
					))
					.ToImmutableDictionary(x => x.AtomicNumber)
			);

		[ReducerMethod]
		public static ElementsMatchGameState RevealElementAction(ElementsMatchGameState state, RevealElementAction action) =>
			state.With
			(
				elementStates: state.ElementStates.Values
					.Select(x =>
						x.AtomicNumber != action.AtomicNumber
						? x
						: x.With(concealed: false))
					.ToImmutableDictionary(x => x.AtomicNumber)
			);

		[ReducerMethod(typeof(ConcealAllElementsAction))]
		public static ElementsMatchGameState ConcealAllElementsAction(ElementsMatchGameState state) =>
			state.With
			(
				elementStates: state.ElementStates.Values
					.Select(x => x.With(concealed: true))
					.ToImmutableDictionary(x => x.AtomicNumber)
			);

		[ReducerMethod]
		public static ElementsMatchGameState SetExpectedElementAction(ElementsMatchGameState state, SetExpectedElementAction action)
		{
			var newAvailable = state.AvailableElements.Remove(action.AtomicNumber);
			return state.With
			(
				expectedElement: action.AtomicNumber,
				expectedElementDisplayText: state.MatchType switch
				{
					MatchType.PlaceTheName => TableOfElementsData.ElementByNumber[action.AtomicNumber].Name,
					MatchType.PlaceTheSymbol => TableOfElementsData.ElementByNumber[action.AtomicNumber].Symbol,
					_ => throw new NotImplementedException(state.MatchType.ToString())
				},
				showElementGroup: false,
				highlightElementsInExpectedGroup: false,
				availableElements: newAvailable
			);
		}

		[ReducerMethod]
		public static ElementsMatchGameState RevealElementGroupAction(ElementsMatchGameState state, RevealElementGroupAction action) =>
			state.ExpectedElement != action.AtomicNumber
			? state
			: state.With(
					showElementGroup: true,
					highlightElementsInExpectedGroup: true);

		[ReducerMethod(typeof(ElementMatchedAction))]
		public static ElementsMatchGameState ElementMatchedAction(ElementsMatchGameState state) =>
			state.With
			(
				totalMatched: state.TotalMatched + 1,
				highlightElementsInExpectedGroup: false
			);

		[ReducerMethod(typeof(ElementMismatchedAction))]
		public static ElementsMatchGameState ElementMismatchedAction(ElementsMatchGameState state) =>
			state.With
			(
				totalMismatched: state.TotalMismatched + 1
			);
	}
}
