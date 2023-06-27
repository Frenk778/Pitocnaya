using UnityEngine;

public class WebCollision : MonoBehaviour
{
    public float pullForce = 10f;  // —ила, с которой паутина т€нет главного геро€

    void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Wall"))  // «амените "Wall" на тег, который вы используете дл€ стен
        {
            // Ќаходим главного геро€
            GameObject player = GameObject.FindGameObjectWithTag("Player");  // «амените "Player" на тег, который вы используете дл€ главного геро€

            // ѕримен€ем силу, чтобы т€нуть главного геро€ к паутине
            Rigidbody playerRigidbody = player.GetComponent<Rigidbody>();
            playerRigidbody.AddForce((transform.position - player.transform.position).normalized * pullForce, ForceMode.Impulse);
        }
    }
}
