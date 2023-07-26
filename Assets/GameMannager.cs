using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameMannager : MonoBehaviour
{
    public void LoadNextLevel()
    {
        int currentLevel = SceneManager.GetActiveScene().buildIndex;
        int nextLevel = currentLevel + 1;
        SceneManager.LoadScene(nextLevel);
    }

    public void RestartLevel()
    {
        int currentLevel = SceneManager.GetActiveScene().buildIndex;
        SceneManager.LoadScene(currentLevel);
    }

    public void SaveCurrentGame()
    {
        int currentLevel = SceneManager.GetActiveScene().buildIndex;
        int lives = 3; 
        int score = 0;
        SaveGame.instance.SaveGames(currentLevel, lives, score);
    }

    public void LoadSavedGame()
    {
        int currentLevel, lives, score;
        SaveGame.instance.LoadGame(out currentLevel, out lives, out score);
        SceneManager.LoadScene(currentLevel);
        
    }
}
