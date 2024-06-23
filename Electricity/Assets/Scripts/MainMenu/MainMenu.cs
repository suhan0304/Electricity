using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEditor;

public class MainMenu : MonoBehaviour
{
    public static string MenuToLoad = "Main";
    public static string levelToLoad = "MainLevel";

    public void Play() {
        SceneManager.LoadScene(levelToLoad);
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
