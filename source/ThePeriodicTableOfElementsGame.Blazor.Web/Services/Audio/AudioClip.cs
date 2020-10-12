using Microsoft.JSInterop;
using System;
using ThePeriodicTableOfElementsGame.GamePlay.Services;

namespace ThePeriodicTableOfElementsGame.Blazor.Web.Services.Audio
{
	public sealed class AudioClip: IAudioClip
	{
		private readonly IJSInProcessRuntime JSRuntime;
		private int AudioId;
		private DotNetObjectReference<AudioClip> ObjRef;
		private bool IsDisposed;

		public event EventHandler<int> TimingEvent;

		private AudioClip(IJSInProcessRuntime jsRuntime)
		{
			JSRuntime = jsRuntime;
		}

		public static IAudioClip Create(
			IJSInProcessRuntime jsRuntime,
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
			int audioId = jsRuntime.Invoke<int>(
				Consts.Namespace + "create",
				objRef,
				filename,
				eventTimingsMs);

			audio.Initialize(audioId, objRef);

			return audio;
		}

		public void Play()
		{
			JSRuntime.InvokeVoid(Consts.Play, AudioId);
		}

		public void Stop()
		{
			JSRuntime.InvokeVoid(Consts.Pause, AudioId);
		}

		public void Dispose()
		{
			Dispose(disposing: true);
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

		private void Dispose(bool disposing)
		{
			if (!IsDisposed)
			{
				IsDisposed = true;
				if (disposing)
				{
					ObjRef.Dispose();
					JSRuntime.InvokeVoid(Consts.Dispose, AudioId);
				}
			}
		}
	}
}
