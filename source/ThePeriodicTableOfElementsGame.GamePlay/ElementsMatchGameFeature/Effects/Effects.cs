﻿using Fluxor;
using System;
using System.Linq;
using System.Threading.Tasks;
using ThePeriodicTableOfElementsGame.GamePlay.ElementsMatchGameFeature.Actions;
using ThePeriodicTableOfElementsGame.GamePlay.Services;
using ThePeriodicTableOfElementsGame.GamePlay.SharedFeature;
using ThePeriodicTableOfElementsGame.GamePlay.SharedFeature.Actions;

namespace ThePeriodicTableOfElementsGame.GamePlay.ElementsMatchGameFeature.Effects
{
	public class Effects
	{
		private IState<SharedState> SharedState;
		private IState<ElementsMatchGameState> GameState;
		private IAudioPlayer AudioPlayer;

		public Effects(
			IState<SharedState> sharedState,
			IState<ElementsMatchGameState> gameState,
			IAudioPlayer audioPlayer)
		{
			SharedState = sharedState ?? throw new ArgumentNullException(nameof(sharedState));
			GameState = gameState ?? throw new ArgumentNullException(nameof(gameState));
			AudioPlayer = audioPlayer ?? throw new ArgumentNullException(nameof(audioPlayer));
		}

		[EffectMethod]
		public async Task StartGame(StartGameAction _, IDispatcher dispatcher)
		{
			dispatcher.Dispatch(new NavigateAction(SceneType.ElementsMatchGame));
			await Task.Delay(500);
			dispatcher.Dispatch(new SetExpectedElementAction(AtomicNumber: GetRandomElementAtomicNumber()));
		}

		[EffectMethod]
		public Task ElementClickedEvent(ElementClickedEvent action, IDispatcher dispatcher)
		{
			if (SharedState.Value.ShowElementsMatchGame)
				dispatcher.Dispatch(new ClickElementAction(action.AtomicNumber));
			return Task.CompletedTask;
		}

		[EffectMethod]
		public Task ClickElement(ClickElementAction action, IDispatcher dispatcher)
		{
			if (!GameState.Value.ElementStates[action.AtomicNumber].Concealed)
				return Task.CompletedTask;

			byte? expectedElement = GameState.Value.ExpectedElement;

			dispatcher.Dispatch(new RevealElementAction(action.AtomicNumber));

			if (expectedElement.HasValue && expectedElement == action.AtomicNumber)
				dispatcher.Dispatch(new ElementMatchedAction(AtomicNumber: action.AtomicNumber));
			else
				dispatcher.Dispatch(new ElementMismatchedAction(
					ClickedAtomicNumber: action.AtomicNumber,
					ExpectedAtomicNumber: GameState.Value.ExpectedElement));

			return Task.CompletedTask;
		}

		[EffectMethod]
		public Task ElementMismatched(ElementMismatchedAction _, IDispatcher dispatcher)
		{
			return AudioPlayer.PlayOneShotAsync(AudioSample.ElementMismatched);
		}

		[EffectMethod]
		public async Task ElementMatched(ElementMatchedAction _, IDispatcher dispatcher)
		{
			await AudioPlayer.PlayOneShotAsync(AudioSample.ElementFastMatched1);
			await Task.Delay(1000);
			dispatcher.Dispatch(new ConcealAllElementsAction());
			await Task.Delay(500);
			if (GameState.Value.AvailableElements.Any())
				dispatcher.Dispatch(new SetExpectedElementAction(AtomicNumber: GetRandomElementAtomicNumber()));
			else
				dispatcher.Dispatch(new StartGameOverSequenceAction());
		}

		[EffectMethod]
		public Task SetExpectedElement(SetExpectedElementAction _, IDispatcher dispatcher) =>
			AudioPlayer.PlayOneShotAsync(AudioSample.ElementAppeared);

		[EffectMethod]
		public async Task StartGameOverSequence(StartGameOverSequenceAction _, IDispatcher dispatcher)
		{
			await Task.Delay(2050);
			dispatcher.Dispatch(new CompleteGameOverAction());
		}

		private byte GetRandomElementAtomicNumber() =>
			GameState.Value.AvailableElements[new Random().Next(GameState.Value.AvailableElements.Length)];
	}
}
