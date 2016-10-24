using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using XInputDotNetPure;

public class playerController : MonoBehaviour {

    public List<AxleInfo> axleInfos;
    public float maxMotorTorque;
    public float maxSteeringAngle;

	public GameObject fork;
	public GameObject forkMax;
	public GameObject forkMin;

	public GameObject camTarget;
	public float camYRot=0;
	public float camRotSpeed =.1f;

	public float camLPos=0;
	public float camLiftSpeed =.1f;
	public float camCeiling = 10f;
	public float camFloor = -10f;

	public float liftSpeed = 1;

	public Transform centerOfMassTF;
	public Transform playerStart;

	public Camera cam;
	public int playerNumber;


	public PlayerIndex playerIndexNum;
	private GamePadState state;

	void Start () {
		Cursor.lockState = CursorLockMode.Locked;
		this.gameObject.GetComponent<Rigidbody> ().centerOfMass = centerOfMassTF.localPosition;
		cam.rect = new Rect( 0.5f*playerNumber-0.5f,0, 0.5f,1);
		if (playerNumber == 1) {
			playerIndexNum = PlayerIndex.One;
		}else if (playerNumber == 2) {
			playerIndexNum = PlayerIndex.Two;
		}
	}

	public void Update(){
		float mDeltaX;
		float mDeltaY;

		state = GamePad.GetState(playerIndexNum);
		if (state.IsConnected) {
			//Debug.Log ("Controller " + playerIndexNum.ToString () + " connected.");
			mDeltaX = state.ThumbSticks.Right.X;
			mDeltaY = state.ThumbSticks.Right.Y;
		} else {
			mDeltaX = Input.GetAxis ("Mouse X");
			mDeltaY = Input.GetAxis ("Mouse Y");
		}

		camYRot += mDeltaX*camRotSpeed;
		camLPos -= mDeltaY * camLiftSpeed;
		if (camLPos > camCeiling)
			camLPos = camCeiling;
		else if (camLPos < camFloor)
			camLPos = camFloor;

		camTarget.transform.rotation = Quaternion.EulerAngles (camLPos, camYRot, 0);

		if (Input.GetKeyDown (KeyCode.R)) {
			this.gameObject.transform.position = playerStart.position;
			this.gameObject.transform.rotation = playerStart.rotation;
			this.gameObject.GetComponent<Rigidbody> ().velocity = Vector3.zero;
			this.gameObject.GetComponent<Rigidbody> ().angularVelocity = Vector3.zero;
		}
	}

    public void FixedUpdate()
    {
		float motor;
		float steering;

		state = GamePad.GetState(playerIndexNum);
		if (state.IsConnected) {
			//motor = maxMotorTorque * state.ThumbSticks.Left.Y;
			motor = maxMotorTorque * -(state.Triggers.Left - state.Triggers.Right);
			steering = maxSteeringAngle * state.ThumbSticks.Left.X;
			if ((state.Buttons.RightShoulder == ButtonState.Pressed) && (fork.transform.localPosition.y < forkMax.transform.localPosition.y)) {
				fork.transform.localPosition = new Vector3 (fork.transform.localPosition.x,fork.transform.localPosition.y+liftSpeed,fork.transform.localPosition.z);
			}else if ((state.Buttons.LeftShoulder == ButtonState.Pressed) && (fork.transform.localPosition.y > forkMin.transform.localPosition.y)) {
				fork.transform.localPosition = new Vector3 (fork.transform.localPosition.x,fork.transform.localPosition.y-liftSpeed,fork.transform.localPosition.z);
			}
		} else {
			motor = maxMotorTorque * Input.GetAxis ("Vertical");
			steering = maxSteeringAngle * Input.GetAxis ("Horizontal");
			if (Input.GetMouseButton (0) && (fork.transform.localPosition.y < forkMax.transform.localPosition.y)) {
				fork.transform.localPosition = new Vector3 (fork.transform.localPosition.x,fork.transform.localPosition.y+liftSpeed,fork.transform.localPosition.z);
			}else if (Input.GetMouseButton (1) && (fork.transform.localPosition.y > forkMin.transform.localPosition.y)) {
				fork.transform.localPosition = new Vector3 (fork.transform.localPosition.x,fork.transform.localPosition.y-liftSpeed,fork.transform.localPosition.z);
			}
		}

        foreach (AxleInfo axleInfo in axleInfos)
        {
            if (axleInfo.steering)
            {
                axleInfo.leftWheel.steerAngle = steering;
                axleInfo.rightWheel.steerAngle = steering;
            }
            if (axleInfo.motor)
            {
                axleInfo.leftWheel.motorTorque = motor;
                axleInfo.rightWheel.motorTorque = motor;
            }
        }


    }
}

[System.Serializable]
public class AxleInfo
{
    public WheelCollider leftWheel;
    public WheelCollider rightWheel;
    public bool motor;
    public bool steering;
}

