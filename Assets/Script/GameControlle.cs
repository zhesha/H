using UnityEngine;
using System.Collections;
using System.Runtime.Serialization.Formatters.Binary;
using System.IO;
using System;
using System.Linq;
using System.Collections.Generic;

public class GameControlle : MonoBehaviour {

	public ScrollBG background;
	public ScrollBG parallax;
	public StartGUI startText;
	public GameObject ground;
	public Player player;
	public DeathBlockController deathBlockController;
	public GameObject scoreText;
	public GameObject winText;

	public AudioClip pointSound;
	public AudioClip winSound;
	public AudioClip musicSound;

	public AudioSource musicSource;
	public AudioSource soundSource;

	private bool isStarted = false;
	private int doneBlockCount = 0;

	private float cameraSize = 5.4f;
	private float canvasWidth = 1;
	private float canvasHeight = 1;

	private IEnumerator gameOverCoroutine;

	void Start() {
		canvasHeight = cameraSize;
		canvasWidth = (float)Screen.width / (float)Screen.height * cameraSize;

		float grounfSize = ground.GetComponent<BoxCollider2D> ().bounds.size.y / 2;
		float groundOffset = canvasHeight * 0.5f;
		if (grounfSize * 2 + groundOffset < cameraSize) {
			groundOffset = canvasHeight - grounfSize * 2;
		}
		ground.transform.position += Vector3.down * (grounfSize + groundOffset);

		float deathBlockSize = 0.5f;
		deathBlockController.transform.position += Vector3.down * (groundOffset - deathBlockSize);
		deathBlockController.transform.position += Vector3.right * (canvasWidth + deathBlockSize);

		float playerSize = 1f;
		float playerOffset = playerSize * 1f;
		player.transform.position += Vector3.left * (canvasWidth - playerOffset);
		player.transform.position += Vector3.down * (groundOffset - playerSize/2);
		
		float parallaxSize = 3.09f;
		parallax.transform.position += Vector3.down * (groundOffset - parallaxSize / 2);
		
		float scoreHeight = scoreText.GetComponent<MeshRenderer> ().bounds.size.y / 2;
		scoreText.transform.position += Vector3.up * (canvasHeight - scoreHeight);


		musicSource.PlayOneShot(musicSound, 1f);
	}

	void Update () {
		if (!isStarted && (Input.GetButton("Jump") || Input.touchCount > 0)) {
			Load();
			isStarted = true;
			doneBlockCount = 0;
			scoreText.GetComponent<TextMesh>().text = "Score: 0";
			player.reset ();
			background.init ();
			parallax.init ();
			deathBlockController.init ();
			startText.init ();
			startText.GetComponent<TextMesh>().text = "Tap to jump";
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
	
		if (gameOverCoroutine != null) {
			StopCoroutine (gameOverCoroutine);
		}
		gameOverCoroutine = deferredGameOver ();
		StartCoroutine (gameOverCoroutine);
	}

	IEnumerator deferredGameOver ()
	{
		yield return new WaitForSeconds (1);
		isStarted = false;
	}

	public void doneBlock () {
		doneBlockCount++;
		scoreText.GetComponent<TextMesh>().text = "Score: "+doneBlockCount.ToString();
		soundSource.PlayOneShot(pointSound, 1f);
		Save();
		if (deathBlockController.initialBlocksNumber <= doneBlockCount) {
			soundSource.PlayOneShot(winSound, 1f);
			winText.GetComponent<Renderer>().enabled = true;
			background.stop();
			parallax.stop();
			deathBlockController.stop ();
		}
	}

	public void Save() {
		if (doneBlockCount > Load()) {
			Progress progress = new Progress(doneBlockCount.ToString());
	    	BinaryFormatter bf = new BinaryFormatter();
	    	FileStream file = File.Create (Application.persistentDataPath + "/save.gd");
	    	bf.Serialize(file, progress);
	    	file.Close();
    	}
	}

	public int Load() {
	    if(File.Exists(Application.persistentDataPath + "/save.gd")) {
	        BinaryFormatter bf = new BinaryFormatter();
	        FileStream file = File.Open(Application.persistentDataPath + "/save.gd", FileMode.Open);
	        Progress progress = (Progress)bf.Deserialize(file);
	        file.Close();
	        int numVal = Int32.Parse(progress.bestScore);
	        return numVal;
	    }
	    return 0;
	}
}
