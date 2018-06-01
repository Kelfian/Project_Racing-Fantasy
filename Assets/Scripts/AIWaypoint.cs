using System;
using System.Collections;
using UnityEngine;

public class AIWaypoint : MonoBehaviour
{
    private Vector3[] waypoint;
    private BoxCollider waypointCollider;
    private int tracker = 0;
    private int totalPos = 0;

    private void Awake()
    {
        totalPos = transform.childCount;
        Array.Resize(ref waypoint, totalPos);
        totalPos--;
        for (int i = totalPos; i != -1; i--)
        {
            waypoint[i] = transform.GetChild(i).transform.localPosition;
            Destroy(transform.GetChild(i).gameObject);
        }
    }

    private void Start()
    {
        waypointCollider = GetComponent<BoxCollider>();
        transform.localPosition = waypoint[0];
    }
    private IEnumerator OnTriggerEnter(Collider collision)
    {
        if (collision.gameObject.tag == "CarAI00")
        {
            waypointCollider.enabled = false;
            /*tracker++;
            if (tracker == totalPos)
            {
                tracker = 0;
            }*/
            tracker += (tracker == totalPos) ? -totalPos : 1;
            transform.localPosition = waypoint[tracker];
            yield return new WaitForSeconds(1);
            waypointCollider.enabled = true;
        }
    }
}
