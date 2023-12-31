using Agava.YandexGames;
using Lean.Localization;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class LeaderboardOpener : MonoBehaviour
{
    private const string AnonymousName = "Anonymous";
    private const string LeaderboardName = "LeaderBoard";

    [SerializeField] private GameObject _leaderboardPanel;
    [SerializeField] private GameObject _notAuthorizedPanel;
    [SerializeField] private Button _openLeaderboardButton;
    [SerializeField] private Button _authorizeButton;
    [SerializeField] private Button _declineAuthorizeButton;
    [SerializeField] private TMP_Text[] _playersName;
    [SerializeField] private TMP_Text[] _playersScore;
    [SerializeField] private int _maxLength;

    public void OnOpenLeaderBoard()
    {
        if (PlayerAccount.IsAuthorized)
        {
            OnGetLeaderboardEntriesButtonClick();
            _leaderboardPanel.SetActive(true);
        }
        else
        {
            PlayerAccount.Authorize();
            _notAuthorizedPanel.gameObject.SetActive(true);
        }
    }

    public void OnGetLeaderboardEntriesButtonClick()
    {
        Agava.YandexGames.Leaderboard.GetEntries(LeaderboardName, (result) =>
        {
            Debug.Log($"My rank = {result.userRank}");
            ClearLeaderboardPanel();

            for (int i = 0; i < result.entries.Length; i++)
            {
                string name = result.entries[i].player.publicName;
                int score = result.entries[i].score;
                int rank = result.entries[i].rank;

                if (string.IsNullOrEmpty(name))
                {
                    if (LeanLocalization.GetFirstCurrentLanguage() == Constants.RussianCode)
                        name = "������";
                    else if (LeanLocalization.GetFirstCurrentLanguage() == Constants.EnglishCode)
                        name = AnonymousName;
                    else if (LeanLocalization.GetFirstCurrentLanguage() == Constants.TurkishCode)
                        name = "Anonim";
                    else
                        name = "������";
                }

                _playersName[i].text = TextOprimizer(name);
                _playersScore[i].text = $"{score}";
            }
        });
    }

    private void ClearLeaderboardPanel()
    {
        foreach (var text in _playersName)
        {
            text.text = string.Empty;
        }

        foreach (var text in _playersScore)
        {
            text.text = string.Empty;
        }
    }

    private string TextOprimizer(string name)
    {
        string nameToLower = name.ToLower();

        if (nameToLower.Length > _maxLength)
            return nameToLower.Substring(0, _maxLength);
        else
            return nameToLower;
    }
}
