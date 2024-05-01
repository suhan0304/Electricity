using UnityEngine;

public class CameraController : MonoBehaviour
{
    public float panSpeed = 30f; // camera pan speed

    private void Update()
    {
        if (Input.GetKey("w"))
        {
            transform.Translate(Vector3.forward * panSpeed * Time.deltaTime, Space.World);
        }
        if (Input.GetKey("s"))
        {
            transform.Translate(Vector3.back * panSpeed * Time.deltaTime, Space.World);
        }

    }
}
