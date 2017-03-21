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
		if (!isDone && transform.position.x - player.transform.position.x < 1.2f) {
			isDone = true;
			gameControlle.doneBlock ();
		}
	}

	bool triggerCondition () {
		if (type == 4 && transform.position.x - player.transform.position.x < 3.5f) {
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
			transform.position = transform.position + Vector3.up * 0.5f;
		}
		if (type == 3) {
			type = 0;
			transform.position = transform.position + Vector3.down * 0.5f;
		}
		if (type == 4) {
			type = 0;
			transform.position = transform.position + Vector3.left * 0.5f;
		}
		if (type == 5) {
			type = 0;
			transform.position = transform.position + Vector3.right * 0.5f;
		}
		if (type == 6) {
			type = 0;
		}
		if (type == 7) {
			type = 0;
			transform.position = transform.position + Vector3.up * 0.5f;
		}
		if (type == 8) {
			type = 2;
			transform.position = transform.position + Vector3.right * 0.5f;
		}
	}

	public void setType (int initType) {
		type = initType;
		if (initType == 3) {
			transform.position = transform.position + Vector3.up * 0.5f;
		}
		if (initType == 7) {
			transform.position = transform.position + Vector3.down * 0.5f;
		}
	}

	void OnTriggerEnter2D(Collider2D other) {
		if (other.tag == "Player") {
			Player player = (Player)other.gameObject.GetComponent(typeof(Player));
			player.death ();
		}
	}
}
