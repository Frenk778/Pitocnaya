//using UnityEngine;
//using UnityEngine.UI;
//using System;

//[RequireComponent(typeof(AudioSource))]

//public class VolumeSetting : MonoBehaviour
//{
//    public Slider sliderVelue;
//    private AudioSource audioSource;    

//    private void Start()
//    {
//        audioSource = GetComponent<AudioSource>();
//        audioSource.volume = sliderVelue.value;

//        if (UnityEngine.SceneManagement.SceneManager.GetActiveScene().name == "MainMenu")
//        {            
//            sliderVelue.interactable = true;
//        }
//    }

//    private void OnEnable() => sliderVelue.onValueChanged.AddListener(param => ChangeVolume(param));

//    private void OnDisable() => sliderVelue.onValueChanged.RemoveListener(param => ChangeVolume(param));

//    public void ChangeVolume(float currentValue) => audioSource.volume = currentValue;    
//}

using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

[RequireComponent(typeof(AudioSource))]
public class VolumeSetting : MonoBehaviour
{
    public Slider sliderVelue;
    private AudioSource audioSource;

    private void Start()
    {
        audioSource = GetComponent<AudioSource>();
        audioSource.volume = sliderVelue.value;

        SceneManager.sceneLoaded += OnSceneLoaded;
    }

    private void OnDestroy()
    {
        SceneManager.sceneLoaded -= OnSceneLoaded;
    }

    private void OnEnable()
    {
        sliderVelue.onValueChanged.AddListener(ChangeVolume);
    }

    private void OnDisable()
    {
        sliderVelue.onValueChanged.RemoveListener(ChangeVolume);
    }

    public void ChangeVolume(float currentValue)
    {
        audioSource.volume = currentValue;
    }

    private void OnSceneLoaded(Scene scene, LoadSceneMode mode)
    {
        if (scene.name == "MainMenu")
        {
            // Остановка воспроизведения аудио при входе в главное меню
            audioSource.Stop();
        }
    }
}
