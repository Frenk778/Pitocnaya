using UnityEngine;
using UnityEngine.Events;


public class Destructable : MonoBehaviour
{
    [SerializeField] private GameObject _destructed;

    public UnityAction Destructed;

    private bool _isDestroyed = false;

    private void OnCollisionEnter(Collision collision)
    {
        if (!_isDestroyed && collision.gameObject.CompareTag("Player"))
        {
            Destruct();
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (!_isDestroyed && other.CompareTag("Player"))
        {
            Destruct();
        }
    }

    private void Destruct()
    {
        _isDestroyed = true;
        gameObject.SetActive(false);
        GameObject destructedObject = Instantiate(_destructed, transform.position, transform.rotation);
        destructedObject.SetActive(true);
        Destructed?.Invoke();
    }
}