using System;
using System.Collections.Generic;

namespace ThePeriodicTableOfElementsGame.GamePlay.Services;

public interface IAudioPlayer
{
	void PlayOneShot(AudioSample audioSample);
	IAudioClip Create(
		AudioSample audioSample,
		IEnumerable<int> eventTimingsMs = null);
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
