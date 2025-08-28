namespace ThePeriodicTableOfElementsGame.GamePlay.ElementsMatchGame;

public record CardState(
	bool ShowAtomicNumber,
	bool ShowSymbol,
	bool ShowName)
{
	public static readonly CardState Default = new(
		ShowAtomicNumber: true,
		ShowSymbol: true,
		ShowName: true);
}
