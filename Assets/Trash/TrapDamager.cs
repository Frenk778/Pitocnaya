using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TrapDamager : MonoBehaviour
{    
    protected Collider _collider;

    [SerializeField] protected float _damage;

    [SerializeField] protected float _hitDelay;

    [SerializeField] protected float _timeNextHit;

    protected virtual void Awake()
    {
        // Получаем Collider компонент нашего объекта
        _collider = GetComponent<Collider>();
    }

    protected virtual void Start()
    {
        // Устанавливаем время следующего удара в начальное значение
        _timeNextHit = 0f;
    }

    public void Init(float hitDelay, float damage)
    {
        // Инициализируем задержку между ударами и урон
        _hitDelay = hitDelay;
        _damage = damage;
    }

    protected virtual void OnCollisionStay(Collision collision)
    {
        // Получаем объект, с которым произошло столкновение
        GameObject other = collision.gameObject;

        // Проверяем, если время следующего удара уже прошло
        if (Time.time >= _timeNextHit)
        {
            // Вызываем метод контроля столкновения
            CollisionControll(other);

            // Устанавливаем время следующего удара
            _timeNextHit = Time.time + _hitDelay;
        }
    }

    protected virtual void OnTriggerStay(Collider collider)
    {
        // Получаем объект, с которым произошло соприкосновение
        GameObject other = collider.gameObject;

        // Проверяем, если время следующего удара уже прошло
        if (Time.time >= _timeNextHit)
        {
            // Вызываем метод контроля соприкосновения
            CollisionControll(other);

            // Устанавливаем время следующего удара
            _timeNextHit = Time.time + _hitDelay;
        }
    }

    protected virtual void CollisionControll(GameObject gameObject)
    {
        // Получаем компонент PlayerBone с объекта игрока
        //PlayerBone playerBone = gameObject.GetComponent<PlayerBone>();

        //// Проверяем, если компонент PlayerBone присутствует
        //if (playerBone != null)
        //{
        //    // Вызываем метод удара
        //    Hit(playerBone);
        //}
    }

    //protected virtual void Hit(PlayerBone playerBone)
    //{
    //    // Применяем урон к игроку
    //    playerBone.TakeDamage(_damage);
    //}
}

