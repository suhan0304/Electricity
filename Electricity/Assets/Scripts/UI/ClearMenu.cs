using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class ClearMenu : MonoBehaviour
{
    public Button NextLevelButton;

    public static string MenuToLoad = "MainMenu";
    public static string levelToLoad = "MainLevel";
    void OnClickMainMenuButton() {
        SceneManager.LoadScene(MenuToLoad);
    }
    void OnClickMainLevelButton() {
        SceneManager.LoadScene(levelToLoad);
    }

    void OnClickNextLevel() {
        if(CurrentLevel.maxLevel >= CurrentLevel.curLevel + 1){
            NextLevelButton.interactable = false;
            return;
        }
        else {
            CurrentLevel.curLevel = CurrentLevel.curLevel + 1;
        }
        SceneManager.LoadScene(MenuToLoad);
    }
}
