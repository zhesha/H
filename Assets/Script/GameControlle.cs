﻿using UnityEngine;
using System.Collections;

public class GameControlle : MonoBehaviour {

	public ScrollBG background;
	public ScrollBG parallax;
	public StartGUI startText;
	public GameObject ground;
	public Player player;
	public DeathBlockController deathBlockController;
	public GameObject scoreText;
	public GameObject winText;

	private bool isStarted = false;
	private int doneBlockCount = 0;

	private float cameraSize = 5.4f;
	private float canvasWidth = 1;
	private float canvasHeight = 1;

	void Start() {
		canvasHeight = cameraSize;
		canvasWidth = (float)Screen.width / (float)Screen.height * cameraSize;

		float grounfSize = ground.GetComponent<BoxCollider2D> ().bounds.size.y / 2;
		float groundOffset = canvasHeight * 0.8f;
		ground.transform.position += Vector3.down * (grounfSize + groundOffset);

		float deathBlockSize = 0.2f;
		deathBlockController.transform.position += Vector3.down * (groundOffset - deathBlockSize);
		deathBlockController.transform.position += Vector3.right * (canvasWidth + deathBlockSize);

		float playerSize = 0.3f;
		float playerOffset = playerSize * 1.5f;
		player.transform.position += Vector3.left * (canvasWidth - playerOffset);
		player.transform.position += Vector3.down * (groundOffset - playerSize/2);
		
		float parallaxSize = 1.16f;
		parallax.transform.position += Vector3.down * (groundOffset - parallaxSize / 2);
		
		float scoreHeight = scoreText.GetComponent<MeshRenderer> ().bounds.size.y / 2;
		scoreText.transform.position += Vector3.up * (canvasHeight - scoreHeight);
	}

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
