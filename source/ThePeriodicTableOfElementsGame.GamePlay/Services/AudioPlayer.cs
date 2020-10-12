using System;

namespace ThePeriodicTableOfElementsGame.GamePlay.Services
{
	public interface IAudioPlayer
	{
		void PlayOneShot(AudioSample audioSample);
		IAudioClip Create(
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

	public interface IAudioClip: IDisposable
	{
		event EventHandler<int> TimingEvent;
		void Play();
		void Stop();
	}
}
