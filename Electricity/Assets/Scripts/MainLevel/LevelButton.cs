using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class LevelButton : MonoBehaviour
{
    public static string MenuToLoad = "PLAY";
    public TMP_Text levelText;
    
    public void Initialize(int mapLevel) {
        levelText.text = mapLevel.ToString();
        transform.GetComponent<Button>().onClick.AddListener(() => OnLevelButtonClick(mapLevel));
    }

    private void OnLevelButtonClick(int mapLevel) {
        CurrentLevel.curLevel = mapLevel;
        SceneManager.LoadScene(MenuToLoad);
    }
}
