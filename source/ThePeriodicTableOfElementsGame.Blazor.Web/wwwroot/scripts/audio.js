var ThePeriodicTableOfElementsGame = ThePeriodicTableOfElementsGame || {};
ThePeriodicTableOfElementsGame.audio = {
	playOneShot: function (filename) {
		let audio = new Audio(`audio/${filename}`);
		audio.play();
	},

	nextId: 1,
	audioClips: new Map(),

	create: function (filename) {
		let audio = new Audio(`audio/${filename}`);

		this.nextId++;
		this.audioClips[this.nextId] = audio;
		return this.nextId;
	},

	play: function (id) {
		this.audioClips[id].play();
	},

	pause: function (id) {
		this.audioClips[id].pause();
	},

	dispose: function (id) {
		this.audioClips[id].pause();
		this.audioClips.delete(id);
	}
}