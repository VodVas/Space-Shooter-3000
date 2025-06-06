using System;
using UnityEngine;

public class Enemy : MonoBehaviour, ITerminatable
{
    public event Action<ITerminatable> Terminated;

    public void ReturnToPool()
    {
        Terminated?.Invoke(this);
    }
}