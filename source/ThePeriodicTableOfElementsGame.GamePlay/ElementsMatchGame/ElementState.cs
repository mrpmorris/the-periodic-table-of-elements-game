namespace ThePeriodicTableOfElementsGame.GamePlay.ElementsMatchGame
{
	public class ElementState
	{
		public readonly byte AtomicNumber;
		public readonly CardState Front;
		public readonly CardState Back;
		public readonly bool Concealed;

		public ElementState(
			byte atomicNumber,
			CardState front,
			CardState back,
			bool concealed)
		{
			AtomicNumber = atomicNumber;
			Front = front;
			Back = back;
			Concealed = concealed;
		}

		public ElementState With(
			PropertyUpdate<byte> atomicNumber = null,
			PropertyUpdate<CardState> front = null,
			PropertyUpdate<CardState> back = null,
			PropertyUpdate<bool> concealed = null)
			=>
				new ElementState(
					atomicNumber.GetUpdatedValue(AtomicNumber),
					front: front.GetUpdatedValue(Front),
					back: back.GetUpdatedValue(Back),
					concealed: concealed.GetUpdatedValue(Concealed));
	}
}
