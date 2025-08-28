using Fluxor;
using System;
using System.Linq;
using ThePeriodicTableOfElementsGame.GamePlay.Extensions;
using ThePeriodicTableOfElementsGame.GamePlay.Features.ElementsMatchGame.Actions;
using ThePeriodicTableOfElementsGame.GamePlay.PeriodicTableData;

namespace ThePeriodicTableOfElementsGame.GamePlay.Features.ElementsMatchGame
{
	public static class Reducers
	{
		[ReducerMethod]
		public static ElementsMatchGameState StartGameAction(ElementsMatchGameState state, StartElementsMatchGameAction action) =>
			ElementsMatchGameState.Default with
			{
				MatchType = action.MatchType,
				ElementStates = ElementsMatchGameState.Default.ElementStates.Values
					.Select(x =>
						x with
						{
							Back = x.Back with
							{
								ShowName = action.MatchType != MatchType.PlaceTheName,
								ShowSymbol = action.MatchType != MatchType.PlaceTheSymbol
							}
						}
					)
					.ToDictionary(x => x.AtomicNumber).AsReadOnly()
			};

		[ReducerMethod]
		public static ElementsMatchGameState RevealElementAction(ElementsMatchGameState state, RevealElementAction action) =>
			state with
			{
				ElementStates = state.ElementStates.Values
					.Select(x =>
						x.AtomicNumber != action.AtomicNumber
						? x
						: x with { Concealed = false })
					.ToDictionary(x => x.AtomicNumber).AsReadOnly()
			};

		[ReducerMethod(typeof(ConcealAllElementsAction))]
		public static ElementsMatchGameState ConcealAllElementsAction(ElementsMatchGameState state) =>
			state with
			{
				ElementStates = state.ElementStates.Values
					.Select(x => x with { Concealed = true })
					.ToDictionary(x => x.AtomicNumber).AsReadOnly()
			};

		[ReducerMethod]
		public static ElementsMatchGameState SetExpectedElementAction(ElementsMatchGameState state, SetExpectedElementAction action) =>
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
				AvailableElements = state.AvailableElements.Where(x => x != action.AtomicNumber).ToArray()
			};

		[ReducerMethod]
		public static ElementsMatchGameState RevealElementGroupAction(ElementsMatchGameState state, RevealElementGroupAction action) =>
			state.ExpectedElement != action.AtomicNumber
			? state
			: state with
			{
				ShowElementGroup = true,
				HighlighElementsInExpectedGroup = true
			};

		[ReducerMethod(typeof(ElementMatchedAction))]
		public static ElementsMatchGameState ElementMatchedAction(ElementsMatchGameState state) =>
			state with
			{
				TotalMatched = state.TotalMatched + 1,
				HighlighElementsInExpectedGroup = false
			};

		[ReducerMethod(typeof(ElementMismatchedAction))]
		public static ElementsMatchGameState ElementMismatchedAction(ElementsMatchGameState state) =>
			state with
			{
				TotalMismatched = state.TotalMismatched + 1
			};

#if DEBUG && I_WANNA_CHEAT
		[ReducerMethod(typeof(CompleteAllButOneElementAction))]
		public static ElementsMatchGameState CompleteAllButOneElementAction(ElementsMatchGameState state) =>
			state with
			{
				AvailableElements = new byte[] { 1 }
			};
#endif
	}
}
