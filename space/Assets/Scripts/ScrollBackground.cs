using UnityEngine;

public class ScrollBackground : MonoBehaviour
{
    public Transform cam;

    private MeshRenderer mr;
    private Material mat;
    private Vector2 offsetMat;
    private Vector3 offsetCam;
    private float parallax = 2f;

    private void Start()
    {
        mr = GetComponent<MeshRenderer>();
        mat = mr.material;

        offsetMat = mat.mainTextureOffset;
        offsetCam = new Vector3(0f, 0f, 300f);
    }

    private void Update()
    {
        // background follows camera position
        transform.position = cam.position + offsetCam;

        // offsets background to ship position
        offsetMat.x = transform.position.x / transform.localScale.x / parallax;
        offsetMat.y = transform.position.y / transform.localScale.y / parallax;
        mat.mainTextureOffset = offsetMat;
    }
}
