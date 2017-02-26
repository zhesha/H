using UnityEngine;
using System.Collections;

public class StartGUI : ScrollBG {

	public float destroyTime;

	// Use this for initialization
	public void init () {
		base.init ();
		Destroy (gameObject, destroyTime);
	}
}
