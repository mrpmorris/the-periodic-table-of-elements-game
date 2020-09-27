var ThePeriodicTableOfElementsGame = ThePeriodicTableOfElementsGame || {};
ThePeriodicTableOfElementsGame.audio = {
	playOneShot: function (filename) {
		let audio = new Audio(`audio/${filename}`);
		audio.play();
	},

	create: function (filename) {
		let audio = new Audio(`audio/${filename}`);
		audio.getCurrentTime = function () {
			return audio.currentTime;
		}
		return audio;
	}
}