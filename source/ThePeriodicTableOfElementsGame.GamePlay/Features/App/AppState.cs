using Fluxor;

namespace ThePeriodicTableOfElementsGame.GamePlay.Features.App;

[FeatureState]
public record AppState(Scene ActiveScene)
{
	public AppState() : this(ActiveScene: Scene.TitleScreen)
	{
	}
}
