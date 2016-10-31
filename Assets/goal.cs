using UnityEngine;
using System.Collections;

public class goal : MonoBehaviour {

	public GameObject p1win;
	public GameObject p2win;

	private float gameEnd = 0f;
	private bool gameEnded = false;
	public float endDelay = 3f;

	public levelController LC;

	// Use this for initialization
	void OnTriggerEnter (Collider other) {
		if (other.gameObject.tag == "player1Objective") {
			Debug.Log ("Player 1 wins!");
			p1win.SetActive (true);
			gameEnd = Time.time;
			gameEnded = true;
		}else if (other.gameObject.tag == "player2Objective") {
			Debug.Log ("Player 2 wins!");
			p2win.SetActive (true);
			gameEnd = Time.time;
			gameEnded = true;

		}

	}
	
	// Update is called once per frame
	void FixedUpdate () {
		if (gameEnded && (Time.time > (gameEnd + endDelay))) {
			LC.nextLevel ();
		}
	}
}
