using UnityEngine;
using System.Collections;
using System.Collections.Generic;

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

	public void Update(){

		float mDeltaX = Input.GetAxis("Mouse X");
		float mDeltaY = Input.GetAxis("Mouse Y");

		camYRot += mDeltaX*camRotSpeed;
		camLPos -= mDeltaY * camLiftSpeed;
		if (camLPos > camCeiling)
			camLPos = camCeiling;
		else if (camLPos < camFloor)
			camLPos = camFloor;

		camTarget.transform.rotation = Quaternion.EulerAngles (camLPos, camYRot, 0);

	}

    public void FixedUpdate()
    {
        float motor = maxMotorTorque * Input.GetAxis("Vertical");
        float steering = maxSteeringAngle * Input.GetAxis("Horizontal");

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

		if (Input.GetMouseButton (0) && (fork.transform.localPosition.y < forkMax.transform.localPosition.y)) {
			fork.transform.localPosition = new Vector3 (fork.transform.localPosition.x,fork.transform.localPosition.y+liftSpeed,fork.transform.localPosition.z);
		}else if (Input.GetMouseButton (1) && (fork.transform.localPosition.y > forkMin.transform.localPosition.y)) {
			fork.transform.localPosition = new Vector3 (fork.transform.localPosition.x,fork.transform.localPosition.y-liftSpeed,fork.transform.localPosition.z);
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

