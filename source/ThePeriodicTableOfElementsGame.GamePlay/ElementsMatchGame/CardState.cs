namespace ThePeriodicTableOfElementsGame.GamePlay.ElementsMatchGame
{
	public class CardState
	{
		public readonly bool ShowAtomicNumber;
		public readonly bool ShowSymbol;
		public readonly bool ShowName;

		public CardState(bool showAtomicNumber = true, bool showSymbol = true, bool showName = true)
		{
			ShowAtomicNumber = showAtomicNumber;
			ShowSymbol = showSymbol;
			ShowName = showName;
		}

		public CardState With(
			PropertyUpdate<bool> showAtomicNumber = null,
			PropertyUpdate<bool> showSymbol = null,
			PropertyUpdate<bool> showName = null)
			=>
				new CardState(
					showAtomicNumber: showAtomicNumber.GetUpdatedValue(ShowAtomicNumber),
					showSymbol: showSymbol.GetUpdatedValue(ShowSymbol),
					showName: showName.GetUpdatedValue(ShowName));
	}
}
