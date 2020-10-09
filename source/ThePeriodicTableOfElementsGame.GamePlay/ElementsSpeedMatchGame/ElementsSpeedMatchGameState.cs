using System;
using System.Collections.Generic;
using System.Linq;
using ThePeriodicTableOfElementsGame.GamePlay.PeriodicTableFeature;

namespace ThePeriodicTableOfElementsGame.GamePlay.ElementsSpeedMatchGameFeature
{
	public class ElementsSpeedMatchGameState
	{
		public readonly IEnumerable<ElementState> ElementStates;
		public readonly IEnumerable<ElementTiming> ElementTimings;

		public ElementsSpeedMatchGameState(
			IEnumerable<ElementState> elementStates,
			IEnumerable<ElementTiming> elementTimings)
		{
			ElementStates = elementStates;
			ElementTimings = elementTimings;
		}

		public ElementsSpeedMatchGameState With(
			PropertyUpdate<IEnumerable<ElementState>> elementStates = null,
			PropertyUpdate<IEnumerable<ElementTiming>> elementTimings = null)
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
				elementTimings: new ElementTiming[]
				{
					new ElementTiming(time: new TimeSpan(0, 0, 0, 07, 466), atomicNumber: 51), // Sb
					new ElementTiming(time: new TimeSpan(0, 0, 0, 07, 945), atomicNumber: 33), // As
					new ElementTiming(time: new TimeSpan(0, 0, 0, 08, 207), atomicNumber: 13), // Al
					new ElementTiming(time: new TimeSpan(0, 0, 0, 08, 643), atomicNumber: 34), // Se
					new ElementTiming(time: new TimeSpan(0, 0, 0, 09, 229), atomicNumber: 01), // H
					new ElementTiming(time: new TimeSpan(0, 0, 0, 09, 547), atomicNumber: 08), // O
					new ElementTiming(time: new TimeSpan(0, 0, 0, 10, 001), atomicNumber: 07), // N
					new ElementTiming(time: new TimeSpan(0, 0, 0, 10, 421), atomicNumber: 75), // Re
					new ElementTiming(time: new TimeSpan(0, 0, 0, 10, 897), atomicNumber: 28), // Ni
					new ElementTiming(time: new TimeSpan(0, 0, 0, 11, 071), atomicNumber: 60), // Nd
					new ElementTiming(time: new TimeSpan(0, 0, 0, 11, 601), atomicNumber: 93), // Np
					new ElementTiming(time: new TimeSpan(0, 0, 0, 12, 030), atomicNumber: 32), // Ge
					new ElementTiming(time: new TimeSpan(0, 0, 0, 12, 597), atomicNumber: 26), // Fe
					new ElementTiming(time: new TimeSpan(0, 0, 0, 12, 871), atomicNumber: 95), // Am
					new ElementTiming(time: new TimeSpan(0, 0, 0, 13, 270), atomicNumber: 44), // Ru
					new ElementTiming(time: new TimeSpan(0, 0, 0, 13, 775), atomicNumber: 92), // U
				}
			);
	}
}
