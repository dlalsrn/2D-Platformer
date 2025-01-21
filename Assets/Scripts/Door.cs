using UnityEngine;

public class Door : MonoBehaviour
{
    public Sprite opended;
    private SpriteRenderer spriteRenderer;
    private BoxCollider2D boxCollider2d;

    void Start() {
        spriteRenderer = GetComponent<SpriteRenderer>();
        boxCollider2d = GetComponent<BoxCollider2D>();
    }

    void OnCollisionEnter2D(Collision2D collision) {
        if (collision.collider.CompareTag("Player")) {
            PlayerController player = collision.collider.gameObject.GetComponent<PlayerController>();

            if (player.hasKey) { // 만약 키를 가지고 있으면
                spriteRenderer.sprite = opended;
                boxCollider2d.enabled = false;
                player.hasKey = false;
            }
        }
    }
}
