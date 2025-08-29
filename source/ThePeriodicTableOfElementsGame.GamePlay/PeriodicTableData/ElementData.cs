namespace ThePeriodicTableOfElementsGame.GamePlay.PeriodicTableData;

public record ElementData(
	byte AtomicNumber,
	string Symbol,
	string Name,
	byte Column,
	decimal Row,
	ElementGroup Group);
