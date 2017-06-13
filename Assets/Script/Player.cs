using UnityEngine;
using System.Collections;
using UnityEngine.EventSystems;

public class Player : MonoBehaviour {

	private Rigidbody2D rb;
	private Animator animator;
	private bool onGround = true;
	private bool isAlive = false;

	public float jumpVelocity;
	public GameControlle gameControlle;
	public AudioClip jumpSound;
	public AudioClip deathSound;

	private int IDLE = 0;
	private int RUN = 1;
	private int JUMP = 2;
	private int DEATH = 3;

	public bool isMute = false;

	void Start() {
		rb = GetComponent<Rigidbody2D>();
		animator = GetComponent<Animator>();
		animator.SetInteger ("trigger", IDLE);
	}

	void Update () {
		if (isAlive && (Input.GetButton("Jump") || Input.touchCount > 0) && onGround && EventSystem.current.currentSelectedGameObject == null) {
			animator.SetInteger ("trigger", JUMP);
			playAudio(jumpSound);
			rb.velocity = new Vector2 (0f, 1f) * jumpVelocity;
		}
	}

	void OnTriggerEnter2D(Collider2D other) {
		if (other.tag != "ground") { return; }

		if (onGround == false && isAlive) {
			animator.SetInteger ("trigger", RUN);
		}
		onGround = true;
	}

	void OnTriggerExit2D(Collider2D other) {
		if (other.tag != "ground") { return; }

		onGround = false;
	}

	public void reset () {
		animator.SetInteger ("trigger", RUN);
		StartCoroutine (deferredReset ());
	}

	IEnumerator deferredReset ()
	{
		yield return new WaitForSeconds (0.3f);
		isAlive = true;
	}

	public void death () {
		if (isAlive) {
			playAudio(deathSound);
			isAlive = false;
			animator.SetInteger ("trigger", DEATH);

			gameControlle.gameOver ();
		}
	}

	public float position () {
		return transform.position.x;
	}

	public void stop () {
		animator.SetInteger ("trigger", IDLE);
	}

	public void playAudio(AudioClip sound) {
		if (!isMute) {
			GetComponent<AudioSource> ().PlayOneShot(sound, 1f);
		}
	}
}
