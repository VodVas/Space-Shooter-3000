using UnityEngine;

public class Projectile : MonoBehaviour, ITerminatable
{
    public event System.Action<ITerminatable> Terminated;
    private bool _isTerminated;

    private void OnEnable() => _isTerminated = false;

    public void ReturnToPool()
    {
        if (_isTerminated) return;

        _isTerminated = true;

        Terminated?.Invoke(this);
    }
}