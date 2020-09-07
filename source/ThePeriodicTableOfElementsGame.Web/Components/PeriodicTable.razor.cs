using Fluxor;
using Microsoft.AspNetCore.Components;
using ThePeriodicTableOfElementsGame.GamePlay.ElementsMatchGame;

namespace ThePeriodicTableOfElementsGame.Web.Components
{
	public partial class PeriodicTable
	{
		[Parameter]
		public RenderFragment Header { get; set; }

		[Inject]
		private IState<ElementMatchGameState> GameState { get; set; }
	}
}
