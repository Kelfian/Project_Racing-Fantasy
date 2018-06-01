using UnityEngine;

public class CameraStable : MonoBehaviour
{
    private Transform theCar;
    private float carX;
    private float carY;
    private float carZ;
    private void Start()
    {
        theCar = transform.parent;
    }
    private void Update ()
    {
        carX = theCar.eulerAngles.x;
        carY = theCar.eulerAngles.y;
        carZ = theCar.eulerAngles.z;
        transform.eulerAngles = new Vector3 (carX - carX, carY, carZ - carZ);
    }
}
