namespace ThePeriodicTableOfElementsGame.GamePlay
{
	public class PropertyUpdate<T>
	{
		public readonly bool Updated;
		internal readonly T Value;

		public static implicit operator PropertyUpdate<T>(T value) => new PropertyUpdate<T>(value);
		public static readonly PropertyUpdate<T> Default = new PropertyUpdate<T>();

		private PropertyUpdate() { }

		private PropertyUpdate(T value)
		{
			Updated = true;
			Value = value;
		}

		public override string ToString() =>
			Updated ? null : Value?.ToString();
	}

	public static class PropertyUpdateExtensions
	{
		public static T GetValueOrDefault<T>(this PropertyUpdate<T> update) =>
			update.GetUpdatedValue(default);

		public static T GetUpdatedValue<T>(this PropertyUpdate<T> update, T originalValue) =>
			update?.Updated == true ? update.Value : originalValue;
	}

}
