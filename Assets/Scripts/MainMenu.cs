using UnityEngine;
using UnityEngine.SceneManagement;
using Lean.Localization;
using Agava.YandexGames;

public class MainMenu : MonoBehaviour
{
    [SerializeField] private LeanLocalization _leanLocalization;   

    public void PlayeGame()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
    }

    public void PauseGame()
    {
        Time.timeScale = 0f;
    }

    public void ResumeGame()
    {
        Time.timeScale = 1f;
    }
}