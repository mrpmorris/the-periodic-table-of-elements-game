using System.Collections.Generic;
using System.Collections.ObjectModel;

namespace ThePeriodicTableOfElementsGame.GamePlay.Extensions
{
	public static class DictionaryExtensions
	{
		public static ReadOnlyDictionary<TKey, TValue> AsReadOnly<TKey, TValue>(this Dictionary<TKey, TValue> source) =>
			new ReadOnlyDictionary<TKey, TValue>(source);
	}
}
