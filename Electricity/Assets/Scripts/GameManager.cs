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

    [Space(5)]
    [Header("State")]
    public GameState gameState;

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
        validator = GetComponent<Validator>();
        buildManager = GetComponent<BuildManager>();
        endAnimator = endPoint.GetComponent<Animator>();
        startTag = "startPoint";
        endTag = "endPoint";
    }

    void Start()
    {
        gameState = GameState.PLAY;
        // Validation
        if (!validator.ValidateInitialization())
            QuitGame();
    }

    /// <summary>
    /// endPoint's state is now ON. Ending the stage.
    /// </summary>
    public void Clear()
    {
        gameState = GameState.CLEAR; // game Clear

        float delayTime = 1.0f;
        float finishDuration = 2.0f;

        StartCoroutine(FinishCameraSetting(delayTime, finishDuration));
        StartCoroutine(FinishStage(delayTime, finishDuration));
    }

    /// <summary>
    /// Clear State, Finish Stage
    /// </summary>
    IEnumerator FinishStage(float delayTime, float finishDuration)
    {
        yield return new WaitForSeconds(delayTime);

        endAnimator.speed = endAnimationDuration / delayTime;
        endAnimator.SetTrigger("endStateOn"); // play endPoint Animation

    }

    IEnumerator FinishCameraSetting(float delayTime, float finishDuration)
    {
        yield return new WaitForSeconds(delayTime);
        mainCamera.GetComponent<CMmainFreeLookCameraSetting>().ClearGame(endPoint.transform, finishDuration);
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
