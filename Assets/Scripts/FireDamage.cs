using UnityEngine;

public class FireDamage : MonoBehaviour
{
    [SerializeField] private int _damage = 10;   
    
    public int Damage { get => _damage; set => _damage = value; }

    public int GetDamage()
    {
        return Damage;
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
    }
}