using UnityEngine;
using UnityEngine.SceneManagement;

public class LevelRestart : MonoBehaviour
{
    [SerializeField] private string _levelToReset = "Level 1";

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            Hero hero = other.GetComponent<Hero>();
            if (hero != null)
            {
                if (hero.Health <= 0)
                {
                    RestartLevel();
                }
            }
        }
        else
        {
            Destroy(other.gameObject);
        }
    }

    private void RestartLevel()
    {
        SceneManager.LoadScene(_levelToReset);        
    }
}