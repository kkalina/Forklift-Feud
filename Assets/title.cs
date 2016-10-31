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
			if (Input.GetKeyDown (KeyCode.Return)) {
				Application.LoadLevel (firstLevel);
			}
		} else {
			hold -= Time.deltaTime;
		}
	}
}
