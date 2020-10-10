using Microsoft.JSInterop;
using System;
using System.Collections.Generic;
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
				Consts.Namespace + "playOneShot",
				GetAudioFilename(audioSample));
		}

		public Task<IAudioClip> CreateAsync(
			AudioSample audioSample,
			int[] eventTimingsMs = null)
			=> AudioClip.CreateAsync(
					JSRuntime,
					GetAudioFilename(audioSample),
					eventTimingsMs ?? Array.Empty<int>());

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
