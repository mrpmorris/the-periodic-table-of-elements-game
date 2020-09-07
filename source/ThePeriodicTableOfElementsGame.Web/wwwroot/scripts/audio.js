var ThePeriodicTableOfElementsGame = ThePeriodicTableOfElementsGame || {};
ThePeriodicTableOfElementsGame.audio = {
	playOneShot: function (filename) {
		var audio = new Audio(`audio/${filename}`);
		audio.play();
	}
}