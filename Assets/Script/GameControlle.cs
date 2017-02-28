using UnityEngine;
using System.Collections;

public class GameControlle : MonoBehaviour {

	public ScrollBG background;
	public ScrollBG parallax;
	public StartGUI startText;
	public Player player;
	public DeathBlockController deathBlockController;

	private bool isStarted = false;

	void Update () {
		if (!isStarted && Input.GetButton("Jump")) {
			Debug.logger.Log (11);
			isStarted = true;
			player.reset ();
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
		startText.reset ();

		GameObject[] deathBlocks = GameObject.FindGameObjectsWithTag("deathBlock");

		foreach (GameObject deathBlock in deathBlocks) {
			DeathBlock db = (DeathBlock)deathBlock.GetComponent(typeof(DeathBlock));
			db.speed = 0;
			Destroy (deathBlock, 1);
		}


		StartCoroutine (deferredGameOver ());
	}

	IEnumerator deferredGameOver ()
	{
		yield return new WaitForSeconds (1);

		isStarted = false;
	}
}
