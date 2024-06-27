using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEditor;

public class MainMenu : MonoBehaviour
{
    public SceneFader sceneFader;
    public static string MenuToLoad = "MainMenu";
    public static string levelToLoad = "MainLevel";

    public void Play() {
        Debug.Log("OnPlayButtonClick");
        sceneFader.FadeTo(levelToLoad);
    }

    public void Quit() {
        Debug.Log("Exiting...");

    #if UNITY_EDITOR 
        if (EditorApplication.isPlaying)
        {
            EditorApplication.isPlaying = false; 
        }
    #else
        Application.Quit();
    #endif
    }

}
