using Cinemachine;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Block : MonoBehaviour
{
    CinemachineFreeLook freelook;
    public float zoomSpeed = 1000.0f;

    private void Update()
    {
        if (Input.GetKey("q")) // Press "q" Key = Zoom in
        {
            transform.Translate(Vector3.right * panSpeed * Time.deltaTime, Space.World);
        }
        if (Input.GetKey("e")) // Pree "e" Key = Zoom out
        {
            transform.Translate(Vector3.left * panSpeed * Time.deltaTime, Space.World);
        }
    }
}
