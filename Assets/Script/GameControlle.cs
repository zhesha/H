using UnityEngine;
using System.Collections;
using System.Runtime.Serialization.Formatters.Binary;
using System.IO;
using System;
using System.Linq;
using System.Collections.Generic;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class GameControlle : MonoBehaviour {

	public ScrollBG background;
	public ScrollBG parallax;
	public StartGUI startText;
	public GameObject ground;
	public Player player;
	public DeathBlockController deathBlockController;
	public GameObject scoreWrapper;
	public GameObject scoreText;
	public StartGUI highscore;
	public StartGUI highscoreWrapper;
	public GameObject winText;
	public GameObject infoScreen;
	public GameObject confirmationScreen;

	public AudioClip pointSound;
	public AudioClip winSound;
	public AudioClip musicSound;

	public AudioSource musicSource;
	public AudioSource soundSource;

	public Button muteButton;
	public Sprite muteOnSprite;
	public Sprite muteOffSprite;

	private bool isStarted = false;
	private int doneBlockCount = 0;

	private float cameraSize = 5.4f;
	private float canvasWidth = 1;
	private float canvasHeight = 1;

	private bool isMute = false;

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
		float deathBlockOffset = 1.5f;
		deathBlockController.transform.position += Vector3.down * (groundOffset - deathBlockSize);
		deathBlockController.transform.position += Vector3.right * (canvasWidth + deathBlockOffset);

		float playerSize = 1f;
		float playerOffset = playerSize * 1f;
		player.transform.position += Vector3.left * (canvasWidth - playerOffset);
		player.transform.position += Vector3.down * (groundOffset - playerSize/2);
		
		float parallaxSize = 3.09f;
		parallax.transform.position += Vector3.down * (groundOffset - parallaxSize / 2);
		
		//float scoreHeight = scoreText.GetComponent<MeshRenderer> ().bounds.size.y / 2;
		float scoreHeight = scoreWrapper.GetComponent<SpriteRenderer>().bounds.size.y / 2;
		//scoreText.transform.position += Vector3.up * (canvasHeight - scoreHeight);
		scoreWrapper.transform.position += Vector3.up * (canvasHeight - scoreHeight);

		float startTextHeight = startText.GetComponent<SpriteRenderer> ().bounds.size.y / 2;
		float highscoreWidth = highscoreWrapper.GetComponent<SpriteRenderer> ().bounds.size.x;
		highscoreWrapper.transform.position += Vector3.down * (startTextHeight * 2f);
		highscoreWrapper.transform.position += Vector3.right * ((canvasHeight / 1.5f) - highscoreWidth);
		if (Load () < 0) {
			highscore.GetComponent<TextMesh> ().text = 0.ToString ();
		} else {
			highscore.GetComponent<TextMesh> ().text = Load ().ToString ();
		}

		float backgroundWidth = 2048f / 2 / 130;
		background.transform.position += Vector3.right * (backgroundWidth - canvasWidth);

		musicSource.PlayOneShot(musicSound, 1f);
		if (Load () == -1) {
			Save ();
		}
	}

	void FixedUpdate () {

		if (!isStarted && (Input.GetButton("Jump") || Input.touchCount > 0) && EventSystem.current.currentSelectedGameObject == null) {
			Load();
			isStarted = true;
			doneBlockCount = checkpoint();
			scoreText.GetComponent<TextMesh>().text = checkpoint().ToString();
			player.reset ();
			background.init ();
			parallax.init ();
			deathBlockController.init (checkpoint());
			startText.init ();
			highscoreWrapper.init ();
			//startText.GetComponent<TextMesh>().text = "Tap to jump";
		}
	}

	public void gameOver () {
		background.stop();
		parallax.stop();
		deathBlockController.stop ();
		startText.reset ();
		highscoreWrapper.reset ();

		highscore.GetComponent<TextMesh>().text = Load().ToString();

		GameObject[] deathBlocks = GameObject.FindGameObjectsWithTag("deathBlock");

		foreach (GameObject deathBlock in deathBlocks) {
			Obstacle db = (Obstacle)deathBlock.GetComponent(typeof(Obstacle));
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

	public void win () {
		playAudio(winSound);
		winText.GetComponent<SpriteRenderer>().enabled = true;
		background.stop();
		parallax.stop();
		deathBlockController.stop ();
		player.stop ();
	}

	public void doneBlock () {
		
		doneBlockCount++;
		scoreText.GetComponent<TextMesh>().text = doneBlockCount.ToString();
		playAudio(pointSound);
		deathBlockController.spawn();
		processProgress();
	}

	public void doneExit () {
		doneBlockCount++;
		scoreText.GetComponent<TextMesh>().text = doneBlockCount.ToString();
		playAudio(pointSound);
		processProgress();

		if (deathBlockController.initialBlocksNumber <= doneBlockCount) {
			win ();
		} else {
			deathBlockController.spawn ();
		}
	}

	public void processProgress() {
		if (doneBlockCount > Load()) {
			Save ();
    	}
	}

	public void Save() {
		Progress progress = new Progress(doneBlockCount.ToString());
		BinaryFormatter bf = new BinaryFormatter();
		FileStream file = File.Create (Application.persistentDataPath + "/save.gd");
		bf.Serialize(file, progress);
		file.Close();
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
	    return -1;
	}

	public int checkpoint() {
		int hiscore = Load ();
		if (hiscore >= 10) {
			return 10;
		}
		if (hiscore >= 4) {
			return 4;
		}
		return 0;
	}

	public void onMutePressed() {
		if (isMute) {
			musicSource.PlayOneShot(musicSound, 1f);
			isMute = false;
			muteButton.image.sprite = muteOnSprite;
		} else {
			musicSource.Stop ();
			isMute = true;
			muteButton.image.sprite = muteOffSprite;
		}
		player.isMute = isMute;
	}

	public void onAskRestart() {
		confirmationScreen.SetActive (true);
	}

	public void onContinue() {
		confirmationScreen.SetActive (false);
	}

	public void onRestartPressed() {
		confirmationScreen.SetActive (false);
		doneBlockCount = 0;
		Save ();
		scoreText.GetComponent<TextMesh>().text = 0.ToString();
		highscore.GetComponent<TextMesh>().text = 0.ToString();
		winText.GetComponent<SpriteRenderer>().enabled = false;
		player.death ();
	}

	public void onInfoPressed() {
		infoScreen.SetActive (true);
	}

	public void playAudio(AudioClip sound) {
		if (!isMute) {
			soundSource.PlayOneShot(sound, 1f);
		}
	}

	public void closeInfo() {
		infoScreen.SetActive (false);
	}

	public void sendEmail() {
		string email = "savzhe@gmail.com";
		string subject = "Subject";
		Application.OpenURL("mailto:" + email + "?subject=" + subject);
	}
}
