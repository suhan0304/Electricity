using Cinemachine;
using System.Collections;
using UnityEngine;

public class CMmainFreeLookCameraSetting : MonoBehaviour
{
    [Space(5)]
    [Header("Camera Settings")]
    public CinemachineFreeLook mainFreeLookCamera;
    public float zoomSpeed = 2.5f;

    [Space(5)]
    [Header("Objects & Transform")]
    public GameObject CameraTarget;
    public Transform field;

    private void Start()
    {
        mainFreeLookCamera = GetComponent<CinemachineFreeLook>();
        if (field == null)
            return;
        Vector3 centerPos = CalculateCameraTarget(field);
        SetCameraTarget(centerPos);

        mainFreeLookCamera.LookAt = CameraTarget.transform;
        mainFreeLookCamera.Follow = CameraTarget.transform;

    }

    Vector3 CalculateCameraTarget(Transform parent)
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

    private void SetCameraTarget(Vector3 centerPos)
    {
        if (CameraTarget != null)
            CameraTarget.transform.position = centerPos;
    }

    /// <summary>
    /// When Clear Stage, GameManager called this method
    /// </summary>
    public void ClearGame(Transform endPoint, float duration)
    {
        StartCoroutine(TransitionTarget(endPoint, duration));
    }

    IEnumerator TransitionTarget(Transform endPoint, float duration)
    {
        yield return new WaitForSeconds(duration);
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
