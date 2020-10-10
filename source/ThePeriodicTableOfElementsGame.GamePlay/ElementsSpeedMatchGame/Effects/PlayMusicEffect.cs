using Fluxor;
using System;
using System.Threading.Tasks;
using ThePeriodicTableOfElementsGame.GamePlay.ElementsSpeedMatchGameFeature.Actions;
using ThePeriodicTableOfElementsGame.GamePlay.Services;
using ThePeriodicTableOfElementsGame.GamePlay.SharedFeature.Actions;

namespace ThePeriodicTableOfElementsGame.GamePlay.ElementsSpeedMatchGameFeature.Effects
{
	public class PlayMusicEffect : Effect<StartGameAction>
	{
		private IAudioPlayer AudioPlayer;
		private IAudioClip TheElementsSong;
		private static readonly int[] EventTimingsMs = new int[] 
		{
			1_000,
			2_000,
			3_000,
			5_000,
			8_000,
			13_000,
			21_000
		};

		public PlayMusicEffect(IAudioPlayer audioPlayer)
		{
			AudioPlayer = audioPlayer ?? throw new ArgumentNullException(nameof(audioPlayer));
		}

		protected override async Task HandleAsync(StartGameAction action, IDispatcher dispatcher)
		{

			TheElementsSong = 
				await AudioPlayer.CreateAsync(AudioSample.ElementsSong, EventTimingsMs)
				.ConfigureAwait(false);

			await TheElementsSong.PlayAsync().ConfigureAwait(false);
		}

		[EffectMethod]
		public async Task NavigateAwayFromScene(NavigateAction action, IDispatcher dispatcher)
		{
			if (TheElementsSong != null)
			{
				await TheElementsSong.StopAsync().ConfigureAwait(false);
				await TheElementsSong.DisposeAsync().ConfigureAwait(false);
				TheElementsSong = null;
			}
		}
	}
}
