using System.Collections;
using System.Collections.Generic;
using UnityEngine.SceneManagement;
using UnityEngine;
using UnityEngine.UI;

public class TestCharacterSelection : MonoBehaviour
{
    [SerializeField] private GameObject[] characters;
    [SerializeField] private int selectCharacters = 0;
    [SerializeField] private Image messageImage;

    [SerializeField] private GameObject messageObject;

    private void Start()
    {
        messageObject.SetActive(false);
        messageImage.enabled = false;
    }


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
        if (selectCharacters < 0)
        {
            selectCharacters += characters.Length;
        }

        characters[selectCharacters].SetActive(true);
    }

    public void StartGame()
    {        
        int currentCoins = CollactableControl.CoinCount;
        
        if (currentCoins >= characters[selectCharacters].GetComponent<Hero>()._characterCost)
        {            
            CollactableControl.CoinCount -= characters[selectCharacters].GetComponent<Hero>()._characterCost;
            
            PlayerPrefs.SetInt("selectCharacters", selectCharacters);
            SceneManager.LoadScene(3, LoadSceneMode.Single);
        }
        else
        {
            messageObject.SetActive(true);
            messageImage.enabled = true;
           
            StartCoroutine(DeactivateMessageAfterDelay(2f));

        }

        //PlayerPrefs.SetInt("selectCharacters", selectCharacters);
        //SceneManager.LoadScene(3, LoadSceneMode.Single);
    }



    private IEnumerator DeactivateMessageAfterDelay(float delay)
    {
        yield return new WaitForSeconds(delay);
        messageImage.enabled = false;
        messageObject.SetActive(false);
    }
}