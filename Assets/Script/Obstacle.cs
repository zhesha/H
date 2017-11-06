using UnityEngine;
using System.Collections;

public class Obstacle : MonoBehaviour {
	public float speed;
	public float lifetime;
	public Player player;
	public GameControlle gameControlle;

	protected bool isDone = false;

	void Start () {
		Destroy (gameObject, lifetime);
	}

	public void FixedUpdate () {
		transform.position = transform.position + Vector3.left * speed;
		checkDone ();
	}

	protected virtual void checkDone () {
		if (!isDone && transform.position.x - player.transform.position.x < -1f) {
			isDone = true;
			gameControlle.doneBlock ();
		}
	}
}
