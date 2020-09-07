using System;

namespace ThePeriodicTableOfElementsGame.Web.PeriodicTableData
{
	public enum ElementGroup
	{
		AlkaliMetal,
		AlkalineEarthMetal,
		TransitionMetal,
		BasicMetal,
		Semimetal,
		Nonmetal,
		Halogen,
		NobleGas,
		Lathanide,
		Actinide
	}

	public static class ElementGroupExtensions
	{
		public static string GetAsCssClass(this ElementGroup value) =>
			value switch
			{
				ElementGroup.AlkaliMetal => "--alkali-metal",
				ElementGroup.AlkalineEarthMetal => "--alkaline-earth-metal",
				ElementGroup.TransitionMetal => "--transitional-metal",
				ElementGroup.BasicMetal => "--basic-metal",
				ElementGroup.Semimetal => "--semi-metal",
				ElementGroup.Nonmetal => "--non-metal",
				ElementGroup.Halogen => "--halogen",
				ElementGroup.NobleGas => "--noble-gas",
				ElementGroup.Lathanide => "--lathanide",
				ElementGroup.Actinide => "--actinide",
				_ => throw new NotImplementedException(value.ToString())
			};

		public static string GetDescription(this ElementGroup value) =>
			value switch
			{
				ElementGroup.AlkaliMetal => "Alkali metal",
				ElementGroup.AlkalineEarthMetal => "Alkaline earth metal",
				ElementGroup.TransitionMetal => "Transitional metal",
				ElementGroup.BasicMetal => "Basic metal",
				ElementGroup.Semimetal => "Semi-metal",
				ElementGroup.Nonmetal => "Non-metal",
				ElementGroup.Halogen => "Halogen",
				ElementGroup.NobleGas => "Noble gas",
				ElementGroup.Lathanide => "Lathanide",
				ElementGroup.Actinide => "Actinide",
				_ => throw new NotImplementedException(value.ToString())
			};
	}
}
