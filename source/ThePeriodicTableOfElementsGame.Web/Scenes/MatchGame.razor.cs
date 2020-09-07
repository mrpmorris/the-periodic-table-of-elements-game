using Fluxor;
using Microsoft.AspNetCore.Components;
using ThePeriodicTableOfElementsGame.GamePlay.PeriodicTableData;
using ThePeriodicTableOfElementsGame.GamePlay.ElementsMatchGame;

namespace ThePeriodicTableOfElementsGame.Web.Scenes
{
	public partial class MatchGame
	{
		[Inject]
		private IDispatcher Dispatcher { get; set; }

		[Inject]
		private IState<ElementMatchGameState> GameState { get; set; }

		private string GetElementGroupAsCssClass() =>
			GameState.Value.ExpectedElement is null || !GameState.Value.ShowElementGroup
			? ""
			: ElementGroupExtensions.GetAsCssClass(
					TableOfElementsData.ElementByNumber[GameState.Value.ExpectedElement.Value].Group);

		protected override void OnAfterRender(bool firstRender)
		{
			base.OnAfterRenderAsync(firstRender);
			if (firstRender)
				Dispatcher.Dispatch(new GameStartedAction());
		}
	}
}
