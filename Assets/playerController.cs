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

	public float liftSpeed = 1;

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

