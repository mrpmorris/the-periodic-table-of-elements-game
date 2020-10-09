using Microsoft.JSInterop;
using System.Threading.Tasks;
using ThePeriodicTableOfElementsGame.GamePlay.Services;

namespace ThePeriodicTableOfElementsGame.Blazor.Web.Services.Audio
{
	public class AudioClip: IAudioClip
	{
		private readonly IJSRuntime JSRuntime;
		private readonly int AudioId;

		public AudioClip(IJSRuntime jSRuntime, int audioId)
		{
			JSRuntime = jSRuntime;
			AudioId = audioId;
		}

		public ValueTask<float> GetCurrentTime() =>
			JSRuntime.InvokeAsync<float>(Consts.GetCurrentTime, AudioId);

		public ValueTask PlayAsync() =>
			JSRuntime.InvokeVoidAsync(Consts.Play, AudioId);

		public ValueTask StopAsync() =>
			JSRuntime.InvokeVoidAsync(Consts.Pause, AudioId);

		public ValueTask DisposeAsync() =>
			JSRuntime.InvokeVoidAsync(Consts.Dispose, AudioId);
	}
}
