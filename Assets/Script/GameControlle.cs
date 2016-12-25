using UnityEngine;
using System.Collections;

public class GameControlle : MonoBehaviour {

	public ScrollBG background;
	public ScrollBG parallax;
	public DeathBlockController deathBlockController;

	public void gameOver () {
		background.speed = 0;
		parallax.speed = 0;
		deathBlockController.stop ();

		GameObject[] deathBlocks = GameObject.FindGameObjectsWithTag("deathBlock");

		foreach (GameObject deathBlock in deathBlocks) {
			DeathBlock db = (DeathBlock)deathBlock.GetComponent(typeof(DeathBlock));
			db.speed = 0;
			Destroy (deathBlock, 1);
		}
	}
}
