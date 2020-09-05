namespace ThePeriodicTableOfElementsGame.Store.Services
{
	public interface IAudioPlayer
	{
		void PlayOneShot(AudioSample audioSample);
	}

	public enum AudioSample
	{
		ElementAppeared,
		ElementMismatched,
		ElementFastMatched1
	}
}
