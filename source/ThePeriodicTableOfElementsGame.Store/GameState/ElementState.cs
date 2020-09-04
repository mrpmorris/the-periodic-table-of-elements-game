namespace ThePeriodicTableOfElementsGame.Store.GameState
{
	public record ElementState(byte AtomicNumber, CardState Front, CardState Back, bool Concealed);
}
