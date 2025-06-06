using UnityEngine;

public class SquareModifier : MonoBehaviour
{
    [SerializeField] private float _sizeChangeStep = 0.1f;
    [SerializeField] private float _speedChangeStep = 0.5f;
    [SerializeField] private RandomMover _mover;
    [SerializeField] private GameObject _trap;

    public void IncreaseSpeed()
    {
        _mover.SetSpeed(_speedChangeStep);
    }

    public void DecreaseSize()
    {
        transform.localScale *= _sizeChangeStep;
    }

    public void Duplicate()
    {
        Instantiate(gameObject, transform.position, transform.rotation);
        Instantiate(_trap, _trap.transform.position, _trap.transform.rotation);
    }
}