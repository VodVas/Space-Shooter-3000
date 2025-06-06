using UnityEngine;

public class GameLogic : MonoBehaviour
{
    [Header("Game Settings")]
    [SerializeField] private UIDisplayer _ui;

    private int _score;
    private bool _isGameActive = true;

    public void IncreaseScore()
    {
        if (!_isGameActive) return;

        _score++;
        _ui.UpdateScore(_score);
    }

    public void EndGame()
    {
        _isGameActive = false;
        _ui.ShowGameOver(_score);
    }

    public void RestartGame()
    {
        UnityEngine.SceneManagement.SceneManager.LoadScene(0);
        Time.timeScale = 1.0f;
    }
}