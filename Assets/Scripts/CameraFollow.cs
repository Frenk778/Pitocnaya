using UnityEngine;

public class CameraFollow : MonoBehaviour
{
    public Transform target;
    public Vector3 offset;

    void Start()
    {
        transform.position = target.position + offset;
    }

    void LateUpdate()
    {        
        if (target != null)
        {
            transform.position = target.position + offset;
        }
    }
}
