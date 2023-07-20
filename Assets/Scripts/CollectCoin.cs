using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CollectCoin : MonoBehaviour
{
    private void OnTriggerEnter(Collider other)
    {
        CollactableControl.CoinCount += 1;
        //this.gameObject.SetActive(false);
        Destroy(gameObject);
    }
}
