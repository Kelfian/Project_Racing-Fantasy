using System.Collections;
using UnityEngine;
using UnityStandardAssets.Vehicles.Car;

public class RaceFinish : MonoBehaviour
{
	[SerializeField] private Transform car;
    [SerializeField] private Transform gameUI;
    private GameObject win;
    private Transform finishCam;
    //public GameObject viewModes;
    //public GameObject levelMusic;
    //public GameObject completeTrig;
    //public AudioSource finishMusic;
    private void Start()
    {
        finishCam = car.transform.GetChild(7).GetChild(0);
        win = gameUI.GetChild(6).gameObject;
    }

    public void RaceFinished()
    {
        //myCar.SetActive (false);
		//completeTrig.SetActive (false);
		CarController.m_Topspeed = 0.0f;
        car.GetComponent<CarUserControl> ().enabled = false;
        car.gameObject.SetActive (true);
		finishCam.gameObject.SetActive (true);
        win.SetActive(true);
        //levelMusic.SetActive (false);
        //viewModes.SetActive (false);
        //finishMusic.Play ();
        StartCoroutine(MoveToMainMenu());
        finishCam.localEulerAngles = new Vector2(15, 0);
        finishCam.GetComponent<CameraStable>().enabled = false;
        finishCam.GetComponent<CameraChange>().enabled = false;
        //finishCam.transform.Rotate(0, 1, 0, Space.World);
        finishCam.localPosition = new Vector3(0, 15, -25);
        finishCam.GetComponent<FinishRotate>().enabled = true;
    }

    private IEnumerator MoveToMainMenu()
    {
        yield return new WaitForSeconds(5f);
        gameUI.GetComponent<Loading>().LoadScene(0);
    }
}
