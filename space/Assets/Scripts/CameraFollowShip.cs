using UnityEngine;

public class CameraFollowShip : MonoBehaviour
{
    public Transform ship;

    private float smoothness = 0.25f;
    private Vector3 offset = new Vector3(0, 0, -20);
    private Vector3 velocity = Vector3.zero;

    void LateUpdate()
    {
        Vector3 shipPosition = ship.position + offset;

        transform.position = Vector3.SmoothDamp
            (
            transform.position,
            shipPosition,
            ref velocity,
            smoothness
            );
    }
}
