namespace ThePeriodicTableOfElementsGame.GamePlay.ElementsMatchGame.Actions
{
	public class ElementMismatchedAction
	{
		public readonly byte ClickedAtomicNumber;
		public readonly byte? ExpectedAtomicNumber;

		public ElementMismatchedAction(byte clickedAtomicNumber, byte? expectedAtomicNumber)
		{
			ClickedAtomicNumber = clickedAtomicNumber;
			ExpectedAtomicNumber = expectedAtomicNumber;
		}
	}
}
