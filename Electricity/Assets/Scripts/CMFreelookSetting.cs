using Cinemachine;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Experimental.AI;
using UnityEngine.UIElements;

public class CMmainFreeLookCameraSetting : MonoBehaviour
{
    [Space(5)]
    [Header("Camera Settings")]
    public CinemachineFreeLook mainFreeLookCamera;
    public float zoomSpeed = 2.5f;

    [Space(5)]
    [Header("Objects & Transform")]
    public GameObject centerPoint;
    public Transform field;

    private void Start()
    {
        mainFreeLookCamera = GetComponent<CinemachineFreeLook>();
        if (field == null)
            return;
        Vector3 centerPos = CalculateCenterPoint(field);
        SetCenterPoint(centerPos);

        mainFreeLookCamera.LookAt = centerPoint.transform;
        mainFreeLookCamera.Follow = centerPoint.transform;

    }

    Vector3 CalculateCenterPoint(Transform parent)
    {
        Vector3 totalPosition = Vector3.zero;
        int childCount = 0;

        foreach (Transform child in parent)
        {
            if (child.CompareTag("node"))
            {
                totalPosition += child.position;
                childCount++;
            }
        }

        if (childCount > 0)
        {
            return totalPosition / childCount;
        }
        else
        {
            return parent.position;
        }
    }

    private void SetCenterPoint(Vector3 centerPos)
    {
        if (centerPoint != null)
            centerPoint.transform.position = centerPos;
    }

    private void Update()
    {
        if (Input.GetKey("q")) // Press "q" Key = Zoom in
        {
            if(mainFreeLookCamera.m_Lens.FieldOfView >= 5)
                mainFreeLookCamera.m_Lens.FieldOfView -= zoomSpeed * Time.deltaTime; //Zoom In
        }
        if (Input.GetKey("e")) // Pree "e" Key = Zoom out
        {
            if (mainFreeLookCamera.m_Lens.FieldOfView <= 20)
                mainFreeLookCamera.m_Lens.FieldOfView += zoomSpeed * Time.deltaTime; //Zoom Out
        }
    }
}
