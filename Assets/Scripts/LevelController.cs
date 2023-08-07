using UnityEngine;
using UnityEngine.SceneManagement;


public class LevelController : MonoBehaviour
{
    public static LevelController instance = null;
    private int sceneIndex;
    private int levelComplete;

    private void Start()
    {
        if (instance == null)
        {
            instance = this;
        }

        sceneIndex = SceneManager.GetActiveScene().buildIndex;
        levelComplete = PlayerPrefs.GetInt("LevelComplete");
    }

    public void isEndGame()
    {
        if (sceneIndex == 16)
        {
            Invoke("LoadMainMenu", 1f);
        }
        else
        {
            if (levelComplete < sceneIndex)
            {
                PlayerPrefs.SetInt("LevelComplete", sceneIndex - 3);
            }

            Invoke("NextLevel", 0.1f);
        }
    }

    public void NextLevel()
    {
        SceneManager.LoadScene(sceneIndex + 1);
    }

    public void LoadMainMenu()
    {
        SceneManager.LoadScene("LevelChoose");
    }    
}