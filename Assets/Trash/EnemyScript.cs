using UnityEngine;

public class EnemyScript : MonoBehaviour
{
    public Transform target;
    public float detectionRadius = 10f;
    public float shootingRadius = 5f;
    public GameObject bulletPrefab;
    public Transform firePoint;
    public float bulletSpeed;
    public float fireRate = 1f; 

    private Animator animator;
    private float fireTimer;

    private void Start()
    {
        animator = GetComponent<Animator>();
        fireTimer = fireRate; 
    }

    private void Update()
    {
        if (Vector3.Distance(transform.position, target.position) <= detectionRadius)
        {
            if (Vector3.Distance(transform.position, target.position) <= shootingRadius)
            {
                FireTimerUpdate();
            }
            else
            {
                StopFiringAnimation();
                LookAtTarget();
            }
        }
        else
        {
            StopFiringAnimation();
        }
    }

    private void StopFiringAnimation()
    {
        animator.ResetTrigger("Fire");
        animator.SetBool("Fire", false);
    }

    private void LookAtTarget()
    {
        Vector3 direction = target.position - transform.position;
        direction.y = 0;
        Quaternion rotation = Quaternion.LookRotation(direction);
        transform.rotation = rotation;
    }

    private void FireTimerUpdate()
    {
        fireTimer -= Time.deltaTime; 

        if (fireTimer <= 0f)
        {
            animator.SetTrigger("Fire");
            animator.SetBool("Fire", true);
            Shoot();
            fireTimer = fireRate;
        }
    }

    private void Shoot()
    {
        animator.SetTrigger("Fire");

        GameObject bulletObject = Instantiate(bulletPrefab, firePoint.position, Quaternion.Euler(0, transform.eulerAngles.y, 0));
        Bullet bullet = bulletObject.GetComponent<Bullet>();
        if (bullet != null)
        {
            Vector3 direction = target.position - firePoint.position;
            bullet.SetDirection(direction);
        }

        Rigidbody bulletRigidbody = bulletObject.GetComponent<Rigidbody>();
        bulletRigidbody.velocity = firePoint.forward * bulletSpeed;
    }
}
