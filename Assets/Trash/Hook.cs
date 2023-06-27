using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Hook : MonoBehaviour
{
    //[SerializeField] float hookForce = 25f;

    //Grapple grapple;
    //Rigidbody rigid;
    //LineRenderer lineRenderer;

    //public void Initialize(Grapple grapple, Transform shootTransform)
    //{
    //    transform.forward = shootTransform.forward;
    //    this.grapple = grapple;
    //    rigid = GetComponent<Rigidbody>();
    //    lineRenderer = GetComponent<LineRenderer>();
    //    rigid.AddForce(transform.forward * hookForce, ForceMode.Impulse);
    //}

    //void Update()
    //{
    //    Vector3[] positions = new Vector3[]
    //        {
    //            transform.position,
    //            grapple.transform.position
    //        };

    //    lineRenderer.SetPositions(positions);
    //}

    //private void OnTriggerEnter(Collider other)
    //{
    //    if ((LayerMask.GetMask("Grapple") & 1 << other.gameObject.layer) > 0)
    //    {
    //        rigid.useGravity = false;
    //        rigid.isKinematic = true;

    //        grapple.StartPull();
    //    }
    //}

    public GameObject bulletPrefab;
    public Transform bulletSpawnPoint;
    public float bulletForce = 10f;

    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            ShootBullet();
        }
    }

    void ShootBullet()
    {
        GameObject bullet = Instantiate(bulletPrefab, bulletSpawnPoint.position, bulletSpawnPoint.rotation);
        Rigidbody bulletRigidbody = bullet.GetComponent<Rigidbody>();
        bulletRigidbody.AddForce(bulletSpawnPoint.forward * bulletForce, ForceMode.Impulse);
    }
}