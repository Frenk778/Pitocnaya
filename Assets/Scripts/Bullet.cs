using System.Collections;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    [SerializeField] private int _damage = 5;
    [SerializeField] private float speed = 10f;

    private float _destroyTime = 5f;
    private Vector3 _direction;

    public int Damage { get => _damage; set => _damage = value; }

    private void Start()
    {
        StartCoroutine(DestroyAfterDelay());
    }

    public void SetDirection(Vector3 direction)
    {
        this._direction = direction;
    }

    public int GetDamage()
    {
        return Damage;
    }

    private void Update()
    {
        float distanceThisFrame = speed * Time.deltaTime;
        transform.Translate(_direction.normalized * distanceThisFrame, Space.World);
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            Hero hero = other.GetComponent<Hero>();
            if (hero != null)
            {
                hero.TakeDamage(Damage);
            }
        }

        Destroy(gameObject, _destroyTime);
    }

    private IEnumerator DestroyAfterDelay()
    {
        yield return new WaitForSeconds(_destroyTime);
        Destroy(gameObject);
    }
}