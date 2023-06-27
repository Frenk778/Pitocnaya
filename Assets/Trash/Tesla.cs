using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Tesla : MonoBehaviour
{
    [SerializeField] private Transform _sparkPoint;

    public Vector3 Position
    {
        // ���������� ������� ������� Tesla
        get { return transform.position; }
    }

    public Vector3 GetSparkPosition()
    {
        // ���������� ������� ����� _sparkPoint ������������ ������� Tesla
        return _sparkPoint.position;
    }

    public float GetDamage()
    {
        // ���������� ���� Tesla
        // ����� �� ������ ����������� ������ ��� ����������� ��������� �������� ����� � ����������� �� ���������� Tesla
        return 0f;
    }

    public Vector3[] GetPath()
    {
        // ���������� ���� ��� ����������� Spark
        // ����� �� ������ ����������� ������ ��� ����������� ��������� ����� � ����������� �� ���������� Tesla
        // ��������, �� ������ ������������ ������ Vector3 ��� �������� ������������������ ����� ����
        return new Vector3[0];
    }
}

