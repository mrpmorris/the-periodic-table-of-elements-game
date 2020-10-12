namespace ThePeriodicTableOfElementsGame.GamePlay.PeriodicTableData
{
	public class ElementData
	{
		public byte AtomicNumber { get; }
		public string Symbol { get; }
		public string Name { get; }
		public byte Column { get; }
		public decimal Row { get; }
		public ElementGroup Group { get; }

		public ElementData(
			byte atomicNumber,
			string symbol,
			string name,
			byte column,
			decimal row,
			ElementGroup group)
		{
			AtomicNumber = atomicNumber;
			Symbol = symbol;
			Name = name;
			Column = column;
			Row = row;
			Group = group;
		}
	}


}
