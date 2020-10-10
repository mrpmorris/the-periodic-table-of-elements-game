using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace ThePeriodicTableOfElementsGame.GamePlay.Services
{
	public interface IAudioPlayer
	{
		Task PlayOneShotAsync(AudioSample audioSample);
		Task<IAudioClip> CreateAsync(
			AudioSample audioSample,
			IEnumerable<int> eventTimingsMs);
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
