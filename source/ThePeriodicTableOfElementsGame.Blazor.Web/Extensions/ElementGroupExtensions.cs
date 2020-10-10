using System;
using ThePeriodicTableOfElementsGame.GamePlay.PeriodicTableData;

namespace ThePeriodicTableOfElementsGame.Blazor.Web.Extensions
{
	public static class ElementGroupExtensions
	{
		public static string GetAsCssClass(this ElementGroup value) =>
			value switch
			{
				ElementGroup.Actinide => "--actinide",
				ElementGroup.AlkaliMetal => "--alkali-metal",
				ElementGroup.AlkalineEarthMetal => "--alkaline-earth-metal",
				ElementGroup.Lathanide => "--lathanide",
				ElementGroup.Metalloid => "--metalloid",
				ElementGroup.NobleGas => "--noble-gas",
				ElementGroup.PostTransitionMetal => "--post-transitional-metal",
				ElementGroup.ReactiveNonmetal => "--reactive-non-metal",
				ElementGroup.TransitionMetal => "--transitional-metal",
				ElementGroup.Unknown => "--unknown",
				_ => throw new NotImplementedException(value.ToString())
			};

		public static string GetDescription(this ElementGroup value) =>
			value switch
			{
				ElementGroup.Actinide => "Actinide",
				ElementGroup.AlkaliMetal => "Alkali metal",
				ElementGroup.AlkalineEarthMetal => "Alkaline earth metal",
				ElementGroup.Lathanide => "Lathanide",
				ElementGroup.Metalloid => "Metalloid",
				ElementGroup.NobleGas => "Noble gas",
				ElementGroup.PostTransitionMetal => "Post-transitional metal",
				ElementGroup.ReactiveNonmetal => "Reactive non-metal",
				ElementGroup.TransitionMetal => "Transitional metal",
				ElementGroup.Unknown => "Unknown properties",
				_ => throw new NotImplementedException(value.ToString())
			};

	}
}
