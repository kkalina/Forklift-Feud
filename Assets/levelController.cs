using UnityEngine;
using System.Collections;

public class levelController : MonoBehaviour {

	public string nextLevel;

	void Update () {
		if (Input.GetKeyDown (KeyCode.Return)) {
			Application.LoadLevel (nextLevel);
		}
	}
}
