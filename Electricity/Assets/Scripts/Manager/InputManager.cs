using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InputManager : MonoBehaviour
{
    public PauseMenu pauseMenu;

    private const float pasueDuration = 1.0f;
    private bool isPause = false;

    void Start() {
        isPause = false;
    }

    void Update()
    {
        if (Input.GetKey(KeyCode.Escape)) 
        {
            if (!isPause)
                StartCoroutine(TimePause(pasueDuration));
            else 
                StartCoroutine(TimePause(pasueDuration));
        }
        if (Input.GetKey("R")) 
        {

        }
    }

    private IEnumerator TimePause(float slowdownDuration) {
        float startScale = Time.timeScale;
        float timeElapsed = 0f;

        while (timeElapsed < slowdownDuration) {
            timeElapsed += Time.unscaledDeltaTime;
            Time.timeScale = Mathf.Lerp(startScale, 0, timeElapsed / slowdownDuration);
            Time.fixedDeltaTime = Time.timeScale * 0.02f;
            yield return null;
        }

        Time.timeScale = 0;
    }
    
    private IEnumerator TimeResume(float duration)
    {
        float startScale = Time.timeScale; // should be 0 when resuming
        float timeElapsed = 0f;

        while (timeElapsed < duration)
        {
            timeElapsed += Time.unscaledDeltaTime;
            Time.timeScale = Mathf.Lerp(startScale, 1, timeElapsed / duration);
            Time.fixedDeltaTime = Time.timeScale * 0.02f;
            yield return null;
        }

        Time.timeScale = 1;
    }
}
