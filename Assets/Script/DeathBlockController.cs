using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class DeathBlockController : MonoBehaviour {

	public DeathBlock deathBlock;
	public Exit exit;
	public float spawnWait;
	public Player player;
	public GameControlle gameControlle;

	public Sprite defaultSprite;
	public Sprite warningSprite;
	public Sprite upSprite;
	public Sprite righeSprite;
	public Sprite deadlySprite;

	public float initialBlocksNumber;
	//public Sprite deadlySprite;
	//private IEnumerator coroutine;
	private float blocksNumber;
	private int currBlockType = 0;


	public void init (int loadedBlockNumber) {
		currBlockType = loadedBlockNumber;
		blocksNumber = initialBlocksNumber;
		spawn ();
	}

	public void spawn () {
		if (currBlockType == 3 || currBlockType == 9 || currBlockType == 18) {
			spawnLevelExit ();
		} else {
			spawnBlock ();
		}
	}

	public void spawnBlock () {
		DeathBlock db = (DeathBlock)Instantiate (deathBlock, transform.position, Quaternion.identity);
		currBlockType += 1;
		db.setType(currBlockType);
		db.gameControlle = gameControlle;
		db.player = player;

		if (currBlockType == 1) {
			db.GetComponent <SpriteRenderer>().sprite = warningSprite;
		}
		if (currBlockType == 2) {
			db.GetComponent <SpriteRenderer>().sprite = upSprite;
		}
		if (currBlockType == 3) {
			db.GetComponent <SpriteRenderer>().sprite = righeSprite;
		}
	}

	public void spawnLevelExit () {
		Obstacle newExit = (Obstacle)Instantiate (exit, transform.position, Quaternion.identity);
		newExit.gameControlle = gameControlle;
		newExit.player = player;
		currBlockType += 1;
	}

	public void stop () {
		blocksNumber = 0;
	}
}
