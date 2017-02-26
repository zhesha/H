using UnityEngine;
using System.Collections;

public class ScrollBG : MonoBehaviour {

	public float speed;
	public float size;

	private float currentSpeed = 0;
	private Vector3 startPosition;
	private float time;

	// Use this for initialization
	public void init () {
		currentSpeed = speed;
		startPosition = transform.position;
		time = Time.time;
	}

	public void stop () {
		currentSpeed = 0;
	}
	
	// Update is called once per frame
	void Update () {
		if (currentSpeed != 0) {
			float newPosition = Mathf.Repeat (-(time - Time.time) * speed, size);
			transform.position = startPosition + Vector3.left * newPosition;
		}
	}
}
