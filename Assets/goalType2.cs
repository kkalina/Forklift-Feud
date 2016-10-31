using UnityEngine;
using System.Collections;

public class goalType2 : MonoBehaviour {

	public int playerGoal = 1;

	public GameObject p1win;
	public GameObject p2win;

	private float gameEnd = 0f;
	private bool gameEnded = false;
	public float endDelay = 3f;

	public levelController LC;

	// Use this for initialization
	void OnTriggerEnter (Collider other) {
		if ((LC.gameEnded == false)&&((other.gameObject.tag == "player1Objective")||(other.gameObject.tag == "player2Objective"))) {
			if (playerGoal == 1) {
				Debug.Log ("Player 1 wins!");
				p1win.SetActive (true);
			} else {
				Debug.Log ("Player 2 wins!");
				p2win.SetActive (true);

			}
			gameEnd = Time.time;
			gameEnded = true;
			LC.gameEnded = true;
		}

	}

	// Update is called once per frame
	void FixedUpdate () {
		if (gameEnded && (Time.time > (gameEnd + endDelay))) {
			LC.nextLevel ();
		}
	}
}
