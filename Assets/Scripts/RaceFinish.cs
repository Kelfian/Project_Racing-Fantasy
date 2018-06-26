using UnityEngine;
using UnityStandardAssets.Vehicles.Car;

public class RaceFinish : MonoBehaviour
{
	public GameObject myCar;
	public GameObject finishCam;
	//public GameObject viewModes;
	//public GameObject levelMusic;
	//public GameObject completeTrig;
	//public AudioSource finishMusic;

	public void RaceFinished()
    {
        //myCar.SetActive (false);
		//completeTrig.SetActive (false);
		CarController.m_Topspeed = 0.0f; 
		myCar.GetComponent<CarController> ().enabled = false;
		myCar.GetComponent<CarUserControl> ().enabled = false;
		myCar.SetActive (true);
		finishCam.SetActive (true);
        //levelMusic.SetActive (false);
        //viewModes.SetActive (false);
        //finishMusic.Play ();
        finishCam.transform.localEulerAngles = new Vector2(15, 0);
        finishCam.GetComponent<CameraStable>().enabled = false;
        finishCam.GetComponent<CameraChange>().enabled = false;
        //finishCam.transform.Rotate(0, 1, 0, Space.World);
        finishCam.transform.localPosition = new Vector3(0, 15, -25);
        finishCam.transform.parent.GetComponent<FinishRotate>().enabled = true;
    }
}
