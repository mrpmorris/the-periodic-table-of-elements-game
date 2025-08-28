using Fluxor;

namespace ThePeriodicTableOfElementsGame.GamePlay.Features.MainMenu;

[FeatureState]
public record MainMenuState(SubMenuType? VisibleSubMenu)
{
	public MainMenuState() : this(VisibleSubMenu: null)
	{
	}
}
