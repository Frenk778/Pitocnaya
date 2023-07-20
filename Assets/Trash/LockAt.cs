using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LockAt : MonoBehaviour
{
    private Camera Camera => Camera.main;

    private void Update()
    {
        Quaternion rotation = Camera.transform.rotation;
        transform.LookAt(transform.localPosition + rotation * Vector3.back, rotation * Vector3.up);
    }
}
