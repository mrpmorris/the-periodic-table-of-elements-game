using Microsoft.JSInterop;
using System;
using System.Threading.Tasks;
using ThePeriodicTableOfElementsGame.GamePlay.Services;

namespace ThePeriodicTableOfElementsGame.Blazor.Web.Services.Audio
{
	public class AudioPlayer : IAudioPlayer
	{
		private readonly IJSInProcessRuntime JSRuntime;

		public AudioPlayer(IJSInProcessRuntime jSRuntime)
		{
			JSRuntime = jSRuntime;
		}

		public Task PlayOneShotAsync(AudioSample audioSample)
		{
			JSRuntime.InvokeVoid(
				Consts.Namespace + "playOneShot",
				GetAudioFilename(audioSample));
			return Task.CompletedTask;
		}

		public IAudioClip Create(
			AudioSample audioSample,
			int[] eventTimingsMs = null)
			=> AudioClip.Create(
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
