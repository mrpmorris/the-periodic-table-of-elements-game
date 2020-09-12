using Fluxor;
using Microsoft.AspNetCore.Components;
using System.Collections.Generic;
using ThePeriodicTableOfElementsGame.GamePlay.ElementsMatchGame;

namespace ThePeriodicTableOfElementsGame.Web.Components
{
	public partial class PeriodicTable
	{
		[Parameter]
		public RenderFragment ChildContent { get; set; }

		[Inject]
		private IState<ElementsMatchGameState> GameState { get; set; }

		[Parameter(CaptureUnmatchedValues = true)]
		public Dictionary<string, object> Attributes { get; set; }
	}
}
