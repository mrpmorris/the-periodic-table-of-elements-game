using Microsoft.JSInterop;
using System;
using System.Threading.Tasks;
using ThePeriodicTableOfElementsGame.GamePlay.Services;

namespace ThePeriodicTableOfElementsGame.Blazor.Web.Services
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
			JSObjectReference jsAudio = await JSRuntime.InvokeAsync<JSObjectReference>(
				"ThePeriodicTableOfElementsGame.audio.create",
				GetAudioFilename(audioSample));

			return new AudioClip(jsAudio);
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

	public class AudioClip: IAudioClip
	{
		private readonly JSObjectReference JSAudio;

		public AudioClip(JSObjectReference jsAudio)
		{
			JSAudio = jsAudio ?? throw new ArgumentNullException(nameof(jsAudio));
		}

		public ValueTask<float> GetCurrentTime() =>
			JSAudio.InvokeAsync<float>("getCurrentTime");

		public ValueTask Play() =>
			JSAudio.InvokeVoidAsync("play");

		public ValueTask DisposeAsync() =>
			JSAudio.DisposeAsync();
	}
}
