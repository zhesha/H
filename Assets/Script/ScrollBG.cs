using UnityEngine;
using System.Collections;

public class ScrollBG : MonoBehaviour {

	public float speed;
	public float size;

	protected float currentSpeed = 0;
	protected Vector3 startPosition;
	private float time;
	private float stopTime;

	// Use this for initialization
	public void init () {
		currentSpeed = speed;
		if (startPosition == Vector3.zero) {
			startPosition = transform.position;
		}
		time = Time.time;
	}

	public void stop () {
		if (currentSpeed != 0) {
			stopTime = stopTime + Time.time - time;
		}
		currentSpeed = 0;
	}
	
	// Update is called once per frame
	void FixedUpdate () {
		if (currentSpeed != 0) {
			float t = stopTime + Time.time - time;
			float newPosition = Mathf.Repeat (t * speed, size);
			transform.position = startPosition + Vector3.left * newPosition;
		}
	}
}
