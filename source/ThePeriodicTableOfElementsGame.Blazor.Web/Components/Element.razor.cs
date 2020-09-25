using Fluxor;
using Microsoft.AspNetCore.Components;
using ThePeriodicTableOfElementsGame.Blazor.Web.Extensions;
using ThePeriodicTableOfElementsGame.GamePlay.ElementsMatchGame;
using ThePeriodicTableOfElementsGame.GamePlay.PeriodicTableData;
using ThePeriodicTableOfElementsGame.GamePlay.ElementsMatchGame.Actions;

namespace ThePeriodicTableOfElementsGame.Blazor.Web.Components
{
	public partial class Element
	{
		[Parameter]
		public ElementState State { get => _state; set { SetState(value); } }

		[Inject]
		private IDispatcher Dispatcher { get; set; }

		private ElementState _state;
		private ElementData Data;
		private bool NeedsRender = true;

		public string GetStyles() => 
			$"grid-column-start:{Data.Column}; grid-row-start:{Data.Row}";

		public string GetClasses() =>
			$"{Data.Group.GetAsCssClass()} " + (State.Concealed ? "--concealed" : "");

		protected override bool ShouldRender() => NeedsRender;

		protected override void OnAfterRender(bool firstRender)
		{
			base.OnAfterRender(firstRender);
			NeedsRender = false;
		}

		private void SetState(ElementState state)
		{
			if (state == _state)
				return;

			_state = state;
			Data = TableOfElementsData.ElementByNumber[state.AtomicNumber];
			NeedsRender = true;
		}

		private void Clicked()
		{
			Dispatcher.Dispatch(new ClickElementAction(AtomicNumber: State.AtomicNumber));
		}
	}
}
