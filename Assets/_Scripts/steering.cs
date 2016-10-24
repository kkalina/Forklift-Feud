using UnityEngine;
using System.Collections;

public class steering : MonoBehaviour {

    public float steeringPos = 0;
    public float travel = 0;
    public float cosmeticPos = 0;
    public float cosmeticTravel = 0.1f;

    // Use this for initialization
    void Start () {
	
	}
	
	// Update is called once per frame
	void FixedUpdate () {
        steeringPos = Input.GetAxis("Horizontal")*travel;
        cosmeticPos = Input.GetAxis("Horizontal") * cosmeticTravel;
        this.transform.localRotation = Quaternion.EulerAngles(0, cosmeticPos, 0);
        this.GetComponent<WheelCollider>().steerAngle = steeringPos;

        
	}
}
