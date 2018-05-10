using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class Vehicle : System.Object  
{
	public WheelCollider leftWheel; // masukin collider ban
	public GameObject leftWheelMesh; // masukin model ban
	public WheelCollider rightWheel; // masukin collider ban
	public GameObject rightWheelMesh; // masukin model ban
	public bool motor; // main engine
	public bool steering; // bisa belok apa enggak
	public bool reverseTurn; // reverse controller
}

public class VController : MonoBehaviour {

	public float maxMotorTorque; // horse power
	public float maxSteeringAngle; // puteran steernya berapa derajat
	public List<Vehicle> vehicleWheels; // masukin ban nya ada berapa pasang

	public void VisualizeWheel(Vehicle wheelPair)
	{
		Quaternion rot;
		Vector3 pos;
		wheelPair.leftWheel.GetWorldPose ( out pos, out rot);
		wheelPair.leftWheelMesh.transform.position = pos;
		wheelPair.leftWheelMesh.transform.rotation = rot;
		wheelPair.rightWheel.GetWorldPose ( out pos, out rot);
		wheelPair.rightWheelMesh.transform.position = pos;
		wheelPair.rightWheelMesh.transform.rotation = rot;
	}

	public void Update()
	{
		float motor = maxMotorTorque * Input.GetAxis("Vertical");
		float steering = maxSteeringAngle * Input.GetAxis("Horizontal");
		float brakeTorque = Mathf.Abs(Input.GetAxis("Jump"));
		if (brakeTorque > 0.001) {
			brakeTorque = maxMotorTorque;
			motor = 0;
		} else {
			brakeTorque = 0;
		}

		foreach (Vehicle vehicleWheel in vehicleWheels)
		{
			if (vehicleWheel.steering == true) {
				vehicleWheel.leftWheel.steerAngle = vehicleWheel.rightWheel.steerAngle = ((vehicleWheel.reverseTurn)?-1:1)*steering;
			}

			if (vehicleWheel.motor == true)
			{
				vehicleWheel.leftWheel.motorTorque = motor;
				vehicleWheel.rightWheel.motorTorque = motor;
			}

			vehicleWheel.leftWheel.brakeTorque = brakeTorque;
			vehicleWheel.rightWheel.brakeTorque = brakeTorque;

			VisualizeWheel(vehicleWheel);
		}

	}
		
}