//using System.Collections;
//using System.Collections.Generic;
//using UnityEngine;

//public class Grapple : MonoBehaviour
//{
//    [SerializeField] float pullSpeed = 0.5f;
//    [SerializeField] float stopDistance = 4f;
//    [SerializeField] GameObject hookPrefab;
//    [SerializeField] Transform shootTransform;
//    [SerializeField] private Camera camera;

//    Hook hook;
//    bool pulling;
//    Rigidbody rigid;

    
//    void Start()
//    {
//        rigid = GetComponent<Rigidbody>();
//        pulling = false;


//        if (camera == null)
//        {
//            camera = Camera.main;
//        }
//    }
    
//    void Update()
//    {
//        if (hook == null && Input.GetMouseButtonDown(0))
//        {
//            StopAllCoroutines();
//            pulling = false;

//            Vector3 mousePosition = camera.ScreenToWorldPoint(Input.mousePosition);
//            mousePosition.z = 0f; // Установите z-координату в нуль или соответствующую плоскости вашей игры

//            hook = Instantiate(hookPrefab, shootTransform.position, Quaternion.identity).GetComponent<Hook>();
//            hook.Initialize(this, shootTransform);
//            StartCoroutine(DestroyHookAfterLifetime());
//        }
//        else if (hook != null && Input.GetMouseButtonDown(1))
//        {
//            DestroyHook();
//        }

//        if (!pulling || hook == null) return;

//        if (Vector3.Distance(transform.position, hook.transform.position) <= stopDistance)
//        {
//            DestroyHook();
//        }
//        else
//        {
//            rigid.AddForce((hook.transform.position - transform.position).normalized * pullSpeed, ForceMode.VelocityChange);
//        }
//    }

//    public void StartPull()
//    {
//        pulling = true;
//    }

//    private void DestroyHook()
//    {
//        if (hook == null) return;

//        pulling = false;
//        Destroy(hook.gameObject);
//        hook = null;
//    }

//    private IEnumerator DestroyHookAfterLifetime()
//    {
//        yield return new WaitForSeconds(8f);

//        DestroyHook();
//    }
//}