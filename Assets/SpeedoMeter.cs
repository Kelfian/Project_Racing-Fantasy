using UnityEngine;
using UnityEngine.UI;

public class SpeedoMeter : MonoBehaviour
{
    public Rigidbody rb;
    private float speed = 0;
    private Image arrow;

	private void Start ()
    {
        arrow = GetComponent<Image>();
    }
    private void LateUpdate ()
    {
        arrow.rectTransform.eulerAngles = new Vector3(0, 0, Mathf.Lerp(82, -82, Mathf.InverseLerp(0, 100, rb.velocity.magnitude)));
	}
}
