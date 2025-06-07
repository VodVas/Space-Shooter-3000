using UnityEngine;

public class EnemyModificator : MonoBehaviour
{
    [SerializeField, Range(0.1f, 1f)] private float _scaleMin = 0.7f;
    [SerializeField, Range(0.1f, 2f)] private float _scaleMax = 1.3f;
    [SerializeField, Range(0f, 180f)] private float _rotationMin = 0f;
    [SerializeField, Range(181f, 360f)] private float _rotationMax = 180f;

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