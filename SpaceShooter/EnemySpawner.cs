using UnityEngine;

public class EnemySpawner : MonoBehaviour
{
    [SerializeField] private GameObject _enemy;
    [SerializeField] private GameSpeedController _speedController;
    [SerializeField] private ObjectPool _pool;
    [SerializeField] private Transform _leftBorder;
    [SerializeField] private Transform _rightBorder;
    [SerializeField,Range (0.1f, 2f)] private float _spawnInterval = 0.5f;
    [SerializeField, Range(0f, 1f)] private float _spawnTimer = 0f;

    private void Awake()
    {
        if (_enemy == null || _pool == null || _speedController == null)
        {
            Debug.Log("Dependencies not assign", this);
            enabled = false;
            return;
        }
    }

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