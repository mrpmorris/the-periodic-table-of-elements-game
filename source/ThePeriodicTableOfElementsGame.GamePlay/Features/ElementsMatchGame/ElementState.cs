namespace ThePeriodicTableOfElementsGame.GamePlay.Features.ElementsMatchGame;

public readonly record struct ElementState(
	byte AtomicNumber,
	CardState Front,
	CardState Back,
	bool Concealed);
