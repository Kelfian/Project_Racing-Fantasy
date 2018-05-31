using System.Collections;
using UnityEngine;

public class ColliderDetector : MonoBehaviour
{
    private BoxCollider waypointCollider;
    private void Start()
    {
        waypointCollider = GetComponent<BoxCollider>();
    }
    private IEnumerator OnTriggerEnter(Collider collision)
    {
        if (collision.gameObject.tag == "CarAI00")
        {
            waypointCollider.enabled = false;
            AIWaypoint.ChangeWaypoint();
            yield return new WaitForSeconds(1);
            waypointCollider.enabled = true;
        }
    }
}
