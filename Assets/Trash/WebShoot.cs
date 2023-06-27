using UnityEngine;

public class WebShoot : MonoBehaviour
{
    public GameObject webPrefab;  // Ссылка на префаб паутины
    public Transform webAttachPoint;  // Точка присоединения паутины на герое
    public float webSpeed = 10f;  // Скорость полета паутины

    private GameObject currentWeb;  // Текущий экземпляр паутины
    private SpringJoint webJoint;  // Spring Joint компонент

    void Update()
    {
        if (Input.GetButtonDown("Fire1"))  // Назначьте кнопку выстрела по своему усмотрению
        {
            if (currentWeb == null)
            {
                // Создание экземпляра паутины
                currentWeb = Instantiate(webPrefab, transform.position, Quaternion.identity);
                LineRenderer lineRenderer = currentWeb.GetComponent<LineRenderer>();
                lineRenderer.positionCount = 2;
                lineRenderer.SetPosition(0, webAttachPoint.position);  // Устанавливаем точку начала линии
                lineRenderer.SetPosition(1, webAttachPoint.position);  // Устанавливаем точку конца линии

                // Задание скорости паутины
                Rigidbody webRigidbody = currentWeb.GetComponent<Rigidbody>();
                webRigidbody.velocity = (webAttachPoint.position - transform.position).normalized * webSpeed;

                // Добавляем Spring Joint
                webJoint = currentWeb.AddComponent<SpringJoint>();
                webJoint.connectedBody = GetComponent<Rigidbody>();
                webJoint.autoConfigureConnectedAnchor = false;
                webJoint.connectedAnchor = webAttachPoint.localPosition;
            }
        }

        if (Input.GetButtonUp("Fire1"))  // Назначьте кнопку отпускания выстрела по своему усмотрению
        {
            if (currentWeb != null)
            {
                Destroy(currentWeb);  // Удаляем паутину
                currentWeb = null;
                Destroy(webJoint);  // Удаляем Spring Joint
            }
        }
    }

}
