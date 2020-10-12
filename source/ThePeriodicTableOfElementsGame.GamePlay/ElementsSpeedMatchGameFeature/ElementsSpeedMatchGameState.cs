using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using ThePeriodicTableOfElementsGame.GamePlay.ElementsSpeedMatchGameFeature.Actions;
using ThePeriodicTableOfElementsGame.GamePlay.PeriodicTableFeature;

namespace ThePeriodicTableOfElementsGame.GamePlay.ElementsSpeedMatchGameFeature
{
	public class ElementsSpeedMatchGameState
	{
		public readonly IEnumerable<ElementState> ElementStates;
		public readonly ReadOnlyDictionary<int, object> ElementTimings;
		public readonly byte? HighlightedAtomicNumber;

		public ElementsSpeedMatchGameState(
			IEnumerable<ElementState> elementStates,
			ReadOnlyDictionary<int, object> elementTimings,
			byte? highlightedAtomicNumber)
		{
			ElementStates = elementStates;
			ElementTimings = elementTimings;
			HighlightedAtomicNumber = highlightedAtomicNumber;
		}

		public ElementsSpeedMatchGameState With(
			PropertyUpdate<IEnumerable<ElementState>> elementStates = null,
			PropertyUpdate<ReadOnlyDictionary<int, object>> elementTimings = null,
			PropertyUpdate<byte?> highlightedAtomicNumber = null)
			=>
				new ElementsSpeedMatchGameState(
					elementStates: elementStates.GetUpdatedValue(ElementStates),
					elementTimings: elementTimings.GetUpdatedValue(ElementTimings),
					highlightedAtomicNumber: highlightedAtomicNumber.GetUpdatedValue(HighlightedAtomicNumber));
	}

	public static class ElementsSpeedMatchGameStateExtensions
	{
		public static readonly ElementsSpeedMatchGameState DefaultState =
			new ElementsSpeedMatchGameState(
				highlightedAtomicNumber: PropertyUpdate<byte?>.Default,
				elementStates: Enumerable.Range(1, 118)
					.Select(x => new ElementState(
						atomicNumber: (byte)x,
						front: new CardState(),
						back: new CardState(),
						concealed: false))
					.ToArray(),
				elementTimings: new ReadOnlyDictionary<int, object>(
					new Dictionary<int, object>
					{
						[008_377] = new HighlightElementAction(051), // Sb
						[008_859] = new HighlightElementAction(033), // As
						[009_250] = new HighlightElementAction(013), // Al
						[009_684] = new HighlightElementAction(034), // Se
						[010_342] = new HighlightElementAction(001), // H
						[010_844] = new HighlightElementAction(008), // O
						[011_336] = new HighlightElementAction(007), // N
						[011_900] = new HighlightElementAction(075), // Re
						[012_385] = new HighlightElementAction(028), // Ni
						[012_638] = new HighlightElementAction(060), // Nd
						[013_282] = new HighlightElementAction(093), // Np
						[013_790] = new HighlightElementAction(032), // Ge
						[014_416] = new HighlightElementAction(026), // Fe
						[014_714] = new HighlightElementAction(095), // Am
						[015_357] = new HighlightElementAction(044), // Ru
						[015_914] = new HighlightElementAction(092) // U
					})
			);
	}
}
