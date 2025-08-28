using ThePeriodicTableOfElementsGame.GamePlay.Features.MainMenu;

namespace ThePeriodicTableOfElementsGame.Blazor.Web.Scenes.MainMenu;

public partial class MainMenu
{
	private void ShowSubMenu(SubMenuType subMenuType)
	{
		var action = new ShowSubMenuIndexAction(subMenuType);
		Dispatcher.Dispatch(action);
	}
}