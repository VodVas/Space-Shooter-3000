using UnityEngine;

public class PlayerMover : MonoBehaviour
{
    private void Update()
    {
        Move();
    }

    private void Move()
    {
        if (Input.GetMouseButton(0))
        {
            Vector2 mousePosition = Input.mousePosition;
            Vector2 realPosition = Camera.main.ScreenToWorldPoint(mousePosition);
            transform.position = realPosition;
        }
    }
}