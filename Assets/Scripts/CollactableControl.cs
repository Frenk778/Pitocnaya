using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class CollactableControl : MonoBehaviour
{   
    [SerializeField] private static int _coinCount;
    [SerializeField] private TextMeshProUGUI _coinCountDisplay;

    public static int CoinCount
    {
        get => _coinCount;
        set
        {            
            _coinCount = Mathf.Max(value, 0);
        }
    }

    private void Awake()
    {        
        CoinCount = PlayerPrefs.GetInt("CoinCount", 0);
    }

    private void Update()
    {
        _coinCountDisplay.text = CoinCount.ToString();
    }
}