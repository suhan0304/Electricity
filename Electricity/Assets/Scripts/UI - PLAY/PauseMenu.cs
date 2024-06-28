using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class PauseMenu : MonoBehaviour
{
    public static string RetryToLoad = "Play";
    public static string MenuToLoad = "MainMenu";
    public SceneFader sceneFader;

    public void OnClickRetryButton() {
        Debug.Log($"{this.name} - OnClickRetryButton");
        sceneFader.FadeTo(RetryToLoad);
    }

    public void OnClickMainMenuButton() {
        Debug.Log($"{this.name} - OnClickMainMenuButton");
        sceneFader.FadeTo(MenuToLoad);
    }
}
