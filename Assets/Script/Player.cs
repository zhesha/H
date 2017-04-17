using UnityEngine;
using System.Collections;

public class Player : MonoBehaviour {

	private Rigidbody2D rb;
	private Animator animator;
	private bool onGround = false;
	private bool isAlive = false;

	public float jumpVelocity;
	public GameControlle gameControlle;
	public AudioClip jumpSound;
	public AudioClip deathSound;

	void Start() {
		rb = GetComponent<Rigidbody2D>();
		animator = GetComponent<Animator>();
	}

	void FixedUpdate () {
		if (isAlive && (Input.GetButton("Jump") || Input.touchCount > 0) && onGround) {
			GetComponent<AudioSource> ().PlayOneShot(jumpSound, 1f);
			rb.velocity = new Vector2 (0f, 1f) * jumpVelocity;
		}
	}

	void OnTriggerEnter2D(Collider2D other) {
		onGround = true;
	}

	void OnTriggerExit2D(Collider2D other) {
		onGround = false;
	}

	public void reset () {
		animator.SetBool("dead", false);

		int deathHash = Animator.StringToHash("DudeAnimation");
		animator.SetTrigger (deathHash);

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
			animator.SetBool ("dead", true);

			int deathHash = Animator.StringToHash ("death");
			animator.SetTrigger (deathHash);

			gameControlle.gameOver ();
		}
	}

	public float position () {
		return transform.position.x;
	}
}
