using UnityEngine;
using System.Collections;

public class GameControlle : MonoBehaviour {

	public ScrollBG background;
	public ScrollBG parallax;
	public StartGUI startText;
	public DeathBlockController deathBlockController;

	private bool isStarted = false;

	void FixedUpdate () {
		if (!isStarted && Input.GetButton("Jump")) {
			isStarted = true;
			background.init ();
			parallax.init ();
			deathBlockController.init ();
			startText.init ();
		}
	}

	public void gameOver () {
		background.stop();
		parallax.stop();
		deathBlockController.stop ();

		GameObject[] deathBlocks = GameObject.FindGameObjectsWithTag("deathBlock");

		foreach (GameObject deathBlock in deathBlocks) {
			DeathBlock db = (DeathBlock)deathBlock.GetComponent(typeof(DeathBlock));
			db.speed = 0;
			Destroy (deathBlock, 1);
		}
	}
}
