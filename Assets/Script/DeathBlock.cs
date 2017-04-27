using UnityEngine;
using System.Collections;

public class DeathBlock : MonoBehaviour {

	public float speed;
	public float lifetime;
	public Player player;
	public Sprite deadlySprite;
	public int type = 0;
	public GameControlle gameControlle;

	private bool isDone = false;
	private float shiftSize = 1.2f;

	// Update is called once per frame
	void Update () {
		Destroy (gameObject, lifetime);
		transform.position = transform.position + Vector3.left * speed;
		checkDone ();
		if (type != 0 && triggerCondition()) {
			action ();
		}

	}

	void checkDone () {
		if (!isDone && transform.position.x - player.transform.position.x < -1f) {
			isDone = true;
			gameControlle.doneBlock ();
		}
	}

	bool triggerCondition () {
		if (type == 4 && transform.position.x - player.transform.position.x < 2.5f) {
			return true;
		}

		if (transform.position.x - player.transform.position.x < 2) {
			return true;
		}
		return false;
	}

	void action () {
		GetComponent <SpriteRenderer>().sprite = deadlySprite;
		if (type == 1) {
			type = 0;
		}
		if (type == 2) {
			type = 0;
			transform.position = transform.position + Vector3.up * shiftSize;
		}
		if (type == 3) {
			type = 0;
			transform.position = transform.position + Vector3.down * shiftSize;
		}
		if (type == 4) {
			type = 0;
			Debug.logger.Log (123);
			transform.position = transform.position + Vector3.left * shiftSize;
		}
		if (type == 5) {
			type = 0;
			transform.position = transform.position + Vector3.right * shiftSize;
		}
		if (type == 6) {
			type = 0;
		}
		if (type == 7) {
			type = 0;
			transform.position = transform.position + Vector3.up * shiftSize;
		}
		if (type == 8) {
			type = 2;
			transform.position = transform.position + Vector3.right * shiftSize;
		}
	}

	public void setType (int initType) {
		type = initType;
		if (initType == 3) {
			transform.position = transform.position + Vector3.up * shiftSize;
		}
		if (initType == 7) {
			transform.position = transform.position + Vector3.down * shiftSize;
		}
	}

	void OnTriggerEnter2D(Collider2D other) {
		if (other.tag == "Player") {
			Player player = (Player)other.gameObject.GetComponent(typeof(Player));
			player.death ();
		}
	}
}
