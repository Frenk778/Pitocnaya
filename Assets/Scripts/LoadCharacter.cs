using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LoadCharacter : MonoBehaviour
{
    public GameObject[] characterPrefacbs;
    public Transform spawPoint;


    private void Start()
    {
        int selectCharacters = PlayerPrefs.GetInt("selectCharacters");
        GameObject prefab = characterPrefacbs[selectCharacters];
        GameObject clone = Instantiate(prefab, spawPoint.position, Quaternion.identity);
    }
}
