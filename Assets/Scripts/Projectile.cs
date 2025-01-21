using UnityEngine;

public class Projectile : MonoBehaviour
{
    Rigidbody2D rigidbody2d;
    float rotate = 720f; // 초당 2바퀴
    float moveSpeed = 7f;

    void Awake() {
        rigidbody2d = GetComponent<Rigidbody2D>();
    }

    void FixedUpdate() {
        if (GameManager.Instance.State == GameManager.GameState.Pause) {
            return;
        }
        transform.Rotate(new Vector3(0, 0, rotate * Time.deltaTime));
    }

    public void Shoot(Vector3 dir) {
        rigidbody2d.velocity = dir * moveSpeed;
        GameObject.Destroy(gameObject, 5f);
    }

    void OnCollisionEnter2D(Collision2D collision) {
        if (collision.collider.CompareTag("Enemy")) {
            GameObject.Destroy(collision.collider.gameObject);
            GameObject.Destroy(gameObject);        
        }

        if (collision.collider.CompareTag("Platform")) {
            GameObject.Destroy(gameObject);        
        }
    }
}
