var ThePeriodicTableOfElementsGame = ThePeriodicTableOfElementsGame || {};
ThePeriodicTableOfElementsGame.audio = {

	_nextId: 1,
	_audioClips: new Map(),

	playOneShot: function (filename) {
		let audio = new Audio(`audio/${filename}`);
		audio.play();
	},

	create: function (filename, eventTimings) {
		let audio = new AudioClip(filename, eventTimings);
		let currentAudioId = this._nextId++;
		this._audioClips[currentAudioId] = audio;
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
	constructor(filename, eventTimings) {
		this._audio = new Audio(`audio/${filename}`);
		this._filename = filename;
		this._eventTimings = eventTimings || [];
		this._timeoutId = null;
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
		let nextEventTimeSeconds = this._eventTimings[0] / 1000;
		let audioTime = this._audio.currentTime;
		if (audioTime < nextEventTimeSeconds) {
			this._setTimeoutForNextEvent();
			return;
		}

		// Otherwise, trigger the event
		while (this._eventTimings.length > 0 && this._eventTimings[0] <= audioTime) {
			console.log(`At ${this._audio.currentTime}: Event = ${this._eventTimings[0]}`);
			this._eventTimings.splice(0, 1);
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
