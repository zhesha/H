using UnityEngine;
using System.Collections;

public class StartGUI : ScrollBG {

	public float destroyTime;

	// Use this for initialization
	public void init () {
		base.init ();
		//Destroy (gameObject, destroyTime);
		StartCoroutine (deferredStop ());
	}

	IEnumerator deferredStop ()
	{
		yield return new WaitForSeconds (destroyTime);

		currentSpeed = 0;
	}

	public void reset () {
		StartCoroutine (deferredReset ());
	}

	IEnumerator deferredReset ()
	{
		yield return new WaitForSeconds (1);

		transform.position = startPosition;
	}
}
