using System.Collections;
using System.Collections.Generic;
using UnityEngine.SceneManagement;
using UnityEngine;
using UnityEngine.UI;
using System;

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

        if (characters[selectCharacters].GetComponent<Hero>().HasCanvas)
        {
            List<int> purchasedCharacters = new List<int>();
            if (PlayerPrefs.HasKey("purchasedCharacters"))
            {
                string serializedData = PlayerPrefs.GetString("purchasedCharacters");
                purchasedCharacters = new List<int>(Array.ConvertAll(serializedData.Split(','), int.Parse));
            }

            if (purchasedCharacters.Contains(selectCharacters))
            {
                characters[selectCharacters].GetComponent<Hero>().PriceCanvas.gameObject.SetActive(false);
            }
        }
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

        if (characters[selectCharacters].GetComponent<Hero>().HasCanvas)
        {
            List<int> purchasedCharacters = new List<int>();
            if (PlayerPrefs.HasKey("purchasedCharacters"))
            {
                string serializedData = PlayerPrefs.GetString("purchasedCharacters");
                purchasedCharacters = new List<int>(Array.ConvertAll(serializedData.Split(','), int.Parse));
            }

            if (purchasedCharacters.Contains(selectCharacters))
            {
                characters[selectCharacters].GetComponent<Hero>().PriceCanvas.gameObject.SetActive(false);
            }
        }
    }

    public void StartGame()
    {
        int currentCoins = CollactableControl.CoinCount;

        List<int> purchasedCharacters = new List<int>();

        if (PlayerPrefs.HasKey("purchasedCharacters"))
        {
            string serializedData = PlayerPrefs.GetString("purchasedCharacters");
            purchasedCharacters = new List<int>(Array.ConvertAll(serializedData.Split(','), int.Parse));
        }

        if (purchasedCharacters.Contains(selectCharacters) || currentCoins >= characters[selectCharacters].GetComponent<Hero>()._characterCost)
        {
            if (!purchasedCharacters.Contains(selectCharacters))
            {
                CollactableControl.CoinCount -= characters[selectCharacters].GetComponent<Hero>()._characterCost;
                currentCoins = CollactableControl.CoinCount;

                purchasedCharacters.Add(selectCharacters);
                string serializedData = string.Join(",", purchasedCharacters);
                PlayerPrefs.SetString("purchasedCharacters", serializedData);

                if (characters[selectCharacters].GetComponent<Hero>().HasCanvas)
                {
                    characters[selectCharacters].GetComponent<Hero>().PriceCanvas.gameObject.SetActive(false);
                }
            }

            PlayerPrefs.SetInt("CoinCount", currentCoins);
            PlayerPrefs.Save();

            PlayerPrefs.SetInt("selectCharacters", selectCharacters);
            SceneManager.LoadScene(3, LoadSceneMode.Single);
        }
        else
        {
            messageObject.SetActive(true);
            messageImage.enabled = true;

            StartCoroutine(DeactivateMessageAfterDelay(2f));
        }        
    }

    private IEnumerator DeactivateMessageAfterDelay(float delay)
    {
        yield return new WaitForSeconds(delay);
        messageImage.enabled = false;
        messageObject.SetActive(false);
    }
}