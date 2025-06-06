using UnityEngine;

public class EnemySpawner : MonoBehaviour
{
    [SerializeField] private GameObject _enemy;
    [SerializeField] private Transform _leftBorder;
    [SerializeField] private Transform _rightBorder;
    [SerializeField] private float _spawnInterval;
    [SerializeField] private float _spawnTimer;
    [SerializeField] private GameSpeedController _speedController;
    [SerializeField] private ObjectPool _pool;

    private void Update()
    {
        _spawnTimer -= Time.deltaTime;

        if (_spawnTimer <= 0)
        {
            Execute();
        }
    }

    private void Execute()
    {
        float randomX = Random.Range(_leftBorder.position.x, _rightBorder.position.x);

        Vector2 newPosition = transform.position;
        newPosition.x = randomX;

        GameObject enemy = _pool.GetObject(newPosition, Quaternion.identity);

        if (enemy.TryGetComponent(out EnemyMover mover))
            mover.Initialize(_speedController);

        _spawnTimer = _spawnInterval;
    }
}