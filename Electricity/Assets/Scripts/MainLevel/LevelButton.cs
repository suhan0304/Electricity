using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class LevelButton : MonoBehaviour
{
    public SceneFader sceneFader;
    public static string PlayToLoad = "Play";
    public TMP_Text levelText;
    
    public void Initialize(int mapLevel) {
        levelText.text = mapLevel.ToString();
        transform.GetComponent<Button>().onClick.AddListener(() => OnLevelButtonClick(mapLevel));
    }

    private void OnLevelButtonClick(int mapLevel) {
        CurrentLevel.curLevel = mapLevel;
        LevelManager.Instance.sceneFader.FadeTo(PlayToLoad);
    }
}
