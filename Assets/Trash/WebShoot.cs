using UnityEngine;

public class WebShoot : MonoBehaviour
{
    public GameObject webPrefab;  // ������ �� ������ �������
    public Transform webAttachPoint;  // ����� ������������� ������� �� �����
    public float webSpeed = 10f;  // �������� ������ �������

    private GameObject currentWeb;  // ������� ��������� �������
    private SpringJoint webJoint;  // Spring Joint ���������

    void Update()
    {
        if (Input.GetButtonDown("Fire1"))  // ��������� ������ �������� �� ������ ����������
        {
            if (currentWeb == null)
            {
                // �������� ���������� �������
                currentWeb = Instantiate(webPrefab, transform.position, Quaternion.identity);
                LineRenderer lineRenderer = currentWeb.GetComponent<LineRenderer>();
                lineRenderer.positionCount = 2;
                lineRenderer.SetPosition(0, webAttachPoint.position);  // ������������� ����� ������ �����
                lineRenderer.SetPosition(1, webAttachPoint.position);  // ������������� ����� ����� �����

                // ������� �������� �������
                Rigidbody webRigidbody = currentWeb.GetComponent<Rigidbody>();
                webRigidbody.velocity = (webAttachPoint.position - transform.position).normalized * webSpeed;

                // ��������� Spring Joint
                webJoint = currentWeb.AddComponent<SpringJoint>();
                webJoint.connectedBody = GetComponent<Rigidbody>();
                webJoint.autoConfigureConnectedAnchor = false;
                webJoint.connectedAnchor = webAttachPoint.localPosition;
            }
        }

        if (Input.GetButtonUp("Fire1"))  // ��������� ������ ���������� �������� �� ������ ����������
        {
            if (currentWeb != null)
            {
                Destroy(currentWeb);  // ������� �������
                currentWeb = null;
                Destroy(webJoint);  // ������� Spring Joint
            }
        }
    }

}
