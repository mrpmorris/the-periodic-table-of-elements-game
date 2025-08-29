using Microsoft.JSInterop;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using ThePeriodicTableOfElementsGame.GamePlay.Services;

namespace ThePeriodicTableOfElementsGame.Blazor.Web.Services.Audio;

public class AudioPlayer : IAudioPlayer
{
	private readonly IJSInProcessRuntime JSRuntime;

	public AudioPlayer(IJSInProcessRuntime jSRuntime)
	{
		JSRuntime = jSRuntime;
	}

	public void PlayOneShot(AudioSample audioSample)
	{
		JSRuntime.InvokeVoid(
			Consts.Namespace + "playOneShot",
			GetAudioFilename(audioSample));
	}

	public IAudioClip Create(
		AudioSample audioSample,
		IEnumerable<int> eventTimingsMs = null)
	=>
		AudioClip.Create(
			JSRuntime,
			GetAudioFilename(audioSample),
			eventTimingsMs);

	private static string GetAudioFilename(AudioSample audioSample) =>
		audioSample switch
		{
			AudioSample.ElementAppeared => "ElementAppeared.ogg",
			AudioSample.ElementFastMatched1 => "ElementFastMatched1.ogg",
			AudioSample.ElementMismatched => "ElementMismatched.ogg",
			AudioSample.ElementsSong => "ElementsSong.mp3",
			_ => throw new NotImplementedException(audioSample.ToString())
		};
}
