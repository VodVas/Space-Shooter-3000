using UnityEngine;

public abstract class Destroyer<T> : MonoBehaviour where T : Component
{
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.TryGetComponent(out ITerminatable terminatable))
        {
            terminatable.ReturnToPool();
        }
    }
}