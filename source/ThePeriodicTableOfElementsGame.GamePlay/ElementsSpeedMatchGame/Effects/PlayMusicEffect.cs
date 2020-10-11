using Fluxor;
using System;
using System.Linq;
using System.Threading.Tasks;
using ThePeriodicTableOfElementsGame.GamePlay.ElementsSpeedMatchGame.Actions;
using ThePeriodicTableOfElementsGame.GamePlay.ElementsSpeedMatchGameFeature.Actions;
using ThePeriodicTableOfElementsGame.GamePlay.Services;
using ThePeriodicTableOfElementsGame.GamePlay.SharedFeature.Actions;

namespace ThePeriodicTableOfElementsGame.GamePlay.ElementsSpeedMatchGameFeature.Effects
{
	public class PlayMusicEffect : Effect<StartGameAction>
	{
		private readonly IAudioPlayer AudioPlayer;
		private IAudioClip TheElementsSong;
		private readonly IState<ElementsSpeedMatchGameState> State;
		private IDispatcher Dispatcher;

		public PlayMusicEffect(
			IAudioPlayer audioPlayer,
			IState<ElementsSpeedMatchGameState> state)
		{
			AudioPlayer = audioPlayer ?? throw new ArgumentNullException(nameof(audioPlayer));
			State = state;
		}

		protected override async Task HandleAsync(StartGameAction action, IDispatcher dispatcher)
		{
			Dispatcher = dispatcher;

			int[] elementTimingsMs =
				State.Value.ElementTimings.Select(x => x.Key).ToArray();

			TheElementsSong = 
				await AudioPlayer.CreateAsync(AudioSample.ElementsSong, elementTimingsMs)
				.ConfigureAwait(false);
			TheElementsSong.TimingEvent += OnTimingEvent;

			await TheElementsSong.PlayAsync().ConfigureAwait(false);
		}

		private void OnTimingEvent(object sender, int eventTimeMs)
		{
			//TODO: PeteM - D1
			System.Diagnostics.Debug.WriteLine("EventTimeMs: " + eventTimeMs);
			Dispatcher.Dispatch(new TimingEventAction(eventTimeMs));
		}

		[EffectMethod]
		public async Task NavigateAwayFromScene(NavigateAction action, IDispatcher dispatcher)
		{
			if (TheElementsSong != null)
			{
				TheElementsSong.TimingEvent -= OnTimingEvent;
				await TheElementsSong.StopAsync().ConfigureAwait(false);
				await TheElementsSong.DisposeAsync().ConfigureAwait(false);
				TheElementsSong = null;
			}
		}
	}
}
