using UnityEngine;
using UnityEngine.UI;

public class LookCamera : MonoBehaviour
{
    [SerializeField] private Transform _camera;    

    private void LateUpdate()
    {
        transform.LookAt(_camera);
    }
}
