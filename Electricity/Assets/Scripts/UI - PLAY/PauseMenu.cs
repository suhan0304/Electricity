using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class PauseMenu : MonoBehaviour
{
    public static string RetryToLoad = "Play";
    public static string LevelToLoad = "MainLevel";
    public SceneFader sceneFader;

    public void OnClickRetryButton() {
        sceneFader.FadeTo(RetryToLoad);
    }

    public void OnClickMainMenuButton() {
        sceneFader.FadeTo(LevelToLoad);
    }
}
