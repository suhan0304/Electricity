using Cinemachine;
using System.Collections;
using UnityEngine;

public class CMmainFreeLookCameraSetting : MonoBehaviour
{
    [Space(5)]
    [Header("Camera Settings")]
    public CinemachineFreeLook mainFreeLookCamera;
    public float zoomSpeed = 2.5f;
    public float targetFOV = 30.0f;

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
        SetCameraTargetPos(centerPos);

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

    private void SetCameraTargetPos(Vector3 centerPos)
    {
        if (CameraTarget != null)
            CameraTarget.transform.position = centerPos;
    }

    /// <summary>
    /// When Clear Stage, GameManager called this method
    /// </summary>
    public void ClearGame(Transform endPoint, float transitionDuration)
    {
        StartCoroutine(MoveTargetToPosition(endPoint, transitionDuration));
        StartCoroutine(CloseUpEndPoint(endPoint, transitionDuration));
    }

    /// <summary>
    /// Move CameraTarget to EndPoint
    /// </summary>
    IEnumerator MoveTargetToPosition(Transform endPoint, float duration)
    {
        Vector3 startPosition = CameraTarget.transform.position;
        
        float elapsedTime = 0f;

        while ( elapsedTime < duration )
        {
            float t = Mathf.Clamp01(elapsedTime / duration);
            float smoothT = Mathf.SmoothStep(0.0f, 1.0f, t);

            CameraTarget.transform.position = Vector3.Lerp(startPosition, endPoint.position, smoothT);
            elapsedTime += Time.deltaTime;
            yield return null;

        }
        CameraTarget.transform.position = endPoint.position;
    }

    IEnumerator CloseUpEndPoint(Transform endPoint, float duration)
    {
        float originalFOW = mainFreeLookCamera.m_Lens.FieldOfView;
        float elapsedTime = 0f;

        while ( elapsedTime < duration )
        {
            float t = Mathf.Clamp01(elapsedTime / duration);
            float smoothT = Mathf.SmoothStep(0.0f, 1.0f, t);

            float interpolatedFOV = Mathf.Lerp(originalFOW, targetFOV, t);

            mainFreeLookCamera.m_Lens.FieldOfView = interpolatedFOV;

            elapsedTime += Time.deltaTime;
            yield return null;
        }

        mainFreeLookCamera.m_Lens.FieldOfView = targetFOV;
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
