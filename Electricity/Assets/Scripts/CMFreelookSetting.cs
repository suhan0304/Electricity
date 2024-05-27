using Cinemachine;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CMFreelookSetting : MonoBehaviour
{
    CinemachineFreeLook freelook;
    public float zoomSpeed = 2.5f;

    private void Start()
    {
        freelook = GetComponent<CinemachineFreeLook>();
    }

    private void Update()
    {
        if (Input.GetKey("q")) // Press "q" Key = Zoom in
        {
            if(freelook.m_Lens.FieldOfView >= 5)
                freelook.m_Lens.FieldOfView -= zoomSpeed * Time.deltaTime; //Zoom In
        }
        if (Input.GetKey("e")) // Pree "e" Key = Zoom out
        {
            if (freelook.m_Lens.FieldOfView <= 20)
                freelook.m_Lens.FieldOfView += zoomSpeed * Time.deltaTime; //Zoom Out
        }
    }
}
