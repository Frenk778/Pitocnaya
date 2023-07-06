using UnityEngine;

public class CameraFollow : MonoBehaviour
{
    [SerializeField] private Transform _target;
    [SerializeField] private Vector3 _offset;

    void Start()
    {
        transform.position = _target.position + _offset;
    }

    void LateUpdate()
    {        
        if (_target != null)
        {
            transform.position = _target.position + _offset;
        }
    }
}
