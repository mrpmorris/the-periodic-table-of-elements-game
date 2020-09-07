using Microsoft.JSInterop;
using System;
using System.Threading.Tasks;
using ThePeriodicTableOfElementsGame.GamePlay.Services;

namespace ThePeriodicTableOfElementsGame.Web.Services
{
	public class AudioPlayer : IAudioPlayer
	{
		private readonly IJSRuntime JSRuntime;

		public AudioPlayer(IJSRuntime jSRuntime)
		{
			JSRuntime = jSRuntime;
		}

		public async Task PlayOneShotAsync(AudioSample audioSample)
		{
			await JSRuntime.InvokeVoidAsync(
				"ThePeriodicTableOfElementsGame.audio.playOneShot",
				GetAudioFilename(audioSample));
		}

		private static string GetAudioFilename(AudioSample audioSample) =>
			audioSample switch
			{
				AudioSample.ElementAppeared => "ElementAppeared.ogg",
				AudioSample.ElementFastMatched1 => "ElementFastMatched1.ogg",
				AudioSample.ElementMismatched => "ElementMismatched.ogg",
				_ => throw new NotImplementedException(audioSample.ToString())
			};
	}
}
