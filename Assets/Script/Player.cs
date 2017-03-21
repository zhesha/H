﻿using UnityEngine;
using System.Collections;

public class Player : MonoBehaviour {

	private Rigidbody2D rb;
	private Animator animator;
	private bool onGround = false;
	private bool isAlive = false;

	public float jumpVelocity;
	public GameControlle gameControlle;

	void Start() {
		rb = GetComponent<Rigidbody2D>();
		animator = GetComponent<Animator>();
	}

	void FixedUpdate () {
		if (isAlive && Input.GetButton("Jump") && onGround) {
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
		isAlive = false;
		animator.SetBool("dead", true);

		int deathHash = Animator.StringToHash("death");
		animator.SetTrigger (deathHash);

		gameControlle.gameOver ();
	}

	public float position () {
		Debug.logger.Log(transform.localPosition);
		return transform.position.x;
	}
}
