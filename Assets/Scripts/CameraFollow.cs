using UnityEngine;

public class CameraFollow : MonoBehaviour
{
    [SerializeField] private Vector3 _offset; 
    
    private Transform _target;

    void LateUpdate()
    {
        if (_target != null)
        {
            transform.position = _target.position + _offset;
        }
    }

    public void SetTarget(Transform target)
    {
        _target = target;
    }
}