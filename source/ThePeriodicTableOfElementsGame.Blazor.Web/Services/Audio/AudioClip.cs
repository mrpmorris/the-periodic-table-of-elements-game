using Microsoft.JSInterop;
using System;
using System.Threading.Tasks;
using ThePeriodicTableOfElementsGame.GamePlay.Services;

namespace ThePeriodicTableOfElementsGame.Blazor.Web.Services.Audio
{
	public class AudioClip: IAudioClip
	{
		private readonly IJSRuntime JSRuntime;
		private int AudioId;
		private DotNetObjectReference<AudioClip> ObjRef;

		public event EventHandler<int> TimingEvent;

		private AudioClip(IJSRuntime jsRuntime)
		{
			JSRuntime = jsRuntime;
		}

		public static async Task<IAudioClip> CreateAsync(
			IJSRuntime jsRuntime,
			string filename,
			int[] eventTimingsMs)
		{
			if (jsRuntime == null)
				throw new ArgumentNullException(nameof(jsRuntime));
			if (filename == null)
				throw new ArgumentNullException(nameof(filename));

			var audio = new AudioClip(jsRuntime);
			var objRef = DotNetObjectReference.Create<AudioClip>(audio);

			eventTimingsMs = eventTimingsMs ?? Array.Empty<int>();
			int audioId = await jsRuntime.InvokeAsync<int>(
				Consts.Namespace + "create",
				objRef,
				filename,
				eventTimingsMs);

			audio.Initialize(audioId, objRef);

			return audio;
		}


		public ValueTask PlayAsync() =>
			JSRuntime.InvokeVoidAsync(Consts.Play, AudioId);

		public ValueTask StopAsync() =>
			JSRuntime.InvokeVoidAsync(Consts.Pause, AudioId);

		public ValueTask DisposeAsync()
		{
			ObjRef.Dispose();
			return JSRuntime.InvokeVoidAsync(Consts.Dispose, AudioId);
		}

		[JSInvokable("TriggerTimingEvent")]
		public void TriggerTimingEvent(int eventTimeMs)
		{
			TimingEvent?.Invoke(this, eventTimeMs);
		}

		private void Initialize(
			int audioId,
			DotNetObjectReference<AudioClip> objRef)
		{
			AudioId = audioId;
			ObjRef = objRef;
		}
	}
}
