using Fluxor;
using Microsoft.AspNetCore.Components;
using ThePeriodicTableOfElementsGame.Store.GameState;

namespace ThePeriodicTableOfElementsGame.Components
{
	public partial class PeriodicTable
	{
		[Parameter]
		public RenderFragment Header { get; set; }

		[Inject]
		private IState<GameState> GameState { get; set; }
	}
}
