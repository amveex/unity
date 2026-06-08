using UnityEngine;
using UnityEngine.InputSystem;

public class MoveToClick : MonoBehaviour
{
    private float speed = 2f;
    private bool isMoving;

    private Vector2 screenPos;
    private Vector2 clickPos;
    private Vector2 moveToPos;
    private Vector3 direction;

    void Update()
    {
        if (Mouse.current.leftButton.wasPressedThisFrame)
        {
            screenPos = Mouse.current.position.ReadValue();
            clickPos = new Vector3(screenPos.x, screenPos.y);
            moveToPos = Camera.main.ScreenToWorldPoint(clickPos);

            isMoving = true;
        }

        if (isMoving)
        {
            transform.position = Vector3.MoveTowards
                (
                transform.position,
                moveToPos,
                speed * Time.deltaTime
                );

            direction = new Vector3
                (
                moveToPos.x - transform.position.x,
                moveToPos.y - transform.position.y
                );

            transform.up += direction;
        }
    }
}
