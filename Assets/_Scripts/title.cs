using UnityEngine;
using System.Collections;
using XInputDotNetPure;

public class title : MonoBehaviour {

	public PlayerIndex playerIndexNum;
	private GamePadState state;
	public string firstLevel;
	public GameObject controls;
	public float hold;

	void Update () {
		if (hold <= 0) {
			state = GamePad.GetState (playerIndexNum);
			if (state.IsConnected) {
				if (state.Buttons.A == ButtonState.Pressed) {
					Application.LoadLevel (firstLevel);
				}
				if (state.Buttons.B == ButtonState.Pressed) {
					if (controls.activeInHierarchy) {
						controls.SetActive (false);
						this.gameObject.GetComponent<MeshRenderer> ().enabled = true;
					} else {
						controls.SetActive (true);
						this.gameObject.GetComponent<MeshRenderer> ().enabled = false;
					}
					hold = .2f;
				}
			}
		} else {
			hold -= Time.deltaTime;
        }
        if (Input.GetKeyDown(KeyCode.Return))
        {
            Application.LoadLevel(firstLevel);
        }
        else if (Input.GetKeyDown(KeyCode.Alpha1))
        {
            Application.LoadLevel("Level1");
        }
        else if (Input.GetKeyDown(KeyCode.Alpha2))
        {
            Application.LoadLevel("Level2");
        }
        else if (Input.GetKeyDown(KeyCode.Alpha3))
        {
            Application.LoadLevel("Level3");
        }
        else if (Input.GetKeyDown(KeyCode.Alpha4))
        {
            Application.LoadLevel("Level4");
        }
        else if (Input.GetKeyDown(KeyCode.Escape))
        {
            Application.Quit();
        }
    }
}
