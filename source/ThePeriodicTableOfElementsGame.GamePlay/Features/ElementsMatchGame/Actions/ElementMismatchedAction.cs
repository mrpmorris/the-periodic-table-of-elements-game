namespace ThePeriodicTableOfElementsGame.GamePlay.Features.ElementsMatchGame.Actions;

public readonly record struct ElementMismatchedAction(byte ClickedAtomicNumber, byte? ExpectedAtomicNumber);
