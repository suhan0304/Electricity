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
    public void OnClickMainMenuButton() {
        SceneManager.LoadScene(MenuToLoad);
    }
    public void OnClickMainLevelButton() {
        SceneManager.LoadScene(levelToLoad);
    }

    public void OnClickNextLevelButton() {
        if(CurrentLevel.maxLevel >= CurrentLevel.curLevel + 1){
            NextLevelButton.interactable = false;
            return;
        }
        else {
            CurrentLevel.curLevel = CurrentLevel.curLevel + 1;
        }
        SceneManager.LoadScene(MenuToLoad);
    }

    public void Clear() {
        this.gameObject.SetActive(true);
    }
}
