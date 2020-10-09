using System;

namespace ThePeriodicTableOfElementsGame.GamePlay.ElementsSpeedMatchGameFeature
{
	public class ElementTiming
	{
		public readonly TimeSpan Time;
		public readonly byte AtomicNumber;

		public ElementTiming(TimeSpan time, byte atomicNumber)
		{
			Time = time;
			AtomicNumber = atomicNumber;
		}
	}
}
