using UnityEngine;
using UnityEngine.EventSystems;

public class RedClickResponder : MonoBehaviour, IPointerDownHandler
{
    [SerializeField] private GameLogic _logic;

    //private void OnMouseDown()
    //{
    //    _logic.EndGame();
    //}

    public void OnPointerDown(PointerEventData eventData)
    {
        _logic.EndGame();
    }
}