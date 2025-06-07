using UnityEngine;
using System.Collections;

[RequireComponent(typeof(Collider2D))]
public class ProjectileMover : MonoBehaviour
{
    [SerializeField, Range (0.5f, 10f)] private float _speed = 5f;
    [SerializeField] private float _lifeTime = 2f;
    [SerializeField] private Vector2 _direction = Vector2.up;

    private Projectile _projectile;
    private Coroutine _lifeTimeRoutine;

    private void Awake()
    {
        _projectile = GetComponent<Projectile>();

        GetComponent<Collider2D>().isTrigger = true;
    }

    private void OnEnable()
    {
        _lifeTimeRoutine = StartCoroutine(ReturnAfterLifetime());
    }

    private void OnDisable()
    {
        if (_lifeTimeRoutine != null)
            StopCoroutine(_lifeTimeRoutine);
    }

    private IEnumerator ReturnAfterLifetime()
    {
        yield return new WaitForSeconds(_lifeTime);
        _projectile?.ReturnToPool();
    }

    private void Update()
    {
        transform.position += (Vector3)(_direction * _speed * Time.deltaTime);
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (!other.isTrigger)
            _projectile?.ReturnToPool();
    }
}