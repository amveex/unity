using UnityEngine;

public class MoveToClick : MonoBehaviour
{
    private float speed = 3f;
    private bool isMoving;
    private Vector3 mouseClick;
    private Vector3 direction;
    private Vector3 velocity = Vector3.zero;

    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            mouseClick = Camera.main.ScreenToWorldPoint(Input.mousePosition);
            mouseClick.z = 15f;
            isMoving = true;
        }

        if (isMoving)
        {
            transform.position = Vector3.SmoothDamp
                (
                transform.position,
                mouseClick,
                ref velocity,
                speed
                );

            direction = new Vector3
                (
                mouseClick.x - transform.position.x,
                mouseClick.y - transform.position.y
                );

            transform.up += direction;
        }
    }
}
