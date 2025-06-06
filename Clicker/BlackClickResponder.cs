using UnityEngine;
using UnityEngine.EventSystems;

public class BlackClickResponder : MonoBehaviour, IPointerDownHandler
{
    [SerializeField] private GameLogic _logic;
    [SerializeField] private SquareModifier _squareModifier;

    //private void OnMouseDown()
    //{
    //    _logic.IncreaseScore();
    //    _squareModifier.IncreaseSpeed();
    //    _squareModifier.DecreaseSize();
    //    _squareModifier.Duplicate();
    //}

    public void OnPointerDown(PointerEventData eventData)
    {
        _logic.IncreaseScore();
        _squareModifier.IncreaseSpeed();
        _squareModifier.DecreaseSize();
        _squareModifier.Duplicate();
    }
}