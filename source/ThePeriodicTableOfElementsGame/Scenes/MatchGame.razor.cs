using Fluxor;
using Microsoft.AspNetCore.Components;
using System.Threading.Tasks;
using ThePeriodicTableOfElementsGame.PeriodicTableData;
using ThePeriodicTableOfElementsGame.Store.GameState;

namespace ThePeriodicTableOfElementsGame.Scenes
{
	public partial class MatchGame
	{
		[Inject]
		private IDispatcher Dispatcher { get; set; }

		[Inject]
		private IState<GameState> GameState { get; set; }

		private string GetElementGroupAsCssClass() =>
			GameState.Value.ExpectedElement is null || !GameState.Value.ShowElementGroup
			? ""
			: ElementGroupExtensions.GetAsCssClass(
					TableData.ElementByNumber[GameState.Value.ExpectedElement.Value].Group);

		protected override void OnAfterRender(bool firstRender)
		{
			base.OnAfterRenderAsync(firstRender);
			if (firstRender)
				Dispatcher.Dispatch(new GameStartedAction());
		}
	}
}
