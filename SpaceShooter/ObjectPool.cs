using UnityEngine;
using UnityEngine.Pool;

public class ObjectPool : MonoBehaviour
{
    [SerializeField] private GameObject _prefab;
    [SerializeField] private int _defaultCapacity = 10;
    [SerializeField] private int _maxSize = 20;

    private IObjectPool<GameObject> _pool;

    private void Awake()
    {
        _pool = new ObjectPool<GameObject>(
            createFunc: CreatePooledObject,
            actionOnGet: OnTakeFromPool,
            actionOnRelease: OnReturnedToPool,
            actionOnDestroy: DestroyObject,
            defaultCapacity: _defaultCapacity,
            maxSize: _maxSize
        );
    }

    private GameObject CreatePooledObject() => Instantiate(_prefab);

    private void OnTakeFromPool(GameObject obj)
    {
        obj.SetActive(true);

        if (obj.TryGetComponent(out ITerminatable terminatable))
        {
            terminatable.Terminated += HandleObjectTermination;
        }
    }

    private void OnReturnedToPool(GameObject obj)
    {
        obj.SetActive(false);

        if (obj.TryGetComponent(out ITerminatable terminatable))
        {
            terminatable.Terminated -= HandleObjectTermination;
        }
    }

    private void DestroyObject(GameObject obj)
    {
        if (obj.TryGetComponent(out ITerminatable terminatable))
        {
            terminatable.Terminated -= HandleObjectTermination;
        }

        Destroy(obj);
    }

    private void HandleObjectTermination(ITerminatable terminatable)
    {
        if (terminatable is MonoBehaviour monoBehaviour)
        {
            ReleaseObject(monoBehaviour.gameObject);
        }
    }

    public GameObject GetObject(Vector3 position, Quaternion rotation)
    {
        GameObject obj = _pool.Get();
        obj.transform.SetPositionAndRotation(position, rotation);
        return obj;
    }

    public void ReleaseObject(GameObject obj)
    {
        if (obj.activeSelf)
            _pool.Release(obj);
    }
}