using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Tesla : MonoBehaviour
{
    [SerializeField] private Transform _sparkPoint;

    public Vector3 Position
    {
        // Возвращаем позицию объекта Tesla
        get { return transform.position; }
    }

    public Vector3 GetSparkPosition()
    {
        // Возвращаем позицию точки _sparkPoint относительно объекта Tesla
        return _sparkPoint.position;
    }

    public float GetDamage()
    {
        // Возвращаем урон Tesla
        // Здесь вы можете реализовать логику для возвращения различных значений урона в зависимости от конкретной Tesla
        return 0f;
    }

    public Vector3[] GetPath()
    {
        // Возвращаем путь для перемещения Spark
        // Здесь вы можете реализовать логику для возвращения различных путей в зависимости от конкретной Tesla
        // Например, вы можете использовать массив Vector3 для указания последовательности точек пути
        return new Vector3[0];
    }
}

