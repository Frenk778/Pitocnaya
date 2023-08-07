using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CollectCoin : MonoBehaviour
{
    private void OnTriggerEnter(Collider other)
    {
        CollactableControl.CoinCount += 1;        
        gameObject.SetActive(false);

        PlayerPrefs.SetInt("CoinCount", CollactableControl.CoinCount);
        PlayerPrefs.Save();
    }
}