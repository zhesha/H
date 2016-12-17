using UnityEngine;
using System.Collections;

public class DeathBlock : MonoBehaviour {

	public float speed;
	public float lifetime;

	// Update is called once per frame
	void Update () {
		//float newPosition = Mathf.Repeat (Time.time * speed, size);
		Destroy (gameObject, lifetime);
		transform.position = transform.position + Vector3.left * speed;
	}
}
