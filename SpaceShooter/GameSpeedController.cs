using UnityEngine;

public class GameSpeedController : MonoBehaviour
{
    [SerializeField, Range(0.1f, 10f)] private float _initialSpeed = 1f;
    [SerializeField, Range(0.5f, 50f)] private float _maxSpeed = 5f;
    [SerializeField, Range(0.01f, 5f)] private float _accelerationRate = 0.1f;

    public float CurrentSpeed { get; private set; }

    private void Start()
    {
        CurrentSpeed = _initialSpeed;
    }

    private void Update()
    {
        if (CurrentSpeed < _maxSpeed)
        {
            CurrentSpeed += _accelerationRate * Time.deltaTime;
        }
    }
}