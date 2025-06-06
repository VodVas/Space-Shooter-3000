using UnityEngine;

public class EnemyMover : MonoBehaviour
{
    [SerializeField] private float _speed = 5f;

    private GameSpeedController _speedController;

    public void Initialize(GameSpeedController speedController)
    {
        _speedController = speedController;
    }

    private void Update() => CalculateSpeed();

    private void CalculateSpeed()
    {
        if (_speedController == null) return;

        transform.position += Vector3.down *
            (_speed + _speedController.CurrentSpeed) * Time.deltaTime;
    }
}