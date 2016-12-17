using UnityEngine;
using System.Collections;

public class DeathBlockController : MonoBehaviour {

	public GameObject deathBlock;
	public float spawnWait;

	void Start () {
		StartCoroutine (Spawn ());
	}

	IEnumerator Spawn ()
	{
		for (int i = 0; i < 10; i++)
		{
			yield return new WaitForSeconds (spawnWait);
			Instantiate (deathBlock, transform.position, Quaternion.identity);

		}
	}
}
