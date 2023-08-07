using System.Collections;
using System.Collections.Generic;
using UnityEngine.SceneManagement;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class CharacterSelections : MonoBehaviour
{
    //[SerializeField] private GameObject[] characters;
    [SerializeField] private Hero[] _characters;
    [SerializeField] private int _selectCharacters = 0;
    [SerializeField] private CollactableControl _money;
    [SerializeField] private Button _button;

    private TMP_Text _text;

    private void Awake()
    {
        _text = _button.GetComponentInChildren<TMP_Text>();
    }


    public void NextCgaracter()
    {
        //_text.text = _characters[_selectCharacters].Price.ToString();

        //if (CollactableControl.CoinCount >= _characters[_selectCharacters].Price && _selectCharacters != 0)
        //{
        //    _button.gameObject.SetActive(true);
        //}
        //else
        //{
        //    _button.gameObject.SetActive(false);
        //}

        _characters[_selectCharacters].gameObject.SetActive(false);
        _selectCharacters = (_selectCharacters + 1) % _characters.Length;
        _characters[_selectCharacters].gameObject.SetActive(true);
    }

    public void PreviousCharacter()
    {
        //_text.text = _characters[_selectCharacters].Price.ToString();

        //if (CollactableControl.CoinCount >= _characters[_selectCharacters].Price && _selectCharacters != 0)
        //{
        //    _button.gameObject.SetActive(true);
        //}
        //else
        //{
        //    _button.gameObject.SetActive(false);
        //}


        _characters[_selectCharacters].gameObject.SetActive(false);
        _selectCharacters--;
        if (_selectCharacters < 0)
        {
            _selectCharacters += _characters.Length;
        }

        _characters[_selectCharacters].gameObject.SetActive(true);
    }

    public void StartGame()
    {
        PlayerPrefs.SetInt("selectCharacters", _selectCharacters);
        SceneManager.LoadScene(3, LoadSceneMode.Single);
    }    
}