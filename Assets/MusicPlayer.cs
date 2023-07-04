using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MusicPlayer : MonoBehaviour
{
    public static AudioSource _audioSource;

    private void Awake()
    {
        if (_audioSource == null)
        {
            GameObject audioManager = GameObject.Find("AudioManager");
            _audioSource = audioManager.GetComponent<AudioSource>();
            DontDestroyOnLoad(_audioSource);
        }
    }
}
