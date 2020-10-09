using System;
using System.Threading.Tasks;

namespace ThePeriodicTableOfElementsGame.GamePlay.Services
{
	public interface IAudioPlayer
	{
		Task PlayOneShotAsync(AudioSample audioSample);
		Task<IAudioClip> CreateAsync(AudioSample audioSample);
	}

	public enum AudioSample
	{
		ElementAppeared,
		ElementMismatched,
		ElementFastMatched1,
		ElementsSong
	}

	public interface IAudioClip: IAsyncDisposable
	{
		ValueTask<float> GetCurrentTime();
		ValueTask PlayAsync();
		ValueTask StopAsync();
	}
}
