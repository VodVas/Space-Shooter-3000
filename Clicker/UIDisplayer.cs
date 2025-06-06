using TMPro;
using UnityEngine;

public class UIDisplayer : MonoBehaviour
{
    [Header("UI References")]
    [SerializeField] private TMP_Text _scoreText;
    [SerializeField] private GameObject _gameOverPanel;
    [SerializeField] private TMP_Text _finalScoreText;

    public void UpdateScore(int value)
    {
        _scoreText.text = value.ToString();
    }

    public void ShowGameOver(int score)
    {
        _gameOverPanel.SetActive(true);

        Time.timeScale = 0;
        _finalScoreText.text = $"{score}";
    }
}