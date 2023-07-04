using UnityEngine;

public class EnemyScript : MonoBehaviour
{
    [SerializeField] private Transform _target;
    [SerializeField] private float _detectionRadius = 10f;
    [SerializeField] private float _shootingRadius = 5f;
    [SerializeField] private GameObject _bulletPrefab;
    [SerializeField] private Transform _firePoint;
    [SerializeField] private float _bulletSpeed;
    [SerializeField] private float _fireRate = 1f;    

    private Animator animator;
    private float fireTimer;

    private void Start()
    {
        animator = GetComponent<Animator>();
        fireTimer = _fireRate;
    }

    private void Update()
    {
        if(_target!=null&&Vector3.Distance(transform.position,_target.position)<=_detectionRadius)        
        {
            if (Vector3.Distance(transform.position, _target.position) <= _shootingRadius)
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
        Vector3 direction = _target.position - transform.position;
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
            fireTimer = _fireRate;
        }
    }

    private void Shoot()
    {
        animator.SetTrigger("Fire");

        GameObject bulletObject = Instantiate(_bulletPrefab, _firePoint.position, Quaternion.Euler(0, transform.eulerAngles.y, 0));
        Bullet bullet = bulletObject.GetComponent<Bullet>();
        if (bullet != null)
        {
            Vector3 direction = _target.position - _firePoint.position;
            bullet.SetDirection(direction);
        }

        Rigidbody bulletRigidbody = bulletObject.GetComponent<Rigidbody>();
        bulletRigidbody.velocity = _firePoint.forward * _bulletSpeed;
    }
}
