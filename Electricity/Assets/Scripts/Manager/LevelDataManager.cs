using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelDataManager : MonoBehaviour
{
    public static LevelDataManager Instance;

    [SerializeField]
    public LevelData[] levelDatas;

    private void Awake() {
        if (Instance == null) {
            Instance = this;
        }     
        else {
            Destroy(gameObject);
        }

        levelDatas = Resources.LoadAll<LevelData>("LevelData");
    }
    
    public LevelData GetLevelData(int level) {
        foreach(var levelData in levelDatas) {
            if (levelData.level == level) {
                return levelData;
            }
        }
        Debug.LogWarning("$Level {level} can't find");
        return null;
    }
}
