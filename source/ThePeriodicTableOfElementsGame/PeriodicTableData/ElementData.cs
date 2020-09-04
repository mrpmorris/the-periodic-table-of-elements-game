namespace ThePeriodicTableOfElementsGame.PeriodicTableData
{
	public struct ElementData
	{
		public byte AtomicNumber { get; }
		public string Symbol { get; }
		public string Name { get; }
		public byte Column { get; }
		public byte Row { get; }
		public ElementGroup Group { get; }

		public ElementData(
			byte atomicNumber,
			string symbol,
			string name,
			byte column,
			byte row,
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
