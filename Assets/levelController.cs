using UnityEngine;
using System.Collections;

public class levelController : MonoBehaviour {

	public string nextLevelName;

	void Update () {
		if (Input.GetKeyDown (KeyCode.Return)) {
			nextLevel();
		}
	}

	public void nextLevel(){
		Application.LoadLevel (nextLevelName);
	}
}
