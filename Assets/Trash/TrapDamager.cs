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
        // �������� Collider ��������� ������ �������
        _collider = GetComponent<Collider>();
    }

    protected virtual void Start()
    {
        // ������������� ����� ���������� ����� � ��������� ��������
        _timeNextHit = 0f;
    }

    public void Init(float hitDelay, float damage)
    {
        // �������������� �������� ����� ������� � ����
        _hitDelay = hitDelay;
        _damage = damage;
    }

    protected virtual void OnCollisionStay(Collision collision)
    {
        // �������� ������, � ������� ��������� ������������
        GameObject other = collision.gameObject;

        // ���������, ���� ����� ���������� ����� ��� ������
        if (Time.time >= _timeNextHit)
        {
            // �������� ����� �������� ������������
            CollisionControll(other);

            // ������������� ����� ���������� �����
            _timeNextHit = Time.time + _hitDelay;
        }
    }

    protected virtual void OnTriggerStay(Collider collider)
    {
        // �������� ������, � ������� ��������� ���������������
        GameObject other = collider.gameObject;

        // ���������, ���� ����� ���������� ����� ��� ������
        if (Time.time >= _timeNextHit)
        {
            // �������� ����� �������� ���������������
            CollisionControll(other);

            // ������������� ����� ���������� �����
            _timeNextHit = Time.time + _hitDelay;
        }
    }

    protected virtual void CollisionControll(GameObject gameObject)
    {
        // �������� ��������� PlayerBone � ������� ������
        //PlayerBone playerBone = gameObject.GetComponent<PlayerBone>();

        //// ���������, ���� ��������� PlayerBone ������������
        //if (playerBone != null)
        //{
        //    // �������� ����� �����
        //    Hit(playerBone);
        //}
    }

    //protected virtual void Hit(PlayerBone playerBone)
    //{
    //    // ��������� ���� � ������
    //    playerBone.TakeDamage(_damage);
    //}
}

