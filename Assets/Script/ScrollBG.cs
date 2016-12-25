using UnityEngine;
using System.Collections;

public class ScrollBG : MonoBehaviour {

	public float speed;
	public float size;
	public float destroyTime;

	private Vector3 startPosition;

	// Use this for initialization
	void Start () {
		startPosition = transform.position;
		if (destroyTime != 0) {
			Destroy (gameObject, destroyTime);
		}
	}
	
	// Update is called once per frame
	void Update () {
		if (speed != 0) {
			float newPosition = Mathf.Repeat (Time.time * speed, size);
			transform.position = startPosition + Vector3.left * newPosition;
		}
	}
}
