using UnityEngine;

public class OrbitAround : MonoBehaviour
{
    public Transform target;

    private float speed = 0.025f;

    private void Update()
    {
        transform.RotateAround(target.position, Vector3.forward, speed * Time.deltaTime);
    }
}
