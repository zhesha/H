using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class DeathBlockController : MonoBehaviour {

	public DeathBlock deathBlock;
	public float spawnWait;
	public float initialBlocksNumber;
	public Player player;
	private float blocksNumber;
	private int currBlockType = 0;
	public GameControlle gameControlle;

	private IEnumerator coroutine;


	public void init () {
		currBlockType = 0;
		blocksNumber = initialBlocksNumber;
		//StopCoroutine (coroutine);
		coroutine = Spawn ();
		StartCoroutine (coroutine);
	}

	IEnumerator Spawn ()
	{
		for (int i = 0; i < blocksNumber; i++)
		{
			DeathBlock db = (DeathBlock)Instantiate (deathBlock, transform.position, Quaternion.identity);
			currBlockType += 1;
			db.setType(currBlockType);
			db.gameControlle = gameControlle;
			db.player = player;
			yield return new WaitForSeconds (spawnWait);
		}
	}

	public void stop () {
		StopCoroutine (coroutine);
		blocksNumber = 0;
	}
}
