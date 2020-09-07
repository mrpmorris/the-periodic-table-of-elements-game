using Microsoft.AspNetCore.Components;

namespace ThePeriodicTableOfElementsGame.Web.Scenes
{
	public partial class MainMenu
	{
		[Inject]
		private NavigationManager NavigationManager { get; set; }

		private void PlayMatchGame()
		{
			NavigationManager.NavigateTo("/match-game");
		}
	}
}
