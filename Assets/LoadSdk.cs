using System.Collections;
using UnityEngine;
using Agava.YandexGames;
using UnityEngine.SceneManagement;

public class LoadSdk : MonoBehaviour
{
    private void Awake()
    {        
        StartCoroutine(LoadYandexSdk());
    }

    private IEnumerator LoadYandexSdk()
    {
        yield return YandexGamesSdk.Initialize(() => SceneManager.LoadScene(1));
    }
}
