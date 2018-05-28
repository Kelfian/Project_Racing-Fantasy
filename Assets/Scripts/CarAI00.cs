using System;
using System.Collections;
using UnityEngine;

public class CarAI00 : MonoBehaviour
{
	private GameObject gotoHere;
    private Transform[] waypoint;
	private int tracker = 0;

    private void Awake()
    {
        gotoHere = transform.GetChild(0).gameObject;
        Array.Resize(ref waypoint, transform.childCount - 1);
        for (int i = 1; i < transform.childCount; i++)
        {
            waypoint[i-1] = transform.GetChild(i);
        }
    }

    private void Start()
    {
        gotoHere.transform.localPosition = waypoint[0].transform.localPosition;
    }
    private IEnumerator OnTriggerEnter (Collider collision)
    {
		if (collision.gameObject.tag == "CarAI00")
        {
            gotoHere.GetComponent<BoxCollider>().enabled = false;
            tracker++;
			if (tracker == waypoint.Length)
            {
				tracker = 0;
			}
            gotoHere.transform.localPosition = waypoint[tracker].localPosition;
            yield return new WaitForSeconds (1);
            gotoHere.GetComponent<BoxCollider>().enabled = true;
		}
	}
}
