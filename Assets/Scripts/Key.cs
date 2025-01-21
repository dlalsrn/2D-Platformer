using UnityEngine;

public class Key : MonoBehaviour
{
    void OnCollisionEnter2D(Collision2D collision) {
        if (collision.collider.CompareTag("Player")) {
            PlayerController player = collision.collider.gameObject.GetComponent<PlayerController>();
            player.hasKey = true;
            GameObject.Destroy(gameObject);
        }
    }
}
