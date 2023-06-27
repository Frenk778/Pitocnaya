using UnityEngine;

public class WebCollision : MonoBehaviour
{
    public float pullForce = 10f;  // ����, � ������� ������� ����� �������� �����

    void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Wall"))  // �������� "Wall" �� ���, ������� �� ����������� ��� ����
        {
            // ������� �������� �����
            GameObject player = GameObject.FindGameObjectWithTag("Player");  // �������� "Player" �� ���, ������� �� ����������� ��� �������� �����

            // ��������� ����, ����� ������ �������� ����� � �������
            Rigidbody playerRigidbody = player.GetComponent<Rigidbody>();
            playerRigidbody.AddForce((transform.position - player.transform.position).normalized * pullForce, ForceMode.Impulse);
        }
    }
}
