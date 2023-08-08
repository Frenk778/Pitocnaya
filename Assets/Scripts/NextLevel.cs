using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Agava.YandexGames;

public class NextLevel : MonoBehaviour
{    
    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            LevelController.instance.isEndGame();            
        }
    }    
}