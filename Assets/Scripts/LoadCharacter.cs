using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LoadCharacter : MonoBehaviour
{
    [SerializeField] private Player[] _characterPrefacbs;
    [SerializeField] private Transform _spawPoint;
    public CameraFollow CameraFollow;


    private void Start()
    {
        int selectCharacters = PlayerPrefs.GetInt("selectCharacters");
        Player prefab = _characterPrefacbs[selectCharacters];
        Player clone = Instantiate(prefab, _spawPoint.position, Quaternion.identity);
        CameraFollow.SetTarget(clone.Hips);
    }
}
