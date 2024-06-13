using System.Collections;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    [Space(5)]
    [Header("ForMapData")]
    public int mapLevel = 1;
    public Map map;
    public GameObject field;


    [Space(5)]
    [Header("Manager")]
    public BuildManager buildManager;
    public Validator validator;

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
    public GameState gameState = GameState.PLAY;

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
        endAnimator = endPoint.GetComponent<Animator>();
        if(map == null) 
            map = GetComponent<Map>();
        gameState = GameState.PLAY;
    }

    void Start()
    {
        buildManager = BuildManager.Instance;
        // Validation
        if (!validator.ValidateInitialization())
            QuitGame();
    }

    /// <summary>
    /// endPoint's state is now ON. Ending the stage.
    /// </summary>
    public void Clear()
    {
        Debug.Log("Clear");
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

    /// set MapData
    public void SetMapData() {
        if(map == null) {
            Debug.LogError("Map is not exist.");
            return;
        }
        map.SetMapData();
    }
    /// set MapData
    public void SaveMapData() {
        if(map == null) {
            Debug.LogError("Map is not exist.");
            return;
        }
        map.SaveMapData();
    }
    /// Load MapData
    public void LoadMapData() {
        if(map == null) {
            Debug.LogError("Map is not exist.");
            return;
        }
        map.LoadMapData();
    }
    /// Reset MapData
    public void ResetMapData() {
        if(map == null) {
            Debug.LogError("Map is not exist.");
            return;
        }
        map.ResetMapData();
    }
}
