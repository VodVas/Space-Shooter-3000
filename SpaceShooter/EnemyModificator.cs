using UnityEngine;

public class EnemyModificator : MonoBehaviour
{
    [SerializeField] private float _scaleMin = 0.7f;
    [SerializeField] private float _scaleMax = 1.3f;
    [SerializeField] private float _rotationMin = 0f;
    [SerializeField] private float _rotationMax = 180f;

    private Transform _transform;

    private void Awake()
    {
        _transform = transform;
    }

    private void Start()
    {
        RandomizeSize();
        RandomizeRotation();
    }

    private void RandomizeSize()
    {
        float scaleFactor = Random.Range(_scaleMin, _scaleMax);

        _transform.localScale *= scaleFactor;
    }

    private void RandomizeRotation()
    {
        float rotationFactor = Random.Range(_rotationMin, _rotationMax);

        _transform.localEulerAngles = Vector3.forward * rotationFactor;
    }
}