using UnityEngine;
using System.Collections;

public class randomSpawner : MonoBehaviour {

	public float interval = 1f;
	private float lastSpawn = 0f;
	public GameObject Object;

	void FixedUpdate () {
		if (Time.time > (lastSpawn + interval + (Random.value * 0.5f * interval))) {
			lastSpawn = Time.time;
			GameObject inst = Instantiate (Object);
			inst.transform.position = this.transform.position;
			inst.transform.rotation = this.transform.rotation;
		}
	}
}
