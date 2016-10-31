using UnityEngine;
using System.Collections;

public class deleter : MonoBehaviour {


	void OnTriggerEnter(Collider other){
		Destroy (other.gameObject);
	}

}
