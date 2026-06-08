using UnityEngine;

public class ScrollBackground : MonoBehaviour
{
    public Transform cam;

    private MeshRenderer mr;
    private Material mat;
    private Vector2 offsetMat;
    private Vector3 offsetCam;

    void Start()
    {
        mr = GetComponent<MeshRenderer>();
        mat = mr.material;

        offsetMat = mat.mainTextureOffset;
        offsetCam = new Vector3(0f, 0f, 5f);
    }

    void Update()
    {
        // background follows camera position
        transform.position = cam.position + offsetCam;

        // offsets background to ship position
        offsetMat.x = transform.position.x / transform.localScale.x;
        offsetMat.y = transform.position.y / transform.localScale.y;
        mat.mainTextureOffset = offsetMat;
    }
}
