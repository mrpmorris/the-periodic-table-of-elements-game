using Microsoft.AspNetCore.Components;
using System.Collections.Generic;
using ThePeriodicTableOfElementsGame.GamePlay.ElementsMatchGame;

namespace ThePeriodicTableOfElementsGame.Blazor.Web.Components
{
	public partial class PeriodicTable
	{
		[Parameter]
		public RenderFragment ChildContent { get; set; }

		[Parameter]
		public IEnumerable<ElementState> ElementStates { get; set; }

		[Parameter(CaptureUnmatchedValues = true)]
		public Dictionary<string, object> Attributes { get; set; }
	}
}
