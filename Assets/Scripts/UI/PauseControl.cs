using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PauseControl : MonoBehaviour
{
    bool isPaused;
    public GameObject panelPause;

    void OnEnable()
    {
        isPaused = false;

        if (Time.timeScale == 0)
        {
            isPaused = true;
        }

        Time.timeScale = 0.0f;
    }

    void OnDisable()
    {
        if (isPaused == false)
        {
            Time.timeScale = 1.0f;
        }
    }
}
