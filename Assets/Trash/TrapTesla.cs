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

            // При старте игры выбираем первую Tesla
            SetNextTesla();
        }

        private void SetNextTesla()
        {
            // Устанавливаем следующую Tesla в качестве текущей
            _currentTeslaNum++;
            if (_currentTeslaNum >= _teslas.Length)
            {
                _currentTeslaNum = 0;
            }
            _currentTesla = _teslas[_currentTeslaNum];

            // Задаем позицию и активность Spark на текущей Tesla
            _spark.SetPosition(_currentTesla.GetSparkPosition());
            _spark.SetActive(true);

            // Запускаем корутину для перемещения Spark по пути
            StartCoroutine(CorMoveSpark());
        }

        private IEnumerator CorMoveSpark()
        {
            // Получаем путь для перемещения Spark
            Vector3[] path = _currentTesla.GetPath();

            // Рассчитываем время задержки между точками на пути
            float delayPerPoint = _fullPathDelay / path.Length;

            // Перебираем все точки пути
            for (int i = 0; i < path.Length; i++)
            {
                // Получаем текущую точку на пути
                Vector3 targetPoint = path[i];

                // Двигаем Spark к текущей точке с указанной скоростью                
                _spark.MoveTo(targetPoint);

                // Ждем, пока Spark достигнет целевой точки
                yield return new WaitUntil(() => _spark.transform.position == targetPoint);

                // После достижения точки ждем указанное время
                yield return new WaitForSeconds(delayPerPoint);
            }

            // По достижении конца пути останавливаем Spark и активируем удар
            _spark.SetActive(true);
            _trapDamager.Init(_delay, _currentTesla.GetDamage());

            // Ждем указанную задержку перед переключением на следующую Tesla
            yield return new WaitForSeconds(_delay);

            // Выбираем следующую Tesla
            SetNextTesla();
        }
    }
}