using Fluxor;
using System;
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

		[ReducerMethod]
		public static ElementsMatchGameState StartGameAction(ElementsMatchGameState state, StartGameAction _) =>
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
					.ToDictionary(x => x.AtomicNumber).AsReadOnly()
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
					.ToDictionary(x => x.AtomicNumber).AsReadOnly()
			);

		[ReducerMethod]
		public static ElementsMatchGameState ConcealAllElementsAction(ElementsMatchGameState state, ConcealAllElementsAction _) =>
			state.With
			(
				elementStates: state.ElementStates.Values
					.Select(x => x.With(concealed: true))
					.ToDictionary(x => x.AtomicNumber).AsReadOnly()
			);

		[ReducerMethod]
		public static ElementsMatchGameState SetExpectedElementAction(ElementsMatchGameState state, SetExpectedElementAction action) =>
			state.With
			(
				expectedElement: action.AtomicNumber,
				expectedElementDisplayText: state.MatchType switch
				{
					MatchType.PlaceTheName => TableOfElementsData.ElementByNumber[action.AtomicNumber].Name,
					MatchType.PlaceTheSymbol => TableOfElementsData.ElementByNumber[action.AtomicNumber].Symbol,
					_ => throw new NotImplementedException(state.MatchType.ToString())
				},
				showElementGroup: false,
				highlighElementsInExpectedGroup: false,
				availableElements: state.AvailableElements.Where(x =>x != action.AtomicNumber).ToArray()
			);

		[ReducerMethod]
		public static ElementsMatchGameState RevealElementGroupAction(ElementsMatchGameState state, RevealElementGroupAction action) =>
			state.ExpectedElement != action.AtomicNumber
			? state
			: state.With(
					showElementGroup: true,
					highlighElementsInExpectedGroup: true);

		[ReducerMethod]
		public static ElementsMatchGameState ElementMatchedAction(ElementsMatchGameState state, ElementMatchedAction _) =>
			state.With
			(
				totalMatched: state.TotalMatched + 1,
				highlighElementsInExpectedGroup: false
			);

		[ReducerMethod]
		public static ElementsMatchGameState ElementMismatchedAction(ElementsMatchGameState state, ElementMismatchedAction _) =>
			state.With
			(
				totalMismatched: state.TotalMismatched + 1
			);
	}
}
