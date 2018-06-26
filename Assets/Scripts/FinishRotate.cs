using UnityEngine;

public class FinishRotate : MonoBehaviour
{
	void Update () {
		transform.Rotate (0, 1, 0, Space.World);
	}
}
