using UnityEngine;
using UnityEngine.SceneManagement;

public class PauseMenu : MonoBehaviour
{
    [SerializeField] private GameObject _pauseMenu;    

    public static bool isPaused;

    void Start()
    {
        _pauseMenu.SetActive(false);              
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            if (isPaused)
            {
                ResumeGame();
            }
            else
            {
                PauseGame();
            }
        }
    }


    private void OnGUI()
    {
        if (isPaused)
        {
            PauseGame();
        }
        else
        {
            ResumeGame();
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


    public void PauseGame()
    {
        _pauseMenu.SetActive(true);
        Time.timeScale = 0f;
        isPaused = true;        
    }

    public void ResumeGame()
    {
        _pauseMenu.SetActive(false);
        Time.timeScale = 1f;
        isPaused = false;
    }

    public void GoToMainMenu()
    {
        Time.timeScale = 1f;
        SceneManager.LoadScene("MainMenu");
    }        
}