using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    [Header("Start")]
    public GameObject startObject;
    public StartPoint startPoint;

    [Space(5)]
    [Header("Manager")]
    public BuildManager buildManager;

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
    }

    void Start() 
    {
        startPoint = startObject.GetComponent<StartPoint>();
        buildManager = GetComponent<BuildManager>();
    }
}
