using Fluxor;

namespace ThePeriodicTableOfElementsGame.GamePlay.Features.MainMenu;

public static class MainMenuReducers
{
	[ReducerMethod]
	public static MainMenuState ReduceShowSubMenu(MainMenuState state, ShowSubMenuIndexAction action) =>
		state with { VisibleSubMenu = action.SubMenuType };

	[ReducerMethod(typeof(HideSubMenuAction))]
	public static MainMenuState ReduceHideSubMenuAction(MainMenuState state) =>
		state with { VisibleSubMenu = null };
}
