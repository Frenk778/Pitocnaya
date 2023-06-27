using UnityEngine;

namespace TapAndUp.Traps
{
    public abstract class Trap : MonoBehaviour
    {
        [SerializeField] protected float _damage;
        [SerializeField] protected float _hitDelay;
        [SerializeField] protected Collider _collider;

        protected virtual void Awake()
        {            
            _collider.enabled = false;
        }
    }
}
