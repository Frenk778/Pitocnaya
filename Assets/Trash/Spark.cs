using System.Collections;
using UnityEngine;

public class Spark : MonoBehaviour
{
    private ParticleSystem _particleSystem;
    private Collider _collider;

    private Vector3 _targetPosition;  // ������� �������, � ������� �������� �������-�������
    private float _movementSpeed = 5f;  // �������� �������� �������-�������

    private void Awake()
    {
        _particleSystem = GetComponent<ParticleSystem>();
        _collider = GetComponent<Collider>();
        SetColliderActive(false);
    }

    public void MoveTo(Vector3 targetPosition)
    {
        _targetPosition = targetPosition;
        StartCoroutine(MoveToTarget());
    }

    //private IEnumerator MoveToTarget()
    //{
    //    // �������� ������� ������� �������-�������
    //    Vector3 startPosition = transform.position;

    //    float distance = Vector3.Distance(startPosition, _targetPosition);
    //    float elapsedTime = 0f;

    //    while (elapsedTime < distance / _movementSpeed)
    //    {
    //        // ��������� �������� �������� �� 0 �� 1
    //        float progress = elapsedTime / (distance / _movementSpeed);

    //        // ���������� �������-������� � ������� ������� � �������������� ������������
    //        transform.position = Vector3.Lerp(startPosition, _targetPosition, progress);

    //        elapsedTime += Time.deltaTime;
    //        yield return null;
    //    }

    //    // �������-������� �������� ������� �������
    //    transform.position = _targetPosition;
    //}
    private IEnumerator MoveToTarget()
    {
        Vector3 startPosition = _particleSystem.transform.position;

        float distance = Vector3.Distance(startPosition, _targetPosition);
        float elapsedTime = 0f;

        while (elapsedTime < distance / _movementSpeed)
        {
            float progress = elapsedTime / (distance / _movementSpeed);

            // ������ ���������� ������� �������-������� � �������������� SetColliderProperties
            // _particleSystem.trigger.SetColliderProperties(0, startPosition, Vector3.Lerp(startPosition, _targetPosition, progress));


            elapsedTime += Time.deltaTime;
            yield return null;
        }

        // �������-������� �������� ������� �������
        _particleSystem.transform.position = _targetPosition;
    }



    public void SetPosition(Vector3 point)
    {
        transform.position = point;
    }

    public void SetActive(bool value)
    {
        if (_particleSystem != null)
        {
            if (value)
            {
                _particleSystem.Play();
            }
            else
            {                
                _particleSystem.Clear();
            }
        }

        SetColliderActive(value);
    }

    private void SetColliderActive(bool value)
    {
        if (_collider != null)
        {
            _collider.enabled = value;
        }
    }
}
