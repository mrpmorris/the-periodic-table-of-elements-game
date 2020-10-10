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
			int[] eventTimingsMs = null);
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
		event EventHandler<int> TimingEvent;
		ValueTask PlayAsync();
		ValueTask StopAsync();
	}
}
