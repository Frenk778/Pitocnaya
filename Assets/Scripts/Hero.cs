using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using System;

public class Hero : MonoBehaviour
{
    [SerializeField] private int _health = 100;
    [SerializeField] private Slider _healthBar;
    [SerializeField] private string _levelToReset = "Level 1";    

    private void Update()
    {
        _healthBar.value=_health;
    }    

    public void TakeDamage(int damage)
    {
        _health -= damage;

        if (_health <= 0)
        {
            Die();
            _healthBar.gameObject.SetActive(false);            
            RestartLevel();
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

    private void RestartLevel()
    {
        SceneManager.LoadScene(_levelToReset);
    }    
}