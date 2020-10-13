using Fluxor;
using System;
using System.Linq;
using System.Threading.Tasks;
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

		protected override Task HandleAsync(StartGameAction action, IDispatcher dispatcher)
		{
			Dispatcher = dispatcher;

			int[] elementTimingsMs =
				State.Value.ElementTimings.Select(x => x.Key - Consts.LeadInTimeMs).ToArray();

			TheElementsSong = AudioPlayer.Create(AudioSample.ElementsSong, elementTimingsMs);
			TheElementsSong.TimingEvent += OnTimingEvent;

			TheElementsSong.Play();

			return Task.CompletedTask;
		}

		private void OnTimingEvent(object sender, int eventTimeMs)
		{
			Dispatcher.Dispatch(new TimingEventAction(eventTimeMs + Consts.LeadInTimeMs));
		}

		[EffectMethod]
		public Task NavigateAwayFromScene(NavigateAction action, IDispatcher dispatcher)
		{
			if (TheElementsSong != null && action.Scene != SharedFeature.SceneType.ElementSpeedMatchGame)
			{
				TheElementsSong.TimingEvent -= OnTimingEvent;
				TheElementsSong.Dispose();
				TheElementsSong = null;
			}
			return Task.CompletedTask;
		}
	}
}
