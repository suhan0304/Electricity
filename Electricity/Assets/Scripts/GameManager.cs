using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    [Space(5)]
    [Header("Manager")]
    public BuildManager buildManager;

    [Space(5)]
    [Header("Tag")]
    public String startTag = "startPoint";

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
        buildManager = GetComponent<BuildManager>();
    }
}
