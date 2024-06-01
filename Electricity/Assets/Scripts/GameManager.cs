using Cinemachine;
using System;
using System.Collections;
using System.Runtime.CompilerServices;
using Unity.VisualScripting;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    [Space(5)]
    [Header("Manager")]
    public BuildManager buildManager;
    public Validator validator;

    [Space(5)]
    [Header("Tag & Name")]
    public string startTag = "startPoint";
    public string endTag = "endPoint";
    public string BulbName = "Bulb";

    [Space(5)]
    [Header("endPoint")]
    public GameObject endPoint;
    public Animator endAnimator;
    public float endAnimationDuration = 1.0f;   // Current Animation Duration

    [Space(5)]
    [Header("Material")]
    [SerializeField]
    public Material PillarMaterial = null;

    [Space(5)]
    [Header("mainCamera")]
    public GameObject mainCamera = null;

    public static GameManager Instance { get; private set; }

    void Awake()
    {
        // 싱글톤 인스턴스 설정
        if (Instance == null)
        {
            Instance = this;
        }
        else
        {
            Debug.LogWarning("Error - Only 1 instance - GameManager.");
            Destroy(gameObject);
        }
        endAnimator = endPoint.GetComponent<Animator>();
        startTag = "startPoint";
        endTag = "endPoint";
    }

    void Start()
    {
        validator = GetComponent<Validator>();
        buildManager = GetComponent<BuildManager>();

        // Validation
        if (!validator.ValidateInitialization())
            QuitGame();
    }

    /// <summary>
    /// endPoint's state is now ON. Ending the stage.
    /// </summary>
    public void Clear()
    {
        float delayTime = 2f;
        mainCamera.GetComponent<CMmainFreeLookCameraSetting>().ClearGame(endPoint.transform, delayTime);
        StartCoroutine(FinishStage(delayTime));
    }

    /// <summary>
    /// Clear State, Finish Stage
    /// </summary>
    IEnumerator FinishStage(float delayTime)
    {
        Debug.Log("Clear Game!");
        yield return new WaitForSeconds(0.5f);

        endAnimator.speed = endAnimationDuration / delayTime;
        endAnimator.SetTrigger("endStateOn"); // play endPoint Animation

        yield return new WaitForSeconds(delayTime);
    }

    /// <summary>
    /// Something has happened and shutting down the game
    /// </summary>
    public void QuitGame()
    {
        Debug.Log("Quitting Game...");
    #if UNITY_EDITOR
        UnityEditor.EditorApplication.isPlaying = false;
    #else
        Application.Quit();
    #endif
    }
}
