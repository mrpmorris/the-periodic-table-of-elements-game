using System.Threading.Tasks;

namespace ThePeriodicTableOfElementsGame.GamePlay.Services
{
	public interface IAudioPlayer
	{
		Task PlayOneShotAsync(AudioSample audioSample);
	}

	public enum AudioSample
	{
		ElementAppeared,
		ElementMismatched,
		ElementFastMatched1
	}
}
