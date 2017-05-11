﻿using UnityEngine;
using System.Collections;

public class DeathBlock : Obstacle {

	public Sprite deadlySprite;
	public int type = 0;

	private float shiftSize = 1.2f;

	new void Update () {
		base.Update();
		if (type != 0 && triggerCondition()) {
			action ();
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
			transform.position = transform.position + Vector3.right * shiftSize;
		}
			
		if (type == 5) {
			type = 0;
		}
		if (type == 6) {
			type = 0;
			transform.position = transform.position + Vector3.down * shiftSize;
		}
		if (type == 7) {
			type = 0;
			transform.position = transform.position + Vector3.up * shiftSize;
		}
		if (type == 8) {
			type = 0;
			transform.position = transform.position + Vector3.left * shiftSize;
		}
		if (type == 9) {
			type = 0;
			transform.position = transform.position + Vector3.right * shiftSize;
		}
	}

	public void setType (int initType) {
		type = initType;
		if (initType == 6) {
			transform.position = transform.position + Vector3.up * shiftSize;
		}
	}

	void OnTriggerEnter2D(Collider2D other) {
		if (other.tag == "Player") {
			Player player = (Player)other.gameObject.GetComponent(typeof(Player));
			player.death ();
		}
	}
}
