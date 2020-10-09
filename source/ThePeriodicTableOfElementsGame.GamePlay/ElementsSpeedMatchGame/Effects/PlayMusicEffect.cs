﻿using Fluxor;
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

		public PlayMusicEffect(IAudioPlayer audioPlayer)
		{
			AudioPlayer = audioPlayer ?? throw new ArgumentNullException(nameof(audioPlayer));
		}

		protected override async Task HandleAsync(StartGameAction action, IDispatcher dispatcher)
		{
			TheElementsSong = await AudioPlayer.CreateAsync(AudioSample.ElementsSong)
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
