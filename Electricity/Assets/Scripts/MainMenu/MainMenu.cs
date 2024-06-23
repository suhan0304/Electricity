using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{
    public static string MenuToLoad = "Main";
    public static string levelToLoad = "MainLevel";

    public void Play() {
        SceneManager.LoadScene(levelToLoad);
    }

    public void Quit() {
        Debug.Log("Exiting...");
        Application.Quit();
    }

}
