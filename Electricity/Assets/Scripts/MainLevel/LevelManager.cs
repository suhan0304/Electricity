using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class LevelManager : MonoBehaviour
{
    public static LevelManager Instance { get; private set; }

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
            return;
        }
    }

    public SceneFader sceneFader;
    
    public GameObject buttonRrefab;
    public Transform buttonContents;

    void Start() {
        buttonRrefab = Resources.Load<GameObject>("LevelButton");
        if (buttonRrefab == null) {
            Debug.LogWarning("No Level Button Prefab in Resources/");
            return;
        }
        LoadLevelData();
    }

    void LoadLevelData() {
        LevelData[] levelDatas = Resources.LoadAll<LevelData>("LevelData");
        CurrentLevel.maxLevel = levelDatas.Length;

        Debug.Log($"Number of LevelData objects in Resources/LevelData: {levelDatas.Length}");

        for (int i=0; i<levelDatas.Length; i++) {
            GameObject levelButton = Instantiate(buttonRrefab, buttonContents);
            levelButton.GetComponent<LevelButton>().Initialize(i+1);
        }
    }
}
