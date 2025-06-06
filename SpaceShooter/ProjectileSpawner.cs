using UnityEngine;

public class ProjectileSpawner : MonoBehaviour
{
    [SerializeField] private Transform _targetPosition;
    [SerializeField] private float _shootInterval;

    private ObjectPool _pool;
    private float _shootTimer = 0f;

    private void Awake()
    {
        _pool = GetComponent<ObjectPool>();

        if (_pool == null)
        {
            Debug.Log("Pool not assign", this);
            enabled = false;
            return;
        }
    }

    private void Update()
    {
        _shootTimer -= Time.deltaTime;

        Shoot();
    }

    private void Shoot()
    {
        if (_shootTimer <= 0)
        {
            _pool.GetObject(_targetPosition.position, _targetPosition.rotation);

            _shootTimer = _shootInterval;
        }
    }
}