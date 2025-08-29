namespace ThePeriodicTableOfElementsGame.GamePlay.Features.ElementsMatchGame;

public readonly record struct CardState(
	bool ShowAtomicNumber,
	bool ShowSymbol,
	bool ShowName)
{
	public static readonly CardState Default = new(
		ShowAtomicNumber: true,
		ShowSymbol: true,
		ShowName: true);
}
