using UnityEngine;
using System.Collections;

public class StartGUI : ScrollBG {

	public float destroyTime;

	private IEnumerator stopCoroutine;

	// Use this for initialization
	public void init () {
		base.init ();
		stopCoroutine = deferredStop ();
		StartCoroutine (stopCoroutine);
	}

	IEnumerator deferredStop ()
	{
		yield return new WaitForSeconds (destroyTime);

		currentSpeed = 0;
	}

	public void reset () {
		StopCoroutine (stopCoroutine);
		StartCoroutine (deferredReset ());
	}

	IEnumerator deferredReset ()
	{
		yield return new WaitForSeconds (1);
		currentSpeed = 0;
		transform.position = startPosition;
	}
}
