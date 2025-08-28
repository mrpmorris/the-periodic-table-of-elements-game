using ThePeriodicTableOfElementsGame.GamePlay.Features.MainMenu;

namespace ThePeriodicTableOfElementsGame.Blazor.Web.Scenes;

public partial class NewMainMenu
{
	private void ShowSubMenu(SubMenuType subMenuType)
	{
		var action = new ShowSubMenuIndexAction(subMenuType);
		Dispatcher.Dispatch(action);
	}
}