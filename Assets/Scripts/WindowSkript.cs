using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WindowSkript : MonoBehaviour
{
    public PauseMenu pauseMenu;
    bool isPaused = false;

    private void OnGUI()
    {
        if (isPaused)
        {
            pauseMenu.PauseGame();
        }
        else
        {
            pauseMenu.ResumeGame();
        }
    }

    private void OnApplicationFocus(bool focus)
    {
        isPaused = !focus;
    }

    private void OnApplicationPause(bool pause)
    {
        isPaused = pause;
    }


    private void Awake()
    {
        Application.runInBackground = true;
    }
}
