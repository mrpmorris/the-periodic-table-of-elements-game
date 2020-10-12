var ThePeriodicTableOfElementsGame = ThePeriodicTableOfElementsGame || {};
ThePeriodicTableOfElementsGame.audio = {

	_nextId: 1,
	_audioClips: new Map(),

	playOneShot: function (filename) {
		let audio = new Audio(`audio/${filename}`);
		audio.play();
	},

	create: function (dotNetObjRef, filename, eventTimings) {
		let audio = new AudioClip(dotNetObjRef, filename, eventTimings);
		let currentAudioId = this._nextId++;
		this._audioClips[currentAudioId] = audio;
		this._dotNetObjRef = dotNetObjRef;
		return currentAudioId;
	},

	pause: function (id) {
		this._audioClips[id].pause();
	},

	play: function (id) {
		this._audioClips[id].play();
	},

	dispose: function (id) {
		this._audioClips[id].dispose();
		this._audioClips.delete(id);
	}
}

class AudioClip {
	constructor(dotNetObjRef, filename, eventTimings) {
		this._audio = new Audio(`audio/${filename}`);
		this._filename = filename;
		this._eventTimings = eventTimings || [];
		this._timeoutId = null;
		this._dotNetObjRef = dotNetObjRef;
	}

	play() {
		if (!this._audio.paused) {
			return;
		}
		this._setTimeoutForNextEvent();
		this._audio.play();
	}

	pause() {
		if (this._audio.paused) {
			return;
		}
		this._clearTimeout();
		this._audio.pause();
	}

	dispose() {
		this.pause();
	}

	_setTimeoutForNextEvent() {
		let _this = this;

		this._clearTimeout(this);
		if (this._eventTimings.length > 0) {
			let delayMs = this._eventTimings[0] - (this._audio.currentTime * 1000);
			this._timeoutId = setTimeout(() => { _this._triggerCurrentEvent(); }, delayMs);
		}
	}

	_triggerCurrentEvent() {
		this._clearTimeout();

		// If we are too early, wait
		let audioTimeMs = this._audio.currentTime * 1000;
		if (audioTimeMs < this._eventTimings[0]) {
			this._setTimeoutForNextEvent();
			return;
		}

		// Otherwise, trigger the event
		while (this._eventTimings.length > 0 && this._eventTimings[0] <= audioTimeMs) {
			let eventTimeMs = this._eventTimings.splice(0, 1)[0];
			console.log(`${eventTimeMs} at ${this._audio.currentTime * 1000}`);
			this._dotNetObjRef.invokeMethod(`TriggerTimingEvent`, eventTimeMs);
		}
		this._setTimeoutForNextEvent(this);
	}

	_clearTimeout() {
		if (this._timeoutId) {
			clearTimeout(this._timeoutId);
			this._timeoutId = null;
		}
	}
}
