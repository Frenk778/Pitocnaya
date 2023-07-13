using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class DestroyByBoundary : MonoBehaviour
{
    [SerializeField] private string _levelToReset = "Level 1";      

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player")) 
        {
            RestartLevel(); 
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