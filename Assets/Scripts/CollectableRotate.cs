using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CollectableRotate : MonoBehaviour
{
    [SerializeField] private int _rotateSpeed = 1;

    private void Update()
    {
        transform.Rotate(0, _rotateSpeed, 0,Space.World);
    }
}
