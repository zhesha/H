using UnityEngine;
using System.Collections;

public class Player : MonoBehaviour {

	private Rigidbody2D rb;
	private bool onGround = false;
	public float jumpVelocity;

	void Start() {
		rb = GetComponent<Rigidbody2D>();
	}

	void FixedUpdate () {
		if (Input.GetButton("Jump") && onGround) {
			rb.velocity = new Vector2 (0f, 1f) * jumpVelocity;
		}
	}

	void OnTriggerEnter2D(Collider2D other) {
		onGround = true;
	}

	void OnTriggerExit2D(Collider2D other) {
		onGround = false;
	}
}
