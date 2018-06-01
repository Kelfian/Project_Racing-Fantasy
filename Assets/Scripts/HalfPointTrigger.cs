using UnityEngine;

public class HalfPointTrigger : MonoBehaviour
{
    private void OnTriggerEnter()
    {
        transform.parent.GetChild(0).GetComponent<BoxCollider>().enabled = true;
        gameObject.SetActive(false);
    }
}
