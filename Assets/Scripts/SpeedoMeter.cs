using UnityEngine;
using UnityEngine.UI;
using UnityStandardAssets.Vehicles.Car;

public class SpeedoMeter : MonoBehaviour
{
    [SerializeField] private CarController carScript;
    [SerializeField] private float minAngle = 82f;
    [SerializeField] private float maxAngle = -82f;
    [SerializeField] private float maxSpeed = 180f;
    private Image arrow;    

    public float MinAngle { get; set; }
    public float MaxAngle { get; set; }
    public float MaxSpeed { get; set; }

    private void Start ()
    {
        arrow = GetComponent<Image>();
    }
    private void LateUpdate ()
    {
        arrow.rectTransform.eulerAngles = new Vector3(0, 0, Mathf.Lerp(minAngle, maxAngle, Mathf.InverseLerp(0, maxSpeed, carScript.CurrentSpeed)));
    }
}
