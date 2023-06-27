using UnityEngine;
using UnityEngine.SceneManagement;

public class NextLevelTrigger : MonoBehaviour
{
    public string nextLevelName; 
    public Transform spawnPoint; 

    private void OnTriggerEnter(Collider other)
    {
       
        if (other.CompareTag("Player"))
        {            
            SceneManager.LoadScene(nextLevelName);
            
            other.transform.position = spawnPoint.position;
        }
    }
}