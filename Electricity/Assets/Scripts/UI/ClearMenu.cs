using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ClearMenu : MonoBehaviour
{

    public static string MenuToLoad = "MainMenu";
    public static string levelToLoad = "MainLevel";
    void OnClickMainMenuButton() {
        SceneManager.LoadScene(MenuToLoad);
    }
    void OnClickMainLevelButton() {
        SceneManager.LoadScene(levelToLoad);
    }

}
