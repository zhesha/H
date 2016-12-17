using UnityEngine;
using System.Collections;

public class DeathBlockController : MonoBehaviour {

	public DeathBlock deathBlock;
	public float spawnWait;
	private int currBlockType = 0;

	void Start () {
		StartCoroutine (Spawn ());
	}

	IEnumerator Spawn ()
	{
		for (int i = 0; i < 5; i++)
		{
			yield return new WaitForSeconds (spawnWait);
			DeathBlock db = (DeathBlock)Instantiate (deathBlock, transform.position, Quaternion.identity);
			currBlockType += 1;
			db.setType(currBlockType);
		}
	}
}
