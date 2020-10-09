using Microsoft.JSInterop;
using System;
using System.Threading.Tasks;
using ThePeriodicTableOfElementsGame.GamePlay.Services;

namespace ThePeriodicTableOfElementsGame.Blazor.Web.Services.Audio
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

		public async Task<IAudioClip> CreateAsync(AudioSample audioSample)
		{
			int audioId = await JSRuntime.InvokeAsync<int>(
				"ThePeriodicTableOfElementsGame.audio.create",
				GetAudioFilename(audioSample));

			return new AudioClip(JSRuntime, audioId);
		}

		private static string GetAudioFilename(AudioSample audioSample) =>
			audioSample switch
			{
				AudioSample.ElementAppeared => "ElementAppeared.ogg",
				AudioSample.ElementFastMatched1 => "ElementFastMatched1.ogg",
				AudioSample.ElementMismatched => "ElementMismatched.ogg",
				AudioSample.ElementsSong => "ElementsSong.ogg",
				_ => throw new NotImplementedException(audioSample.ToString())
			};
	}
}
