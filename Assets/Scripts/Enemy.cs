using UnityEngine;

public class Enemy : MonoBehaviour
{
    [SerializeField] private float _shotingInterval = 2f;
    [SerializeField] private GameObject _bulletPrefab;
    [SerializeField] private Transform _firePoint;

    private float _timeSinceLastShot = 0f;
    private int _damage = 5;

    private void Update()
    {
        _timeSinceLastShot += Time.deltaTime;

        if (_timeSinceLastShot >= _shotingInterval)
        {
            Shot();
            _timeSinceLastShot = 0f;
        }
    }

    private void Shot()
    {
        GameObject bullet = Instantiate(_bulletPrefab, _firePoint.position, _firePoint.rotation);

        Bullet bulletComponent = bullet.GetComponent<Bullet>();
        bulletComponent.SetDirection(_firePoint.forward);
        bulletComponent.Damage = _damage;
    }
}
