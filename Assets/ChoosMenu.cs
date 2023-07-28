using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class ChoosMenu : MonoBehaviour
{
    public Button level2b;
    public Button level3b;
    public Button level4b;
    public Button level5b;
    public Button level6b;
    public Button level7b;
    public Button level8b;
    public Button level9b;
    public Button level10b;
    int levelComplete;


    private void Awake()
    {
        levelComplete = PlayerPrefs.GetInt("LevelComplete");
        Debug.Log(levelComplete + "startlevelGetInt");
        level2b.interactable = false;
        level3b.interactable = false;
        level4b.interactable = false;
        level5b.interactable = false;
        level6b.interactable = false;
        level7b.interactable = false;
        level8b.interactable = false;
        level9b.interactable = false;
        level10b.interactable = false;

        switch (levelComplete)
        {
            case 1:
                level2b.interactable = true;
                break;

            case 2:
                level2b.interactable = true;
                level3b.interactable = true;
                break;

            case 3:
                level2b.interactable = true;
                level3b.interactable = true;
                level4b.interactable = true;
                break;

            case 4:
                level2b.interactable = true;
                level3b.interactable = true;
                level4b.interactable = true;
                level5b.interactable = true;
                break;

            case 5:
                level2b.interactable = true;
                level3b.interactable = true;
                level4b.interactable = true;
                level5b.interactable = true;
                level6b.interactable = true;
                break;

            case 6:
                level2b.interactable = true;
                level3b.interactable = true;
                level4b.interactable = true;
                level5b.interactable = true;
                level6b.interactable = true;
                level7b.interactable = true;
                break;

            case 7:
                level2b.interactable = true;
                level3b.interactable = true;
                level4b.interactable = true;
                level5b.interactable = true;
                level6b.interactable = true;
                level7b.interactable = true;
                level8b.interactable = true;
                break;

            case 8:
                level2b.interactable = true;
                level3b.interactable = true;
                level4b.interactable = true;
                level5b.interactable = true;
                level6b.interactable = true;
                level7b.interactable = true;
                level8b.interactable = true;
                level9b.interactable = true;
                break;

            case 9:
                level2b.interactable = true;
                level3b.interactable = true;
                level4b.interactable = true;
                level5b.interactable = true;
                level6b.interactable = true;
                level7b.interactable = true;
                level8b.interactable = true;
                level9b.interactable = true;
                level10b.interactable = true;
                break;
        }
    }

    public void LoadTo(int level)
    {
        SceneManager.LoadScene(level);
    }

    public void Reset()
    {
        level2b.interactable = false;
        level3b.interactable = false;
        level4b.interactable = false;
        level5b.interactable = false;
        level6b.interactable = false;
        level7b.interactable = false;
        level8b.interactable = false;
        level9b.interactable = false;
        level10b.interactable = false;
        PlayerPrefs.DeleteAll();
    }
}