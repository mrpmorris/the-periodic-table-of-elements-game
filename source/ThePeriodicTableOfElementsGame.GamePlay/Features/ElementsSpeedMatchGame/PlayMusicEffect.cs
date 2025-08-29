using Fluxor;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ThePeriodicTableOfElementsGame.GamePlay.Features.App.Actions;
using ThePeriodicTableOfElementsGame.GamePlay.Features.ElementsSpeedMatchGame.Actions;
using ThePeriodicTableOfElementsGame.GamePlay.Services;

namespace ThePeriodicTableOfElementsGame.GamePlay.Features.ElementsSpeedMatchGame;

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

	public override Task HandleAsync(StartGameAction action, IDispatcher dispatcher)
	{
		Dispatcher = dispatcher;

		IEnumerable<int> elementTimingsMs =
			State.Value.ElementTimings.Select(x => x.Key - Consts.LeadInTimeMs);

		TheElementsSong = AudioPlayer.Create(AudioSample.ElementsSong, elementTimingsMs);
		TheElementsSong.TimingEvent += OnTimingEvent;

		TheElementsSong.Play();

		return Task.CompletedTask;
	}

	private void OnTimingEvent(object sender, int eventTimeMs)
	{
		Dispatcher.Dispatch(new TimingEventAction(eventTimeMs + Consts.LeadInTimeMs));
	}

	[EffectMethod(typeof(ChangeSceneAction))]
	public Task NavigateAwayFromScene(IDispatcher _)
	{
		if (TheElementsSong != null)
		{
			TheElementsSong.TimingEvent -= OnTimingEvent;
			TheElementsSong.Dispose();
			TheElementsSong = null;
		}
		return Task.CompletedTask;
	}
}
