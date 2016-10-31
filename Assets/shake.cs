using UnityEngine;
using System.Collections;

public class shake : MonoBehaviour {

	public Transform origin;
	public float shakeTime = 0f;
	public float intensity = 1f;

	void Awake () {
		//origin = this.gameObject.transform;
	}

	void FixedUpdate () {
		if (shakeTime > 0) {
			this.gameObject.transform.position = new Vector3 (origin.position.x + Random.value * intensity, origin.position.y + Random.value * intensity, origin.position.z + Random.value * intensity);
			shakeTime = shakeTime - Time.fixedDeltaTime;
		} else {
			this.gameObject.transform.position = origin.position;
		}
	}
}
