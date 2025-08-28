namespace ThePeriodicTableOfElementsGame.GamePlay.Features.ElementsMatchGame
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
