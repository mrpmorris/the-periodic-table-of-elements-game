using Fluxor;
using Microsoft.AspNetCore.Components;
using System.Collections.Generic;
using ThePeriodicTableOfElementsGame.GamePlay.ElementsMatchGame;

namespace ThePeriodicTableOfElementsGame.Web.Components
{
	public partial class PeriodicTable
	{
		[Parameter]
		public RenderFragment Header { get; set; }

		[Inject]
		private IState<ElementMatchGameState> GameState { get; set; }

		[Parameter(CaptureUnmatchedValues = true)]
		public Dictionary<string, object> Attributes { get; set; }
	}
}
