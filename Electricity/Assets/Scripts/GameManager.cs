using System;
using System.Collections;
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

    [Space(5)]
    [Header("Material")]
    [SerializeField]
    public Material PillarMaterial = null;

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
        if (endPoint == null)
            return;

        StartCoroutine(FinishStage());
    }

    IEnumerator FinishStage()
    {
        yield return new WaitForSeconds(0.5f);
        Debug.Log("Clear Game!");

        endAnimator.SetTrigger("endStateOn");
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
