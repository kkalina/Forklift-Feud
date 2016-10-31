using UnityEngine;
using System.Collections;

public class levelController : MonoBehaviour {

	public string nextLevelName;
	public bool gameEnded = false;

	void Update ()
    {
        if (Input.GetKeyDown(KeyCode.Return))
        {
            nextLevel();
        }
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            Application.LoadLevel("Title");
        }
    }

	public void nextLevel(){
		Application.LoadLevel (nextLevelName);
	}
}
