using UnityEngine;

public class SceneRestartButton : MonoBehaviour
{
    [SerializeField] private GameLogic _logic;

    public void OnClick()
    {
        _logic.RestartGame();
    }
}