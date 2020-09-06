using Fluxor;
using Microsoft.AspNetCore.Components;
using ThePeriodicTableOfElementsGame.PeriodicTableData;
using ThePeriodicTableOfElementsGame.Store.GameState;

namespace ThePeriodicTableOfElementsGame.Scenes
{
	public partial class MatchGame
	{
		[Inject]
		private IState<GameState> GameState { get; set; }

		private string GetElementGroupAsCssClass() =>
			GameState.Value.ExpectedElement is null || !GameState.Value.ShowElementGroup
			? ""
			: ElementGroupExtensions.GetAsCssClass(
					TableData.ElementByNumber[GameState.Value.ExpectedElement.Value].Group);
	}
}
