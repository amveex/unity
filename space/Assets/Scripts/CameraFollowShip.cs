using UnityEngine;

public class CameraFollowShip : MonoBehaviour
{
    public Transform ship;

    private float smoothness = 0.03f;
    private Vector3 offset = new Vector3(0f, 0f, -1f);
    private Vector3 shipPosOffset;

    void Update()
    {
        shipPosOffset = ship.position + offset;

        transform.position = Vector3.Lerp
            (
            transform.position,
            shipPosOffset,
            smoothness
            );
    }
}
