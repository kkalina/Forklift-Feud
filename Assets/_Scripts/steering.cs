using UnityEngine;
using System.Collections;
using XInputDotNetPure;

public class steering : MonoBehaviour {

    public float steeringPos = 0;
    public float travel = 0;
    public float cosmeticPos = 0;
    public float cosmeticTravel = 0.1f;

	public GameObject parentPlayer;

	public PlayerIndex playerIndexNum;
	private GamePadState state;

    // Use this for initialization
    void Start () {
		int playerNumber = parentPlayer.GetComponent<playerController> ().playerNumber;
		if (playerNumber == 1) {
			playerIndexNum = PlayerIndex.One;
		}else if (playerNumber == 2) {
			playerIndexNum = PlayerIndex.Two;
		}
	}
	
	// Update is called once per frame
	void FixedUpdate () {
		state = GamePad.GetState(playerIndexNum);
		if (state.IsConnected) {
			steeringPos = state.ThumbSticks.Left.X * travel;
			cosmeticPos = state.ThumbSticks.Left.X * cosmeticTravel;
		} else {
			steeringPos = Input.GetAxis ("Horizontal") * travel;
			cosmeticPos = Input.GetAxis ("Horizontal") * cosmeticTravel;
		}
        this.transform.localRotation = Quaternion.EulerAngles(0, cosmeticPos, 0);
        this.GetComponent<WheelCollider>().steerAngle = steeringPos;

        
	}
}
