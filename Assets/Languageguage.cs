using UnityEngine;
using UnityEngine.SceneManagement;
using Lean.Localization;
using Agava.YandexGames;

public class Languageguage : MonoBehaviour
{
    [SerializeField] private LeanLocalization _leanLocalization;

    private const string EnglishLanguage = "en";
    private const string RussionLanguage = "ru";
    private const string TurkishLanguage = "tr";

    private void Awake()
    {
#if UNITY_WEBGL && !UNITY_EDITOR
        SetLeanguage();
#endif

        //_leanLocalization.CurrentLanguage = Lenguage.English;
    }


    private void SetLeanguage()
    {
        switch (YandexGamesSdk.Environment.i18n.lang)
        {
            case EnglishLanguage:
                _leanLocalization.CurrentLanguage = Lenguage.English;
                break;

            case RussionLanguage:
                _leanLocalization.CurrentLanguage = Lenguage.Russian;
                break;

            case TurkishLanguage:
                _leanLocalization.CurrentLanguage = Lenguage.Turkish;
                break;

            default:
                _leanLocalization.CurrentLanguage = Lenguage.Russian;
                break;
        }
    }
}