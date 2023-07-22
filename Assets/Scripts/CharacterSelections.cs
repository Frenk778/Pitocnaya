using System.Collections;
using System.Collections.Generic;
using UnityEngine.SceneManagement;
using UnityEngine;

public class CharacterSelections : MonoBehaviour
{
    public GameObject[] characters;
    public int selectCharacters = 0;

    public void NextCgaracter()
    {
        characters[selectCharacters].SetActive(false);
        selectCharacters = (selectCharacters + 1) % characters.Length;
        characters[selectCharacters].SetActive(true);
    }

    public void PreviousCharacter()
    {
        characters[selectCharacters].SetActive(false);
        selectCharacters--;
        if (selectCharacters<0)
        {
            selectCharacters += characters.Length;
        }

        characters[selectCharacters].SetActive(true);
    }

    public void StartGame()
    {
        PlayerPrefs.SetInt("selectCharacters", selectCharacters);
        SceneManager.LoadScene(3, LoadSceneMode.Single);
    }    
}