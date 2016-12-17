using UnityEngine;
using System.Collections;

public class ScrollBG : MonoBehaviour {

	public float speed;
	public float size;

	private Vector3 startPosition;

	// Use this for initialization
	void Start () {
		startPosition = transform.position;
	}
	
	// Update is called once per frame
	void Update () {
		float newPosition = Mathf.Repeat (Time.time * speed, size);
		transform.position = startPosition + Vector3.left * newPosition;
	}
}
