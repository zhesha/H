using UnityEngine;
using System.Collections;

public class StartGUI : ScrollBG {

	public float destroyTime;

	// Use this for initialization
	void Start () {
		base.Start ();
		Destroy (gameObject, destroyTime);
	}
}
