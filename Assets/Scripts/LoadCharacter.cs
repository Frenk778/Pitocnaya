using Agava.YandexGames;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LoadCharacter : MonoBehaviour
{
    [SerializeField] private Player[] _characterPrefacbs;
    [SerializeField] private Transform _spawPoint;
    [SerializeField] private CameraFollow _cameraFollow;
    [SerializeField] private EnemyScript[] _enemies;

    private void Start()
    {
        InterstitialAd.Show(OpenCallback, CloseCallback);
        int selectCharacters = PlayerPrefs.GetInt("selectCharacters");
        Player prefab = _characterPrefacbs[selectCharacters];
        Player clone = Instantiate(prefab, _spawPoint.position, Quaternion.identity);
        _cameraFollow.SetTarget(clone.Hips);

        foreach (EnemyScript enemy in _enemies)
        {
            enemy.SetTarget(clone.Hips);
        }

        Debug.Log("Reklama");
    }

    private void OpenCallback()
    {
        Time.timeScale = 0f;
        Debug.Log("Reklama");
    }

    private void CloseCallback(bool isClose)
    {
        if (isClose)
        {
            Time.timeScale = 1f;
            Debug.Log("Reklama zakrita");
        }
    }
}