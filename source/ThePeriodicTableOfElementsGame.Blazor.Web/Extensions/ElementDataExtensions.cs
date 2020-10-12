using ThePeriodicTableOfElementsGame.GamePlay.PeriodicTableData;

namespace ThePeriodicTableOfElementsGame.Blazor.Web.Extensions
{
	public static class ElementDataExtensions
	{
		public static string GetCssStyleLeft(this ElementData data) =>
			$"calc(100% / 18 * {data.Column - 1})";

		public static string GetCssStyleTop(this ElementData data) =>
			$"calc(100% / 9.5 * {data.Row - 1})";
	}
}
