using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using ThePeriodicTableOfElementsGame.GamePlay.PeriodicTableFeature;

namespace ThePeriodicTableOfElementsGame.GamePlay.ElementsSpeedMatchGameFeature
{
	public class ElementsSpeedMatchGameState
	{
		public readonly IEnumerable<ElementState> ElementStates;
		public readonly ReadOnlyDictionary<int, byte> ElementTimings;

		public ElementsSpeedMatchGameState(
			IEnumerable<ElementState> elementStates,
			ReadOnlyDictionary<int, byte> elementTimings)
		{
			ElementStates = elementStates;
			ElementTimings = elementTimings;
		}

		public ElementsSpeedMatchGameState With(
			PropertyUpdate<IEnumerable<ElementState>> elementStates = null,
			PropertyUpdate<ReadOnlyDictionary<int, byte>> elementTimings = null)
			=>
				new ElementsSpeedMatchGameState(
					elementStates: elementStates.GetUpdatedValue(ElementStates),
					elementTimings: elementTimings.GetUpdatedValue(ElementTimings));
	}

	public static class ElementsSpeedMatchGameStateExtensions
	{
		public static readonly ElementsSpeedMatchGameState DefaultState =
			new ElementsSpeedMatchGameState(
				elementStates: Enumerable.Range(1, 118)
					.Select(x => new ElementState(
						atomicNumber: (byte)x,
						front: new CardState(),
						back: new CardState(),
						concealed: false))
					.ToArray(),
				elementTimings: new ReadOnlyDictionary<int, byte>(
					new Dictionary<int, byte>
					{
						[009_377] = 051, // Sb
						[009_859] = 033, // As
						[010_250] = 013, // Al
						[010_684] = 034, // Se
						[011_342] = 001, // H
						[011_844] = 008, // O
						[012_336] = 007, // N
						[012_900] = 075, // Re
						[013_385] = 028, // Ni
						[013_638] = 060, // Nd
						[014_282] = 093, // Np
						[014_790] = 032, // Ge
						[015_416] = 026, // Fe
						[015_714] = 095, // Am
						[016_357] = 044, // Ru
						[016_914] = 092 // U
					})
			);
	}
}
