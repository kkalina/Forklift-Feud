using UnityEngine;
using System.Collections;

public class catcher : MonoBehaviour {

	public Transform player1ObjSpawn;
	public Transform player2ObjSpawn;

	// Use this for initialization
	void OnTriggerEnter(Collider other){
		if (other.gameObject.tag == "Player") {
			other.gameObject.GetComponent<playerController> ().respawn ();
		}
		else if (other.gameObject.tag == "player1Objective") {
			other.gameObject.transform.position = player1ObjSpawn.transform.position;
		}
		else if (other.gameObject.tag == "player2Objective") {
			other.gameObject.transform.position = player2ObjSpawn.transform.position;
		}
	}
}
