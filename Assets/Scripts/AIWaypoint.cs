using System;
using UnityEngine;

public class AIWaypoint : MonoBehaviour
{
	private static GameObject gotoHere;
    private static Transform[] waypoint;
	private static int tracker = 0;
    private static int totalPos = 0;

    private void Awake()
    {
        gotoHere = transform.GetChild(0).gameObject;
        totalPos = transform.childCount - 1;
        Array.Resize(ref waypoint, totalPos);
        for (int i = 1; i < transform.childCount; i++)
        {
            waypoint[i-1] = transform.GetChild(i);
        }
    }

    private void Start()
    {
        gotoHere.transform.localPosition = waypoint[0].transform.localPosition;
        
    }
    public static void ChangeWaypoint()
    {
        tracker++;
        if (tracker == totalPos)
        {
            tracker = 0;
        }
        gotoHere.transform.localPosition = waypoint[tracker].localPosition;
    }
}
