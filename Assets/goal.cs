using UnityEngine;
using System.Collections;

public class goal : MonoBehaviour {

	public GameObject p1win;
	public GameObject p2win;

	// Use this for initialization
	void OnTriggerEnter (Collider other) {
		if (other.gameObject.tag == "player1Objective") {
			Debug.Log ("Player 1 wins!");
			p1win.SetActive (true);
		}else
			if (other.gameObject.tag == "player2Objective") {
				Debug.Log ("Player 2 wins!");
				p2win.SetActive (true);

		}

	}
	
	// Update is called once per frame
	void Update () {
	
	}
}
