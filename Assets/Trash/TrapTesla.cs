using System.Collections;
using UnityEngine;

namespace TapAndUp.Traps
{
    public class TrapTesla : Trap
    {   
        [SerializeField] private float _delay;
        [SerializeField] private float _sparkSpeed;
        [SerializeField] private float _fullPathDelay;
        [SerializeField] private Tesla[] _teslas;
        [SerializeField] private Spark _spark;
        [SerializeField] private TrapDamager _trapDamager;

        private Tesla _currentTesla;
        private int _currentTeslaNum;

        protected override void Awake()
        {
            base.Awake();

            // ��� ������ ���� �������� ������ Tesla
            SetNextTesla();
        }

        private void SetNextTesla()
        {
            // ������������� ��������� Tesla � �������� �������
            _currentTeslaNum++;
            if (_currentTeslaNum >= _teslas.Length)
            {
                _currentTeslaNum = 0;
            }
            _currentTesla = _teslas[_currentTeslaNum];

            // ������ ������� � ���������� Spark �� ������� Tesla
            _spark.SetPosition(_currentTesla.GetSparkPosition());
            _spark.SetActive(true);

            // ��������� �������� ��� ����������� Spark �� ����
            StartCoroutine(CorMoveSpark());
        }

        private IEnumerator CorMoveSpark()
        {
            // �������� ���� ��� ����������� Spark
            Vector3[] path = _currentTesla.GetPath();

            // ������������ ����� �������� ����� ������� �� ����
            float delayPerPoint = _fullPathDelay / path.Length;

            // ���������� ��� ����� ����
            for (int i = 0; i < path.Length; i++)
            {
                // �������� ������� ����� �� ����
                Vector3 targetPoint = path[i];

                // ������� Spark � ������� ����� � ��������� ���������                
                _spark.MoveTo(targetPoint);

                // ����, ���� Spark ��������� ������� �����
                yield return new WaitUntil(() => _spark.transform.position == targetPoint);

                // ����� ���������� ����� ���� ��������� �����
                yield return new WaitForSeconds(delayPerPoint);
            }

            // �� ���������� ����� ���� ������������� Spark � ���������� ����
            _spark.SetActive(true);
            _trapDamager.Init(_delay, _currentTesla.GetDamage());

            // ���� ��������� �������� ����� ������������� �� ��������� Tesla
            yield return new WaitForSeconds(_delay);

            // �������� ��������� Tesla
            SetNextTesla();
        }
    }
}