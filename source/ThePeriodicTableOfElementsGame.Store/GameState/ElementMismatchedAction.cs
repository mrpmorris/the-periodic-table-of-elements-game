namespace ThePeriodicTableOfElementsGame.Store.GameState
{
	public record ElementMismatchedAction(byte ClickedAtomicNumber, byte? CorrectAtomicNumber);
}
