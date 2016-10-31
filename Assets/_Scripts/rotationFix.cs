using UnityEngine;
using System.Collections;

public class rotationFix : MonoBehaviour {

	public Transform up;

	void Update () {
		
		this.gameObject.transform.rotation = up.rotation;
	}
}
