using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class ClearMenu : MonoBehaviour
{
    public SceneFader sceneFader;

    private Animator anim;
    private readonly int hashClear = Animator.StringToHash("CLEAR");
    public Button NextLevelButton;

    public static string PlayToLoad = "Play";
    public static string MenuToLoad = "MainMenu";
    public static string levelToLoad = "MainLevel";

    public void Start() {
        anim = GetComponent<Animator>();    
    }
    public void OnClickMainMenuButton() {
        sceneFader.FadeTo(MenuToLoad);
    }
    public void OnClickMainLevelButton() {
        sceneFader.FadeTo(levelToLoad);
    }

    public void OnClickNextLevelButton() {
        CurrentLevel.curLevel = CurrentLevel.curLevel + 1;
        Debug.Log("Load Next Level Scene");
        SceneManager.LoadScene(PlayToLoad);
    }

    public void Clear() 
    {
        gameObject.SetActive(true);
        if(CurrentLevel.maxLevel < CurrentLevel.curLevel + 1){
            NextLevelButton.interactable = false;
        }
        StartCoroutine(ActivateClearMenu());
    }

    IEnumerator ActivateClearMenu()
    {
        yield return new WaitForSeconds(3.0f);
        anim.SetTrigger(hashClear);
    }
}
