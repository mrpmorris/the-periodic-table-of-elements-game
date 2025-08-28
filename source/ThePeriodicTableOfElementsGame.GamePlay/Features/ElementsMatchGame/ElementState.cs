namespace ThePeriodicTableOfElementsGame.GamePlay.Features.ElementsMatchGame;

public record ElementState(
	byte AtomicNumber,
	CardState Front,
	CardState Back,
	bool Concealed);
