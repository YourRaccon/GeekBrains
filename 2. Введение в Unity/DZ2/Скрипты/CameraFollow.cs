using UnityEngine;

public class CameraFollow : MonoBehaviour
{
    public GameObject target;
    public Vector3 cameraOffsetPosition;

    void Update()
    {
        gameObject.transform.position = target.transform.position + cameraOffsetPosition;
    }
}
