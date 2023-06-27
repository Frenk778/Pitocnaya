using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{
    public void PlayeGame()
    {       
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
    } 


    public void QuitGame()
    {
        Debug.Log("Игра закрылась");
        Application.Quit();
    }
}
