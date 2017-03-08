using UnityEngine;
using System.Collections;

public class GameControlle : MonoBehaviour {

	public ScrollBG background;
	public ScrollBG parallax;
	public StartGUI startText;
	public Player player;
	public DeathBlockController deathBlockController;
	public GameObject scoreText;
	public GameObject winText;

	private bool isStarted = false;
	private int doneBlockCount = 0;

	void Update () {
		if (!isStarted && Input.GetButton("Jump")) {
			
			isStarted = true;
			doneBlockCount = 0;
			scoreText.GetComponent<TextMesh>().text = "Score: 0";
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

	public void doneBlock () {
		doneBlockCount++;
		scoreText.GetComponent<TextMesh>().text = "Score: "+doneBlockCount.ToString();
		if (deathBlockController.initialBlocksNumber <= doneBlockCount) {
			winText.GetComponent<Renderer>().enabled = true;
			background.stop();
			parallax.stop();
			deathBlockController.stop ();
		}
	}
}
