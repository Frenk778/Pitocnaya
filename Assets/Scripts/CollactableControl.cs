using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class CollactableControl : MonoBehaviour
{
    [SerializeField] private static int _coinCount;
    [SerializeField] private TextMeshProUGUI _coinCountDisplay;

    public static int CoinCount { get => _coinCount; set => _coinCount = value; }

    private void Update()
    {
        _coinCountDisplay.text = CoinCount.ToString();
    }
}
