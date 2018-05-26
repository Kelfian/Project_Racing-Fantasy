using UnityEngine;

public class HalfPointTrigger : MonoBehaviour
{
	void OnTriggerEnter()
    {
		transform.parent.GetChild(0).gameObject.SetActive(true);
		gameObject.SetActive(false);
	}
}
