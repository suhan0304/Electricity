using Cinemachine;
using System.Collections;
using UnityEngine;

public class CMmainFreeLookCameraSetting : MonoBehaviour
{
    [Space(5)]
    [Header("Camera Settings")]
    public CinemachineFreeLook mainFreeLookCamera;
    public float initFOV = 10f;
    public float XAxisSpeed = 50f;
    public float zoomSpeed = 30.0f;
    public float targetFOV = 5.0f;

    [Space(5)]
    [Header("Objects & Transform")]
    public GameObject CameraTarget;
    public Transform field;

    private void Awake()
    {
        mainFreeLookCamera = GetComponent<CinemachineFreeLook>();

    }

    private void Start()
    {
        mainFreeLookCamera.m_YAxis.m_InputAxisName = "Vertical";
        mainFreeLookCamera.m_XAxis.m_InputAxisName = "Horizontal";
        mainFreeLookCamera.m_XAxis.m_MaxSpeed = XAxisSpeed;

        if (field == null)
            return;

        Vector3 centerPos = CalculateCameraTarget(field);
        SetCameraTargetPos(centerPos);

        mainFreeLookCamera.m_Lens.FieldOfView = initFOV; 
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
            return (totalPosition / childCount);
        }
        else
        {
            return parent.position;
        }
    }

    private void SetCameraTargetPos(Vector3 centerPos)
    {
        Vector3 targetPos = new Vector3(centerPos.x, 0, centerPos.z);
        if (CameraTarget != null)
            CameraTarget.transform.position = targetPos;
    }

    /// <summary>
    /// When Clear Stage, GameManager called this method
    /// </summary>
    public void ClearGame(Transform endPoint, float transitionDuration)
    {
        mainFreeLookCamera.m_YAxis.m_InputAxisName = "";
        mainFreeLookCamera.m_XAxis.m_InputAxisName = "";

        mainFreeLookCamera.m_XAxis.m_MaxSpeed = 20f;
        mainFreeLookCamera.m_XAxis.m_InputAxisValue = 1f;

        StartCoroutine(MoveTargetToPosition(endPoint, transitionDuration));
        StartCoroutine(CloseUpEndPoint(endPoint, transitionDuration));
    }

    /// <summary>
    /// Move CameraTarget to EndPoint
    /// </summary>
    IEnumerator MoveTargetToPosition(Transform endPoint, float duration)
    {
        Vector3 startPosition = CameraTarget.transform.position;
        Vector3 endPosition = endPoint.position;
        
        float elapsedTime = 0f;

        while ( elapsedTime < duration )
        {
            float t = Mathf.Clamp01(elapsedTime / duration);
            float smoothT = Mathf.SmoothStep(0.0f, 1.0f, t);

            CameraTarget.transform.position = Vector3.Lerp(startPosition, endPosition, smoothT);
            elapsedTime += Time.deltaTime;
            yield return null;

        }
        CameraTarget.transform.position = endPosition;
    }

    IEnumerator CloseUpEndPoint(Transform endPoint, float duration)
    {
        float originalFOV = mainFreeLookCamera.m_Lens.FieldOfView;
        float elapsedTime = 0f;

        while ( elapsedTime < duration )
        {
            float t = Mathf.Clamp01(elapsedTime / duration);
            float smoothT = Mathf.SmoothStep(0.0f, 1.0f, t);

            float interpolatedFOV = Mathf.Lerp(originalFOV, targetFOV, t);

            mainFreeLookCamera.m_Lens.FieldOfView = interpolatedFOV;

            elapsedTime += Time.deltaTime;
            yield return null;
        }

        mainFreeLookCamera.m_Lens.FieldOfView = targetFOV;
    }

    private void Update()
    {
        if (GameManager.Instance == null)
            return;

        if (GameManager.Instance.gameState == GameState.CLEAR)
            return;

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
