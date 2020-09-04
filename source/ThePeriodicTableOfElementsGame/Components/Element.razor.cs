using Fluxor;
using Microsoft.AspNetCore.Components;
using ThePeriodicTableOfElementsGame.PeriodicTableData;
using ThePeriodicTableOfElementsGame.Store;
using ThePeriodicTableOfElementsGame.Store.GameState;

namespace ThePeriodicTableOfElementsGame.Components
{
	public partial class Element
	{
		[Parameter]
		public ElementState State { get => _state; set { SetState(value); } }

		[Inject]
		private IDispatcher Dispatcher { get; set; }

		private ElementState _state;
		private ElementData Data;

		public string GetStyles() => 
			$"grid-column-start:{Data.Column}; grid-row-start:{Data.Row}";

		public string GetClasses() =>
			$"{Data.Group.GetAsCssClass()} " + (State.Concealed ? "--concealed" : "");

		private void SetState(ElementState state)
		{
			_state = state;
			Data = TableData.ElementByNumber[state.AtomicNumber];
		}

		private void Clicked()
		{
			Dispatcher.Dispatch(new ClickElementAction(AtomicNumber: State.AtomicNumber));
		}
	}
}
