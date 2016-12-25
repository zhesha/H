using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class DeathBlockController : MonoBehaviour {

	public DeathBlock deathBlock;
	public float spawnWait;
	public float blocksNumber;
	private int currBlockType = 0;

	void Start () {
		StartCoroutine (Spawn ());
	}

	IEnumerator Spawn ()
	{
		for (int i = 0; i < blocksNumber; i++)
		{
			
			DeathBlock db = (DeathBlock)Instantiate (deathBlock, transform.position, Quaternion.identity);
			currBlockType += 1;
			db.setType(currBlockType);
			yield return new WaitForSeconds (spawnWait);
		}
	}

	public void stop () {
		blocksNumber = 0;
	}
}
