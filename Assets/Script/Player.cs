using UnityEngine;
using System.Collections;

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

	void Start() {
		rb = GetComponent<Rigidbody2D>();
		animator = GetComponent<Animator>();
		animator.SetInteger ("trigger", IDLE);
	}

	void FixedUpdate () {
		if (isAlive && (Input.GetButton("Jump") || Input.touchCount > 0) && onGround) {
			animator.SetInteger ("trigger", JUMP);
			GetComponent<AudioSource> ().PlayOneShot(jumpSound, 1f);
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
			GetComponent<AudioSource> ().PlayOneShot(deathSound, 1f);
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
}
