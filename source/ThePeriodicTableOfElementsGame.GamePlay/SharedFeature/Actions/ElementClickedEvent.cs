namespace ThePeriodicTableOfElementsGame.GamePlay.SharedFeature.Actions
{
	public class ElementClickedEvent
	{
		public readonly byte AtomicNumber;

		public ElementClickedEvent(byte atomicNumber)
		{
			AtomicNumber = atomicNumber;
		}
	}
}
