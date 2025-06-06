using UnityEngine;

public class RandomMover : MonoBehaviour
{
    [Header("Movement Settings")]
    [SerializeField] private float _speed = 3f;
    [SerializeField] private float _xRange = 5f;
    [SerializeField] private float _yRange = 3f;
    [SerializeField] private float _reachedThreshold = 0.1f;

    private Vector2 _targetPosition;

    private void Start()
    {
        GenerateNewTarget();
    }

    private void Update()
    {
        transform.position = Vector2.MoveTowards(transform.position, _targetPosition, _speed * Time.deltaTime);

        if (Vector2.Distance(transform.position, _targetPosition) < _reachedThreshold)
        {
            GenerateNewTarget();
        }
    }

    public void SetSpeed(float speed)
    {
        _speed += speed;
    }

    private void GenerateNewTarget()
    {
        _targetPosition = new Vector2(Random.Range(-_xRange, _xRange), Random.Range(-_yRange, _yRange));
    }
}