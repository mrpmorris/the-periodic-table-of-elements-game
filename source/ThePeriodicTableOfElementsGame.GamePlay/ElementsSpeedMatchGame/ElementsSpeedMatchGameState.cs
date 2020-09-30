using System;
using System.Collections.Generic;
using System.Collections.Immutable;
using System.Linq;
using ThePeriodicTableOfElementsGame.GamePlay.PeriodicTableFeature;

namespace ThePeriodicTableOfElementsGame.GamePlay.ElementsSpeedMatchGame
{
	public record ElementsSpeedMatchGameState(
		IEnumerable<ElementState> ElementStates,
		IEnumerable<ElementTiming> ElementTimings
		);

	public static class ElementsSpeedMatchGameStateExtensions
	{
		public static readonly ElementsSpeedMatchGameState DefaultState =
			new ElementsSpeedMatchGameState(
				ElementStates: Enumerable.Range(1, 118)
					.Select(x => new ElementState(
						AtomicNumber: (byte)x,
						Front: new CardState(),
						Back: new CardState(),
						Concealed: false))
					.ToImmutableList(),
				ElementTimings: new ElementTiming[]
				{
					new ElementTiming(Time: new TimeSpan(0, 0, 0, 07, 466), AtomicNumber: 51), // Sb
					new ElementTiming(Time: new TimeSpan(0, 0, 0, 07, 945), AtomicNumber: 33), // As
					new ElementTiming(Time: new TimeSpan(0, 0, 0, 08, 207), AtomicNumber: 13), // Al
					new ElementTiming(Time: new TimeSpan(0, 0, 0, 08, 643), AtomicNumber: 34), // Se
					new ElementTiming(Time: new TimeSpan(0, 0, 0, 09, 229), AtomicNumber: 01), // H
					new ElementTiming(Time: new TimeSpan(0, 0, 0, 09, 547), AtomicNumber: 08), // O
					new ElementTiming(Time: new TimeSpan(0, 0, 0, 10, 001), AtomicNumber: 07), // N
					new ElementTiming(Time: new TimeSpan(0, 0, 0, 10, 421), AtomicNumber: 75), // Re
					new ElementTiming(Time: new TimeSpan(0, 0, 0, 10, 897), AtomicNumber: 28), // Ni
					new ElementTiming(Time: new TimeSpan(0, 0, 0, 11, 071), AtomicNumber: 60), // Nd
					new ElementTiming(Time: new TimeSpan(0, 0, 0, 11, 601), AtomicNumber: 93), // Np
					new ElementTiming(Time: new TimeSpan(0, 0, 0, 12, 030), AtomicNumber: 32), // Ge
					new ElementTiming(Time: new TimeSpan(0, 0, 0, 12, 597), AtomicNumber: 26), // Fe
					new ElementTiming(Time: new TimeSpan(0, 0, 0, 12, 871), AtomicNumber: 95), // Am
					new ElementTiming(Time: new TimeSpan(0, 0, 0, 13, 270), AtomicNumber: 44), // Ru
					new ElementTiming(Time: new TimeSpan(0, 0, 0, 13, 775), AtomicNumber: 92), // U
				}
			);
	}
}
