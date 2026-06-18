using UnityEngine;

public class RotatePlanet : MonoBehaviour
{
    private float speedX = 0.5f;
    private float speedY = 0.5f;

    private void Update()
    {
        transform.Rotate(speedX * Time.deltaTime, speedY * Time.deltaTime, 0f);
    }
}
