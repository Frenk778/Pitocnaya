using UnityEngine;
using UnityEngine.UI;

public class Hero : MonoBehaviour
{
    [SerializeField] private int _health = 100;
    [SerializeField] private Slider _healthBar;
    [SerializeField] private Transform _healthpoint;    
    [SerializeField] public int _characterCost = 50;
    
    [field: SerializeField] public Transform Hips { get; private set; }
    public int Health { get => _health; set => _health = value; }
    

    private void Update()
    {
        Camera.main.WorldToScreenPoint(_healthpoint.position);
        Vector3 position= Camera.main.WorldToScreenPoint(_healthpoint.position);
        _healthBar.transform.position = position;        
        _healthBar.value = _health;        
    }

    public void TakeDamage(int damage)
    {
        _health -= damage;

        if (_health <= 0)
        {
            Die();
            _healthBar.gameObject.SetActive(false);
        }
    }

    private void Die()
    {
        Destroy(gameObject);
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Bullet"))
        {
            Bullet bullet = other.GetComponent<Bullet>();
            if (bullet != null)
            {
                TakeDamage(bullet.Damage);
                Destroy(other.gameObject);
            }
        }
    }
}