using UnityEngine;

public class CameraFollowShip : MonoBehaviour
{
    public Transform ship;

    private const float smoothness = 0.005f;
    private Vector3 offset = new Vector3(0f, 0f, -5f);
    private Vector3 shipPosOffset;

    private void Update()
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
