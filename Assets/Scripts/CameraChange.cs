using System.Collections;
using UnityEngine;

public class CameraChange : MonoBehaviour
{
    private enum CameraMode : int { Normal, Far, First};

    [SerializeField] CameraMode camMode;

    private Vector3[] camPos;
    private Vector3[] camRot;
    private CameraStable camStab;
    private int currentCam;
    private int totalCam;

    private void Start()
    {
        totalCam = transform.childCount;
        camPos = new Vector3[totalCam];
        camRot = new Vector3[totalCam];
        for (int i = 0; i < totalCam; i++)
        {
            Transform thisCam = transform.GetChild(i);
            camPos[i] = thisCam.localPosition;
            camRot[i] = thisCam.localEulerAngles;
        }
        totalCam--;
        camStab = GetComponent<CameraStable>();
        currentCam = (int)camMode;
        ChangeCam(currentCam);
    }

    private void Update ()
    {
        if (Input.GetKeyDown(KeyCode.C))
        {
            currentCam += (currentCam == totalCam) ? -totalCam : 1;
            ChangeCam(currentCam);
		}
	}
    private void ChangeCam(int changeTo)
    {
        transform.localPosition = camPos[changeTo];
        transform.localEulerAngles = camPos[changeTo];
        if (currentCam == 2)
        {
            camStab.enabled = false;
        }
        else if (camStab.enabled == false)
        {
            camStab.enabled = true;
        }
    }
}